using System.ComponentModel.DataAnnotations;

namespace AdminRooms.Models.ViewModel
{
    public class FacturaViewModel
    {
        [Key]
        public int IdFactura { get; set; }
        [Required]
        public string Huesped { get; set; } = null!;
        [Required]
        public DateTime Fecha { get; set; }

        public string? Concepto { get; set; }
        [Required]
        public double Monto { get; set; }

        public int idAsignacion { get; set; }

        public string Correo { get; set; }

        public string MontoTexto { get; set; }

        public bool PagoEfectivo { get; set; }
        public bool PagoTransferencia { get; set; }
        public bool RetiroSinTarjeta { get; set; }


    }
}
