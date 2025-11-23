using API.W.MOVIES_2.DAL.Models;
using Microsoft.EntityFrameworkCore;
namespace API.W.MOVIES_2.DAL
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Movie> Movies { get; set; }
    }
}
