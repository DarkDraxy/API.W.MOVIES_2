using API.W.MOVIES_2.DAL.Models;
using API.W.MOVIES_2.DAL.Models.DTO;
using API.W.MOVIES_2.Repository.IRepository;
using API.W.MOVIES_2.Services.IServices;
using AutoMapper;

namespace API.W.MOVIES_2.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryServices(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public Task<bool> CategoryExistsByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CategoryExistsByNameAsync(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<CategoryDTO>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();//solo llamo al repositorio

            return _mapper.Map<ICollection<CategoryDTO>>(categories);//mapeo a DTO
        }

        public Task<CategoryDTO> GetCategoryAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
