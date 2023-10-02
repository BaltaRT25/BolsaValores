using BolsaValores.Business.Interfaces;
using BolsaValores.DataAccess.Data;
using BolsaValores.DataAccess.Interfaces;
using BolsaValores.Shared.DTO;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaValores.Business.Core
{
    public class HistorialBL : IHistorialBL
    {
        public HistorialBL(IHistorialDAL historial) 
        {
            Historial = historial;
        }
        public IHistorialDAL Historial { get; }

        public async Task<int> CalcularTotalHistorialPorUsuario(string correoUsuario)
        {
            return await Historial.CalcularTotalHistorialPorUsuario(correoUsuario);
        }

        public async Task<List<HistorialDTO>> ObtenerHistorialPorUsuario(string correoUsuario, int omitir, int tomar)
        {
            return (await Historial.ObtenerHistorialPorUsuario(correoUsuario, omitir, tomar)).Adapt<List<HistorialDTO>>();
        }
    }
}
