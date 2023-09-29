using BolsaValores.Business.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaValores.Business.Core
{
    public class BotBL : IBotBL
    {
        public BotBL(IConfiguration configuracion) 
        {
            Configuracion = configuracion;
        }
        private readonly IConfiguration Configuracion;

        public void RecibirMensaje()
        {
            

        }
        public string ResponderMensaje()
        {
            return "Hola, soy " + " y mi nombre es ";
        }
    }
}
