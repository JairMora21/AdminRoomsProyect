using System;
using System.Collections.Generic;

namespace AdminRooms.Models;

public partial class Genero
{
    public int IdGenero { get; set; }

    public string Genero1 { get; set; } = null!;

    public virtual ICollection<Huesped> Huespeds { get; set; } = new List<Huesped>();
}
