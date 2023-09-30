using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaValores.Shared.DTO
{
    public class AccionDTO
    {
        public string Id { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public double Abre { get; set; }
        public double Alto { get; set;}
        public double Bajo { get; set;}
        public double Cierra { get; set;}
    }
}
