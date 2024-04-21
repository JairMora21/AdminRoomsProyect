using System.ComponentModel.DataAnnotations;

namespace AdminRooms.Models.ViewModel
{
    public class GastoSemiFijoViewModel
    {
        [Key]
        public int IdGastosFijos { get; set; }

        [Required]
        public string Nombre { get; set; } = null!;

        public double? Monto { get; set; }


    }
}
