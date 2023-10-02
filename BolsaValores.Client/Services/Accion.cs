using BolsaValores.Shared.DTO;
using System.Net.Http.Json;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace BolsaValores.Client.Services
{
    public class Accion : IAccion
    {
        public Accion(HttpClient httpCliente) 
        {
            HttpCliente = httpCliente;
        }
        public HttpClient HttpCliente { get; }

        public async Task<AccionDTO> Consultar(string idAccion)
        {
            try
            {
                var accion = await HttpCliente.GetAsync($"https://localhost:7222/Bot/Consultar/{idAccion}");

                if (accion.IsSuccessStatusCode)
                {
                    return JsonSerializer.Deserialize<AccionDTO>(await accion.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true });
                }
                else
                {
                    return new AccionDTO();
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return new AccionDTO();
            }
        }
    }
}
