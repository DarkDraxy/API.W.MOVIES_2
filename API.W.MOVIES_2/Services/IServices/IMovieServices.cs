using API.W.MOVIES_2.DAL.Models.DTO;
namespace API.W.MOVIES_2.Services.IServices
{
    public interface IMovieServices
    {
        Task<ICollection<MoviesDTO>> GetMoviesAsync();//Me retorna una lista de peliculas

        Task<MoviesDTO> GetMovieAsync(int Id);//Me retorna una pelicula por su Id

        Task<bool> MovieExistsByIdAsync(int Id);//Me retorna true o false si existe la pelicula por su Id

        Task<bool> MovieExistsByNameAsync(string Name);//Me retorna true o false si existe la pelicula por su Nombre


        Task<MoviesDTO> CreateMovieAsync(MovieCreateUpdateDto MovieCreateUpdateDto);//Me crea una nueva pelicula

        Task<MoviesDTO> UpdateMovieAsync(MovieCreateUpdateDto MovieCreateUpdateDto, int id);//Me actualiza una pelicula existente

        Task<bool> DeleteMovieAsync(int id);//Me elimina una pelicula existente
    }
}
