using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace AdminRooms.Models;

public partial class Huesped
{
    public int IdHuesped { get; set; }

    public int? IdCasa { get; set; }

    public int? IdCuarto { get; set; }

    public int IdGenero { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    [Display(Name = "Motivo estancia")]
    public string? MotivoEstancia { get; set; }

    public string Telefono { get; set; } = null!;

    [Display(Name = "Tel. Emergencia")]
    public string? TelefonoEmergencia { get; set; }
    public string? Correo { get; set; }

    [Display(Name = "Pago inicial")]
    public double? PagoInicial { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Fecha de alta")]
    public DateTime? FechaAlta { get; set; }


    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Salida prevista")]
    public DateTime? FechaSalidaPrev { get; set; }


    public string? Alacena { get; set; }

    public string? Refrigerador { get; set; }

    public virtual ICollection<Asignacion> Asignacions { get; set; } = new List<Asignacion>();

    public virtual ICollection<Cuarto> Cuartos { get; set; } = new List<Cuarto>();

    [Display(Name = "Casa")]
    public virtual Casa? IdCasaNavigation { get; set; }

    [Display(Name = "Cuarto")]
    public virtual Cuarto? IdCuartoNavigation { get; set; }

    [Display(Name = "Genero")]
    public virtual Genero IdGeneroNavigation { get; set; } = null!;
}
