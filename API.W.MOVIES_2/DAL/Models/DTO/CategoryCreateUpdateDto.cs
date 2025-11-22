using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace API.W.MOVIES_2.DAL.Models.DTO
{
    public class CategoryCreateUpdateDto
    {
        [Required(ErrorMessage = "El nombre de la categoria es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El numero maximo de caracteres es de 100.")]
        public string Name { get; set; }
    }
}
