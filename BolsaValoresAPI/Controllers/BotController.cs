using BolsaValores.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BolsaValoresAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class BotController : ControllerBase
    {
        public BotController(IBotBL bot) 
        {
            Bot = bot;
        }
        public IBotBL Bot { get; }

        [HttpPost("RecibirMensaje")]
        public string RecibirMensaje() 
        {
            return Bot.ResponderMensaje();
        }
    }
}
