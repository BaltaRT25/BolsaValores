using BolsaValores.Shared.DTO;

namespace BolsaValores.Client.Services
{
    public interface IAccion
    {
        Task<AccionDTO> Consultar(string idAccion);
    }
}
