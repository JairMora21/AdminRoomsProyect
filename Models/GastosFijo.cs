using System;
using System.Collections.Generic;

namespace AdminRooms.Models;

public partial class GastosFijo
{
    public int IdGastosFijos { get; set; }

    public int IdTipoGasto { get; set; }

    public string Nombre { get; set; } = null!;

    public double? Monto { get; set; }

    public DateTime? FechaPagado { get; set; }

    public DateTime? FechaAviso { get; set; }

    public bool? Pagado { get; set; }

    public virtual TipoGasto IdTipoGastoNavigation { get; set; } = null!;
}
