using System;
using System.Collections.Generic;

namespace BolsaValores.DataAccess.Persistences.BolsaValores;

public partial class Accion
{
    public string IdAccion { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public DateTime Hora { get; set; }

    public decimal? Abre { get; set; }

    public decimal? Cierra { get; set; }

    public decimal? Alta { get; set; }

    public decimal? Baja { get; set; }

    public virtual ICollection<BitacoraHistorial> BitacoraHistorial { get; set; } = new List<BitacoraHistorial>();
}
