using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaValores.Shared.DTO
{
    public class PrecioAccionSolicitudDTO
    {
        public string TipoAccion { get; set; } = string.Empty;
        public string UsuarioSolicitante { get; set; } = string.Empty;
    }
}
