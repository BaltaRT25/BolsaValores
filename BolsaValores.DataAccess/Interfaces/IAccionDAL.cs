using BolsaValores.DataAccess.Persistences.BolsaValores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaValores.DataAccess.Interfaces
{
    public interface IAccionDAL
    {
        Task<bool> RegistrarConsulta(Accion accion);
    }
}
