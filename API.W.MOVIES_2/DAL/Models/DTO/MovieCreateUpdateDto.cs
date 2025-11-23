using System.ComponentModel.DataAnnotations;
namespace API.W.MOVIES_2.DAL.Models.DTO
{
    public class MovieCreateUpdateDto
    {
        [Required(ErrorMessage = "El nombre de la pelicula es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El numero maximo de caracteres es de 100.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La duración  de la pelicula es obligatoria.")]
        public int Duration { get; set; }
        public string? Description { get; set; }

        [Required(ErrorMessage = "La clasificación de la pelicula es obligatorio.")]
        [MaxLength(10, ErrorMessage = "El numero maximo de caracteres es de 10.")]
        public string Clasification { get; set; }
    }
}
