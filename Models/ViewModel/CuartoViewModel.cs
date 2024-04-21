using System.ComponentModel.DataAnnotations;

namespace AdminRooms.Models.ViewModel
{
    public class CuartoViewModel
    {
        [Key]
        public int IdCuarto { get; set; }
        [Required]
        public double? Costo { get; set; }

        [Display (Name = "Numero de Cuarto")]
        public int NumeroCuarto { get; set; }




}
}
