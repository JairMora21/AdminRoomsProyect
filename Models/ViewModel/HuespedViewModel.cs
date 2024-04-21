using System.ComponentModel.DataAnnotations;

namespace AdminRooms.Models.ViewModel
{
    public class HuespedViewModel
    {
        [Key]
        public int IdHuesped { get; set; }

        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public int Genero { get; set; }

        [Required]
        [Display(Name = "Motivo de estancia")]
        public string MotivoEstancia { get; set; }

        [Required]
        public string Telefono { get; set; } = null!;

        [Required]
        [Display(Name = "Telefono de emergencia")]

        public string TelefonoEmergencia { get; set; }

        public int idCuarto { get; set; }

        [Required]
        public string? Correo { get; set; }

        [Display(Name = "Pago inicial")]
        public double? PagoInicial { get; set; }

        [Display(Name = "Fecha de salida prevista")]
        public DateTime? FechaSalidaPrev { get; set; }

        [Display(Name = "Fecha alta")]
        public DateTime? FechaAlta { get; set; }

        public string? Alacena { get; set; }

        public string? Refrigerador { get; set; }
    }
}
