using BolsaValores.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaValores.Business.Interfaces
{
    public interface IHistorialBL
    {
        Task<int> CalcularTotalHistorialPorUsuario(string correoUsuario);
        Task<List<HistorialDTO>> ObtenerHistorialPorUsuario(string correoUsuario, int omitir, int tomar);
    }
}
