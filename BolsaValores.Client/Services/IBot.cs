using BolsaValores.Shared.DTO;

namespace BolsaValores.Client.Services
{
    public interface IBot
    {
        Task<string> DefinirRespuestaMenu(string respuestaUsuario);
        string DefinirRespuestaAccion(AccionDTO accion);
    }
}
