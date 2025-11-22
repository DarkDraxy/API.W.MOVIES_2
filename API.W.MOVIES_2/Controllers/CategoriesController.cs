using API.W.MOVIES_2.DAL.Models;
using API.W.MOVIES_2.DAL.Models.DTO;
using API.W.MOVIES_2.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.W.MOVIES_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;
        public CategoriesController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<CategoryDTO>>> GetCategoriesAsyn()
        {
            var categories = await _categoryServices.GetCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "GetCategoryAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryDTO>> GetCategoryAsyn(int id)
        {
            var categoriesDTO = await _categoryServices.GetCategoryAsync(id);
            return Ok(categoriesDTO);
        }

        [HttpPost(Name = "CreateCategoryAsyn")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<CategoryDTO>> CreateCategoryAsyn([FromBody] CategoryCreateUpdateDto categoryCreateDTO)
        {
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState);
            }
            try 
            {
                var createdCategory = await _categoryServices.CreateCategoryAsync(categoryCreateDTO);
                return CreatedAtRoute(
                    "GetCategoryAsync", 
                    new {id = createdCategory.Id} , 
                    createdCategory);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("Ya existe"))
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPut("{id:int}",Name = "UpdateCategoryAsyn")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryDTO>> UpdateCategoryAsyn([FromBody] CategoryCreateUpdateDto categoryCreateDTO, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var updatedCategory = await _categoryServices.UpdateCategoryAsync(categoryCreateDTO, id);
                return Ok(updatedCategory);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("Ya existe"))
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}
