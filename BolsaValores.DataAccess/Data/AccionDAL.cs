using BolsaValores.DataAccess.Interfaces;
using BolsaValores.DataAccess.Persistences.BolsaValores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaValores.DataAccess.Data
{
    public class AccionDAL : IAccionDAL
    {
        public AccionDAL(BolsaValoresTestContext bolsaValoresTestContext) 
        {
            BolsaValoresTestContext = bolsaValoresTestContext;
        }
        public BolsaValoresTestContext BolsaValoresTestContext { get; }

        public async Task<bool> RegistrarConsulta(Accion accion)
        {
            try
            {
                BolsaValoresTestContext.Accion.Add(accion);
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
