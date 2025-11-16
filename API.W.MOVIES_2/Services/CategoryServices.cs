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

        public async Task<bool> CategoryExistsByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CategoryExistsByNameAsync(string Name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<CategoryDTO>> GetCategoriesAsync()
        {
            var category = await _categoryRepository.GetCategoriesAsync();//solo llamo al repositorio

            return _mapper.Map<ICollection<CategoryDTO>>(category);//mapeo a DTO
        }

        public async Task<CategoryDTO> GetCategoryAsync(int Id)
        {
            var categories = await _categoryRepository.GetCategoryAsync(Id);//solo llamo al repositorio

            return _mapper.Map<CategoryDTO>(categories);//mapeo a DTO
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
