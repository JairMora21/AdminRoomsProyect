using System;
using System.Collections.Generic;

namespace AdminRooms.Models;

public partial class Casa
{
    public int IdCasa { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public int NumeroCuartos { get; set; }

    public virtual ICollection<Asignacion> Asignacions { get; set; } = new List<Asignacion>();

    public virtual ICollection<Cuarto> Cuartos { get; set; } = new List<Cuarto>();

    public virtual ICollection<Huesped> Huespeds { get; set; } = new List<Huesped>();
}
