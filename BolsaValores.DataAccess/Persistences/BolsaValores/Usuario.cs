using System;
using System.Collections.Generic;

namespace BolsaValores.DataAccess.Persistences.BolsaValores;

public partial class Usuario
{
    public string Correo { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public virtual ICollection<BitacoraHistorial> BitacoraHistorial { get; set; } = new List<BitacoraHistorial>();
}
