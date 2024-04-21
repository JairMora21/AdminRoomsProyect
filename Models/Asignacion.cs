using System;
using System.Collections.Generic;

namespace AdminRooms.Models;

public partial class Asignacion
{
    public int IdAsignacion { get; set; }

    public int IdCuarto { get; set; }

    public int IdCasa { get; set; }

    public int IdHuesped { get; set; }

    public DateTime? UltimoPago { get; set; }

    public bool? Pago { get; set; }

    public virtual ICollection<Cobro> Cobros { get; set; } = new List<Cobro>();

    public virtual ICollection<Cuarto> Cuartos { get; set; } = new List<Cuarto>();

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual Casa IdCasaNavigation { get; set; } = null!;

    public virtual Cuarto IdCuartoNavigation { get; set; } = null!;

    public virtual Huesped IdHuespedNavigation { get; set; } = null!;
}
