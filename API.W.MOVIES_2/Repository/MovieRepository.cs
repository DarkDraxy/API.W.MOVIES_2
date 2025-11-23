using API.W.MOVIES_2.DAL;
using API.W.MOVIES_2.DAL.Models;
using API.W.MOVIES_2.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
namespace API.W.MOVIES_2.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDBContext _context;

        public MovieRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> MovieExistsByIdAsync(int Id)
        {
            return await _context.Movies.
                AsNoTracking().
                AnyAsync(c => c.Id == Id);
        }

        public async Task<bool> MovieExistsByNameAsync(string Name)
        {
            return await _context.Movies.
                AsNoTracking().
                AnyAsync(c => c.Name == Name);
        }

        public async Task<bool> CreateMovieAsync(Movie Movie)
        {
            Movie.CreatedDate = DateTime.UtcNow;

            var addedCategory = await _context.Movies.AddAsync(Movie);

            return await SaveAsync();

        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var Movie = await GetMovieAsync(id);  //first check if it exists in DB

            if (Movie == null)
            {
                return false; //category not found
            }

            _context.Movies.Remove(Movie);
            return await SaveAsync();
        }

        public async Task<ICollection<Movie>> GetMoviesAsync()
        {
            var Movie = await _context.Movies.
                AsNoTracking().
                OrderBy(c => c.Name).
                ToListAsync();
            return Movie;
        }

        public async Task<Movie> GetMovieAsync(int Id)
        {
            return await _context.Movies.
                AsNoTracking().
                FirstOrDefaultAsync(c => c.Id == Id); //lamda expressions
                                                      //select * from categories Where Id = id

        }

        public async Task<bool> UpdateMovieAsync(Movie Movie)
        {
            Movie.ModifiedDate = DateTime.UtcNow;

            _context.Movies.Update(Movie);

            return await SaveAsync();
        }

        private async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }
    }
}
