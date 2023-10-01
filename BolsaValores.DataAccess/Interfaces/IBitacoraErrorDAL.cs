using BolsaValores.DataAccess.Persistences.BolsaValores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaValores.DataAccess.Interfaces
{
    public interface IBitacoraErrorDAL
    {
        Task<bool> RegistrarMovimiento(BitacoraErrores bitacora);
    }
}
