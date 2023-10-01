using BolsaValores.Business.Interfaces;
using BolsaValores.DataAccess.Interfaces;
using BolsaValores.DataAccess.Persistences.BolsaValores;
using BolsaValores.Shared.DTO;
using Mapster;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BolsaValores.Business.Core
{
    public class AccionBL : IAccionBL
    {
        public AccionBL(IConfiguration configuracion, IAccionDAL accionDAL, IBitacoraErrorBL bitacoraError, IBitacoraHistorialBL bitacoraHistorial) 
        {
            Configuracion = configuracion;
            AccionDAL = accionDAL;
            BitacoraError = bitacoraError;
            BitacoraHistorial = bitacoraHistorial;
        }
        public IConfiguration Configuracion { get; }
        public IAccionDAL AccionDAL { get; }
        public IBitacoraErrorBL BitacoraError { get; }
        public IBitacoraHistorialBL BitacoraHistorial { get; }

        public async Task<AccionDTO> Consultar(string codigo, string correoUsuario)
        {
            var accion = new AccionDTO();
            var archivoAccion = await ObtenerAccionAPI(codigo);

            if (!String.IsNullOrEmpty(archivoAccion))
            {
                accion = GenerarModeloRespuesta(archivoAccion);
                var idAccion = Guid.NewGuid().ToString();
                var registroConsultaAccion = await Registrar(accion, idAccion);
                var registroHistorial = await BitacoraHistorial.RegistrarMovimiento(correoUsuario,idAccion);
            }
            return accion;
        }

        async Task<string> ObtenerAccionAPI(string codigo)
        {
            try
            {
                HttpClient httpcliente = new HttpClient();
                return await httpcliente.GetStringAsync($"https://stooq.com/q/l/?s={codigo}.us&f=sd2t2ohlcv&h&e=csv");
            }
            catch(Exception ex) 
            {
                var errorRegistrado = await BitacoraError.RegistrarMovimiento(ex.Message.ToString());
                return string.Empty;
            }
        }
        AccionDTO GenerarModeloRespuesta(string archivoAccion)
        {
            var filasAccion = archivoAccion.Split("\r\n").ToList();
            var valorFilaAccion = filasAccion[1].Split(",").ToList();
            var accion = new AccionDTO();
            accion.Codigo = !String.IsNullOrEmpty(valorFilaAccion[0]) ? valorFilaAccion[0] : "No encontrado";
            accion.Fecha = !String.IsNullOrEmpty(valorFilaAccion[1]) ? Convert.ToDateTime(valorFilaAccion[1]) : DateTime.Now;
            accion.Hora = !String.IsNullOrEmpty(valorFilaAccion[2]) ? Convert.ToDateTime(valorFilaAccion[1]) : DateTime.Now;
            accion.Abre = !String.IsNullOrEmpty(valorFilaAccion[3]) ? Decimal.Parse(valorFilaAccion[3]) : 0;
            accion.Alta = !String.IsNullOrEmpty(valorFilaAccion[4]) ? Decimal.Parse(valorFilaAccion[4]) : 0;
            accion.Baja = !String.IsNullOrEmpty(valorFilaAccion[5]) ? Decimal.Parse(valorFilaAccion[5]) : 0; 
            accion.Cierra = !String.IsNullOrEmpty(valorFilaAccion[6]) ? Decimal.Parse(valorFilaAccion[6]) : 0;
            return accion;
        }

        public async Task<bool> Registrar(AccionDTO accionDTO, string idAccion)
        {
            var accionDB = accionDTO.Adapt<Accion>();
            accionDB.IdAccion = idAccion;
            return await AccionDAL.Registrar(accionDB);
        }
    }
}
