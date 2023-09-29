namespace BolsaValores.Client.Services
{
    public class ServicioBot : IServicioBot
    {
        public string DefinirRespuestaMenu(string respuestaUsuario)
        {
            string respuestaBot = string.Empty;
            switch(respuestaUsuario)
            {
                case "0":
                    respuestaBot = $"Hola, bienvenido a la bolsa de valores stock <br/> ¿En qué puedo ayudarte? <br/><br/> 1. Consultar precios de acciones <br/> 2. Ver mi historial de consultas";
                    break;
                case "1":
                    respuestaBot = $"Perfecto. ¿Cuál empresa de las siguientes deseas consultar?" +
                                   $"<br/> 3. Apple" +
                                   $"<br/> 4. Tesla" +
                                   $"<br/> 5. Google" +
                                   $"<br/> 0. Regresar al inicio";
                    break;
                case "2":
                    respuestaBot = "De acuerdo. ";
                    break;
                default:
                    respuestaBot = $"Hola, bienvenido a la bolsa de valores stock <br/> ¿En qué puedo ayudarte? <br/><br/> 1. Consultar precios de acciones <br/> 2. Ver mi historial de consultas";
                    break;
            }
            return respuestaBot;
        }
    }
}
