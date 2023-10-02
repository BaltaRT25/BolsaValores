using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaValores.Shared.DTO
{
    public class HistorialDTO
    {
        public DateTime FechaConsulta { get; set; }

        public string Codigo { get; set; } = null!;

        public DateTime Fecha { get; set; }

        public DateTime Hora { get; set; }

        public decimal? Abre { get; set; }

        public decimal? Cierra { get; set; }

        public decimal? Alta { get; set; }

        public decimal? Baja { get; set; }
    }
}
