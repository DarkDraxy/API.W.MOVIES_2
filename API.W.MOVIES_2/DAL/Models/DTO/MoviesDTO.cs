using System.ComponentModel.DataAnnotations;
namespace API.W.MOVIES_2.DAL.Models.DTO
{
    public class MoviesDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [Required(ErrorMessage = "El nombre de la pelicula es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El numero maximo de caracteres es de 100.")]
        public string Name { get; set; }
        public int Duration { get; set; }
        public string? Description { get; set; }
        public string Clasification { get; set; }

    }
}
