using System;
using System.Collections.Generic;

namespace BolsaValores.DataAccess.Persistences.BolsaValores;

public partial class BitacoraHistorial
{
    public string IdBitacoraHistorial { get; set; } = null!;

    public string IdAccion { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public virtual Usuario CorreoNavigation { get; set; } = null!;

    public virtual Accion IdAccionNavigation { get; set; } = null!;
}
