using API.W.MOVIES_2.DAL.Models;

namespace API.W.MOVIES_2.Repository.IRepository
{
    public interface IMovieRepository
    {
        Task<ICollection<Movie>> GetMoviesAsync();//Me retorna una lista de peliculas

        Task<Movie> GetMovieAsync(int Id);//Me retorna una pelicula por su Id

        Task<bool> MovieExistsByIdAsync(int Id);//Me retorna true o false si existe la pelicula por su Id

        Task<bool> MovieExistsByNameAsync(string Name);//Me retorna true o false si existe la pelicula por su Nombre


        Task<bool> CreateMovieAsync(Movie Movie);//Me crea una nueva pelicula

        Task<bool> UpdateMovieAsync(Movie Movie);//Me actualiza una pelicula existente

        Task<bool> DeleteMovieAsync(int id);//Me elimina una pelicula existente
    }
}
