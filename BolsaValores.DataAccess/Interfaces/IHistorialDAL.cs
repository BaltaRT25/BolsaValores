using BolsaValores.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaValores.DataAccess.Interfaces
{
    public interface IHistorialDAL
    {
        Task<int> CalcularTotalHistorialPorUsuario(string correoUsuario);
        Task<List<Historial>> ObtenerHistorialPorUsuario(string correoUsuario, int omitir, int tomar);
    }
}
