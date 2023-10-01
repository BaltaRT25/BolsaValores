using BolsaValores.DataAccess.Interfaces;
using BolsaValores.DataAccess.Persistences.BolsaValores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaValores.DataAccess.Data
{
    public class BitacoraErrorDAL : IBitacoraErrorDAL
    {
        public BitacoraErrorDAL(BolsaValoresTestContext bolsaValoresTestContext)
        {
            BolsaValoresTestContext = bolsaValoresTestContext;
        }
        public BolsaValoresTestContext BolsaValoresTestContext { get; }

        public async Task<bool> RegistrarMovimiento(BitacoraErrores bitacora)
        {
            try
            {
                BolsaValoresTestContext.BitacoraErrores.Add(bitacora);
                await BolsaValoresTestContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
