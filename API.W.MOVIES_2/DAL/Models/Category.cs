using System.ComponentModel.DataAnnotations;

namespace API.W.MOVIES_2.DAL.Models
{
    public class Category : AuditBase
    {
        [Required]
        [Display(Name = "Nombre de la categoria")]
        public string Name { get; set; }
    }
}
