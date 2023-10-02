using BolsaValores.Business.Interfaces;
using BolsaValores.Shared.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BolsaValoresAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HistorialController : ControllerBase
    {
        public HistorialController(IHistorialBL historial) 
        {
            Historial = historial;
        }
        public IHistorialBL Historial { get; }

        [HttpGet("CalcularTotalHistorialPorUsuario")]
        public async Task<int> CalcularTotalHistorialPorUsuario()
        {
            //de aquí tomaría el usuario del token
            return await Historial.CalcularTotalHistorialPorUsuario("usuario@bolsa.com");
        }

        [HttpGet("ObtenerHistorialPorUsuario/{omitir}/{tomar}")]
        public async Task<List<HistorialDTO>> ObtenerHistorialPorUsuario(int omitir, int tomar)
        {
            //de aquí tomaría el usuario del token
            return await Historial.ObtenerHistorialPorUsuario("usuario@bolsa.com",omitir, tomar);
        }
    }
}
