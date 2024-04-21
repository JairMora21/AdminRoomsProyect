using System;
using System.Collections.Generic;

namespace AdminRooms.Models;

public partial class Gasto
{
    public int IdGasto { get; set; }

    public int? IdTipoGasto { get; set; }

    public int? IdGastoFijo { get; set; }

    public double Monto { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public virtual TipoGasto? IdTipoGastoNavigation { get; set; }
}
