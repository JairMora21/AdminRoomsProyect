using System;
using System.Collections.Generic;

namespace AdminRooms.Models;

public partial class GastosRegistro
{
    public int IdGastosRegistro { get; set; }

    public int IdGastos { get; set; }

    public double Monto { get; set; }

    public virtual Gasto IdGastosNavigation { get; set; } = null!;
}
