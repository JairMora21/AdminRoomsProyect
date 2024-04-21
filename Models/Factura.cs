using System;
using System.Collections.Generic;

namespace AdminRooms.Models;

public partial class Factura
{
    public int IdFactura { get; set; }

    public int? IdAsignacion { get; set; }

    public string Huesped { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string? Concepto { get; set; }

    public double Monto { get; set; }

    public virtual Asignacion? IdAsignacionNavigation { get; set; }
}
