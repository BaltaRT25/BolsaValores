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
    public class BitacoraErrorBL : IBitacoraErrorBL
    {
        public BitacoraErrorBL(IBitacoraErrorDAL bitacora) 
        {
            Bitacora = bitacora;
        }
        public IBitacoraErrorDAL Bitacora { get; }

        public async Task<bool> RegistrarMovimiento(string descripcion)
        {
            var error = new BitacoraErrores();
            error.IdBitacoraErrores = Guid.NewGuid().ToString();
            error.Fecha = DateTime.Now;
            error.Descripcion = descripcion;
            return await Bitacora.RegistrarMovimiento(error);
        }
    }
}
