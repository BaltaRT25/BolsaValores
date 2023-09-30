using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaValores.Shared.DTO
{
    public class AccionAuxiliarDTO
    {
        public string Symbol { get; set; } = string.Empty;
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public double Open { get; set; }
        public double High { get; set; } 
        public double Low { get; set; } 
        public double Close { get; set; } 
        public int Volume { get; set; }
    }
}
