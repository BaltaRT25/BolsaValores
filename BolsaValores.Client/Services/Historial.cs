using BolsaValores.Shared.DTO;
using System.Text.Json;

namespace BolsaValores.Client.Services
{
    public class Historial : IHistorial
    {
        public Historial(HttpClient httpCliente)
        {
            HttpCliente = httpCliente;
        }
        public HttpClient HttpCliente { get; }

        public async Task<int> CalcularTotalHistorialPorUsuario()
        {
            try
            {

                var totalHistorial = await HttpCliente.GetAsync($"https://localhost:7222/Historial/CalcularTotalHistorialPorUsuario");

                if (totalHistorial.IsSuccessStatusCode)
                {
                    return JsonSerializer.Deserialize<int>(await totalHistorial.Content.ReadAsStringAsync());
                }
                else
                {
                    return 0;
                }
                
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public async Task<List<HistorialDTO>> ObtenerHistorialPorUsuario(int omitir, int tomar)
        {
            try
            {

                var historialPeticion = await HttpCliente.GetAsync($"https://localhost:7222/Historial/ObtenerHistorialPorUsuario/{omitir}/{tomar}");

                if (historialPeticion.IsSuccessStatusCode)
                {
                    return JsonSerializer.Deserialize<List<HistorialDTO>>(await historialPeticion.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true });
                }
                else
                {
                    return new List<HistorialDTO>();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<HistorialDTO>();
            }
        }
    }
}
