using System.ComponentModel.DataAnnotations;
namespace ServicesDeskUCAB.DTO
{
    public class EstadoDTO
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Ingrese un Estado")]
        [StringLength(128, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} debe ser mayor a 0")]
        public int etiquetaId { get; set; }

        public string etiqueta { get; set; }
    }
}