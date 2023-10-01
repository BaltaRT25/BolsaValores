using System;
using System.Collections.Generic;

namespace BolsaValores.DataAccess.Persistences.BolsaValores;

public partial class BitacoraErrores
{
    public string IdBitacoraErrores { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string Descripcion { get; set; } = null!;
}
