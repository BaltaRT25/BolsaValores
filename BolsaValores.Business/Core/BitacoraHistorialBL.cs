using BolsaValores.Business.Interfaces;
using BolsaValores.DataAccess.Interfaces;
using BolsaValores.DataAccess.Persistences.BolsaValores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaValores.Business.Core
{
    public class BitacoraHistorialBL : IBitacoraHistorialBL
    {
        public BitacoraHistorialBL(IBitacoraHistorialDAL bitacora) 
        {
            Bitacora = bitacora;
        }

        public IBitacoraHistorialDAL Bitacora { get; }

        public async Task<bool> RegistrarMovimiento(string correoUsuario, string idAccion)
        {
            var bitacoraHistorial = new BitacoraHistorial();
            bitacoraHistorial.IdBitacoraHistorial = Guid.NewGuid().ToString();
            bitacoraHistorial.Correo = correoUsuario;
            bitacoraHistorial.IdAccion= idAccion;
            bitacoraHistorial.Fecha = DateTime.Now;
            return await Bitacora.RegistrarMovimiento(bitacoraHistorial);
        }
    }
}
