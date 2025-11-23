using API.W.MOVIES_2.DAL.Models;
using API.W.MOVIES_2.DAL.Models.DTO;
using API.W.MOVIES_2.Services;
using API.W.MOVIES_2.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.W.MOVIES_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieServices _MovieServices;
        public MoviesController(IMovieServices MovieServices)
        {
            _MovieServices = MovieServices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<MoviesDTO>>> GetMoviesAsyn()
        {
            var Movies = await _MovieServices.GetMoviesAsync();
            return Ok(Movies);
        }

        [HttpGet("{id:int}", Name = "GetMovieAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MoviesDTO>> GetMovieAsyn(int id)
        {
            var MovieDTO = await _MovieServices.GetMovieAsync(id);
            if (MovieDTO == null)
            {
                return NotFound(new { Message = $"No se encontro la pelicula con Id {id}"});
            }
            return Ok(MovieDTO);
        }

        [HttpPost(Name = "CreateMovieAsyn")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<MoviesDTO>> CreateMovieAsyn([FromBody] MovieCreateUpdateDto MovieCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var createdMovie = await _MovieServices.CreateMovieAsync(MovieCreateDTO);
                return CreatedAtRoute(
                    "GetCategoryAsync",
                    new { id = createdMovie.Id },
                    createdMovie);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
        
        [HttpPut("{id:int}", Name = "UpdateMovieAsyn")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryDTO>> UpdateMovieAsyn([FromBody] MovieCreateUpdateDto MovieCreateUpdateDTO, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var updatedMovie = await _MovieServices.UpdateMovieAsync(MovieCreateUpdateDTO, id);
                if(updatedMovie==null)
                {
                    return NotFound(new { Message = $"No se encontro la pelicula con Id {id}" });
                }
                return Ok(updatedMovie);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
        /*
        [HttpDelete("{id:int}", Name = "DeleteCategoryAsyn")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteCategoryAsyn(int id)
        {

            try
            {
                var deletedCategory = await _categoryServices.DeleteCategoryAsync(id);
                return Ok(deletedCategory);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("No se encontró"))
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }*/
    }
}
