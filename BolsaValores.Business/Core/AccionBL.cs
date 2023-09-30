using BolsaValores.Business.Interfaces;
using BolsaValores.Shared.DTO;
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
        public AccionBL(IConfiguration configuracion) 
        {
            Configuracion = configuracion;
        }
        public IConfiguration Configuracion { get; }

        public async Task<AccionDTO> Consultar(string idAccion)
        {
            var accion = new AccionDTO();
            var archivoAccion = await ObtenerAccionAPI(idAccion);

            if (!String.IsNullOrEmpty(archivoAccion))
            {
                accion = GenerarModeloRespuesta(archivoAccion);
            }
            return accion;
        }

        async Task<string> ObtenerAccionAPI(string idAccion)
        {
            try
            {
                HttpClient httpcliente = new HttpClient();
                return await httpcliente.GetStringAsync($"https://stooq.com/q/l/?s={idAccion}.us&f=sd2t2ohlcv&h&e=csv");
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }
        AccionDTO GenerarModeloRespuesta(string archivoAccion)
        {
            var fecha = DateTime.Now;
            var filasAccion = archivoAccion.Split("\r\n").ToList();
            var valorFilaAccion = filasAccion[1].Split(",").ToList();
            var accion = new AccionDTO();
            accion.Id = !String.IsNullOrEmpty(valorFilaAccion[0]) ? valorFilaAccion[0] : "No encontrado";
            accion.Fecha = !String.IsNullOrEmpty(valorFilaAccion[1]) ? Convert.ToDateTime(valorFilaAccion[1]) : DateTime.Now;
            accion.Hora = !String.IsNullOrEmpty(valorFilaAccion[2]) ? Convert.ToDateTime(valorFilaAccion[2]) : DateTime.Now;
            accion.Abre = !String.IsNullOrEmpty(valorFilaAccion[3]) ? Double.Parse(valorFilaAccion[3]) : 0;
            accion.Alto = !String.IsNullOrEmpty(valorFilaAccion[4]) ? Double.Parse(valorFilaAccion[4]) : 0;
            accion.Bajo = !String.IsNullOrEmpty(valorFilaAccion[5]) ? Double.Parse(valorFilaAccion[5]) : 0; 
            accion.Cierra = !String.IsNullOrEmpty(valorFilaAccion[6]) ? Double.Parse(valorFilaAccion[6]) : 0;
            return accion;
        }
    }
}
