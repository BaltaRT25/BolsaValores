using BolsaValores.Shared.DTO;

namespace BolsaValores.Client.Services
{
    public class Bot : IBot
    {
        public Bot(IAccion accion) 
        {
            Accion = accion;
        }
        public IAccion Accion { get; }

        public async Task<string> DefinirRespuestaMenu(string respuestaUsuario)
        {
            var accion = new AccionDTO();
            string respuestaBot = string.Empty;
            switch(respuestaUsuario)
            {
                case "0":
                    respuestaBot = DefinirRespuestaPorDefault();
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
                case "3":
                    accion = await Accion.Consultar("AAPL");
                    respuestaBot = DefinirRespuestaAccion(accion);
                    break;
                case "4":
                    accion = await Accion.Consultar("TSLA");
                    respuestaBot = DefinirRespuestaAccion(accion);
                    break;
                case "5":
                    accion = await Accion.Consultar("GOOG");
                    respuestaBot = DefinirRespuestaAccion(accion);
                    break;
                default:
                    respuestaBot = @"No pude obtener la respuesta <br/>" + DefinirRespuestaPorDefault();
                    break;
            }
            return respuestaBot;
        }
        public string DefinirRespuestaAccion(AccionDTO accion)
        {
            if (accion != null && !String.IsNullOrEmpty(accion.Codigo))
            {
                return $"El precio de la acción <b>{accion.Codigo}</b> <br/>" +
                               $"<ul>" +
                               $"<li><b>Fecha</b>: {accion.Fecha.Date.ToString("d")}</li>" +
                               $"<li><b>Hora</b>: {accion.Hora.ToString("H:mm")}</li>" +
                               $"<li><b>Abre en: </b>: {accion.Abre}</li>" +
                               $"<li><b>Cierra en: </b>: {accion.Cierra}</li>" +
                               $"<li><b>Precio más bajo: </b>: {accion.Baja}</li>" +
                               $"<li><b>Precio más alto: </b>: {accion.Alta}</li>" +
                               $"</ul>" +
                               $"<br/> 0. Volver al inicio" +
                               $"<br/> 1. Consultar otra empresa";
            }
            else
            {
                return "No pude obtener la respuesta <br/>" + DefinirRespuestaPorDefault();
            }
        }
        string DefinirRespuestaPorDefault()
        {
            return @"¿En qué puedo ayudarte? <br/><br/> 1. Consultar precios de acciones <br/> 2. Ver mi historial de consultas";
        }
    }
}
