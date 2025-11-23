using System.ComponentModel.DataAnnotations;

namespace API.W.MOVIES_2.DAL.Models
{
    public class Movie : AuditBase
    {
        [Required]
        [Display(Name = "Nombre de la categoria")]
        public string Name { get; set; }
        public int Duration { get; set; }
        public string? Description { get; set; }
        public string Clasification { get; set; }
    }
}


