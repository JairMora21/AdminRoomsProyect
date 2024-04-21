using System.ComponentModel.DataAnnotations;

namespace AdminRooms.Models.ViewModel
{
    public class CasaViewModel
    {
        [Required]
        [Display(Name = "Nombre casa")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }

        [Required]
        [Display(Name = "No. Cuartos")]
        public int NumeroCuartos { get; set; }

    }
}
