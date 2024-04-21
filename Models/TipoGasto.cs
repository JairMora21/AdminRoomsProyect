using System;
using System.Collections.Generic;

namespace AdminRooms.Models;

public partial class TipoGasto
{
    public int IdTipoGasto { get; set; }

    public int? IdTemp { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();

    public virtual ICollection<GastosFijo> GastosFijos { get; set; } = new List<GastosFijo>();
}
