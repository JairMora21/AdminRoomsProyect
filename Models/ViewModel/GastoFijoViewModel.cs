using System.ComponentModel.DataAnnotations;

namespace AdminRooms.Models.ViewModel
{
    public class GastoFijoViewModel
    {
        [Key]
        public int IdGastosFijos { get; set; }
        [Required]
        public string Nombre { get; set; } = null!;
        [Required]
        public double? Monto { get; set; }
        [Display(Name ="Fecha aviso de cobro")]
        [Required]
        public DateTime? FechaAviso { get; set; }

    }
}
