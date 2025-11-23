using API.W.MOVIES_2.DAL.Models;
using API.W.MOVIES_2.DAL.Models.DTO;
using API.W.MOVIES_2.Repository.IRepository;
using API.W.MOVIES_2.Services.IServices;
using AutoMapper;
namespace API.W.MOVIES_2.Services
{
    public class MovieServices : IMovieServices
    {
        private readonly IMovieRepository _MovieRepository;
        private readonly IMapper _mapper;

        public MovieServices(IMovieRepository IMovieRepository, IMapper mapper)
        {
            _MovieRepository = IMovieRepository;
            _mapper = mapper;
        }

        public async Task<bool> MovieExistsByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> MovieExistsByNameAsync(string Name)
        {
            throw new NotImplementedException();
        }

        public async Task<MoviesDTO> CreateMovieAsync(MovieCreateUpdateDto MovieCreateDTO)
        {

            //mapear el DTO a la entidad
            var MovieEntity = _mapper.Map<Movie>(MovieCreateDTO);

            //crear la Pelicula
            var MovieCreated = await _MovieRepository.CreateMovieAsync(MovieEntity);
            if (!MovieCreated)
            {
                throw new Exception("Error al crear la categoria");
            }

            return _mapper.Map<MoviesDTO>(MovieEntity);
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            //verificar si la Pelicula existe
            var existingMovie = await _MovieRepository.GetMovieAsync(id);
            if (existingMovie == null)
            {
                throw new InvalidOperationException($"No se encontró la Pelicula con Id {id}");
            }

            //Eliminar la Pelicuka
            var MovieDeleted = await _MovieRepository.DeleteMovieAsync(id);
            if (!MovieDeleted)
            {
                throw new Exception("Error al actualizar la categoria");
            }

            return MovieDeleted;

        }

        public async Task<ICollection<MoviesDTO>> GetMoviesAsync()
        {
            var Movie = await _MovieRepository.GetMoviesAsync();//solo llamo al repositorio

            return _mapper.Map<ICollection<MoviesDTO>>(Movie);//mapeo a DTO
        }

        public async Task<MoviesDTO> GetMovieAsync(int Id)
        {
            var movies = await _MovieRepository.GetMovieAsync(Id);//solo llamo al repositorio

            return _mapper.Map<MoviesDTO>(movies);//mapeo a DTO
        }

        public async Task<MoviesDTO> UpdateMovieAsync(MovieCreateUpdateDto Movie, int id)
        {
            //verificar si la Pelicula existe
            var existingMovie = await _MovieRepository.GetMovieAsync(id);
            if (existingMovie == null)
            {
                return null;
                //throw new KeyNotFoundException($"No se encontro la pelicula con Id {id}");
            }

            //mapear los cambios del DTO a la entidad existente
            _mapper.Map(Movie, existingMovie);

            //actualizar la pelicula
            var MovieUpdated = await _MovieRepository.UpdateMovieAsync(existingMovie);
            if (!MovieUpdated)
            {
                throw new Exception("Error al actualizar la Pelicula");
            }

            return _mapper.Map<MoviesDTO>(existingMovie);
        }


    }
}
