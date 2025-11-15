using System.ComponentModel.DataAnnotations;
using System.Data;

namespace API.W.MOVIES_2.DAL.Models.DTO
{
    public class CategoryDTO
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la categoria es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El numero maximo de caracteres es de 100.")]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
