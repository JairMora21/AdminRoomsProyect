using System;
using System.Collections.Generic;

namespace AdminRooms.Models;

public partial class Usuario
{
    public int IdUser { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string Contraseña { get; set; } = null!;
}
