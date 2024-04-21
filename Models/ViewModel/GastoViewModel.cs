using System.ComponentModel.DataAnnotations;

namespace AdminRooms.Models.ViewModel
{
    public class GastoViewModel
    {
        [Key]
        public int IdGasto { get; set; }
        public int idGastoRegistro { get; set; }
        [Required]
        public string Nombre { get; set; } = null!;

        [Required]
        public double Monto { get; set; }
        [Required]
        public DateTime Fecha { get; set; }

        public DateTime? FechaAviso { get; set; }

        public bool ActivarAviso { get; set; }

    }
}
