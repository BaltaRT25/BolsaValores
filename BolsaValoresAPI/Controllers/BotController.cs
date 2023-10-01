using BolsaValores.Business.Interfaces;
using BolsaValores.Shared.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BolsaValoresAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class BotController : ControllerBase
    {
        public BotController(IAccionBL accionBL) 
        {
            AccionBL = accionBL;
        }
        public IAccionBL AccionBL { get; }

        [HttpGet("Consultar/{idAccion}")]
        public async Task<AccionDTO> Consultar(string idAccion) 
        {
            //de aquí se tomaría del token, el correo del usuario que realiza la petición
            return await AccionBL.Consultar(idAccion,"usuario@bolsa.com");
        }
    }
}
