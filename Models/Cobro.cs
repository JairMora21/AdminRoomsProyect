using System;
using System.Collections.Generic;

namespace AdminRooms.Models;

public partial class Cobro
{
    public int IdCobros { get; set; }

    public int IdAsignacion { get; set; }

    public DateTime Periodo { get; set; }

    public double Monto { get; set; }

    public virtual Asignacion IdAsignacionNavigation { get; set; } = null!;
}
