using BolsaValores.Shared.DTO;

namespace BolsaValores.Client.Services
{
    public interface IHistorial
    {
        Task<int> CalcularTotalHistorialPorUsuario();
        Task<List<HistorialDTO>> ObtenerHistorialPorUsuario(int omitir, int tomar);
    }
}
