using System;
using System.Collections.Generic;

namespace AdminRooms.Models;

public partial class Cuarto
{
    public int IdCuarto { get; set; }

    public int? IdHuesped { get; set; }

    public int? IdCasa { get; set; }

    public int? IdAsignacion { get; set; }

    public int? NumeroCuarto { get; set; }

    public double? Costo { get; set; }

    public bool? Disponibilidad { get; set; }

    public virtual ICollection<Asignacion> Asignacions { get; set; } = new List<Asignacion>();

    public virtual ICollection<Huesped> Huespeds { get; set; } = new List<Huesped>();

    public virtual Asignacion? IdAsignacionNavigation { get; set; }

    public virtual Casa? IdCasaNavigation { get; set; }

    public virtual Huesped? IdHuespedNavigation { get; set; }
}
