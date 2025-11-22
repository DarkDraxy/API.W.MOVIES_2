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

        public async Task<CategoryDTO> CreateCategoryAsync(CategoryCreateUpdateDto categoryCreateDTO)
        {
            //validar si la categoria ya existe
            var categoryExists = await _categoryRepository.CategoryExistsByNameAsync(categoryCreateDTO.Name);
            if (categoryExists)
            {
                throw new InvalidOperationException($"Ya existe una categoria con el nombre de '{categoryCreateDTO.Name}' ");
            }

            //mapear el DTO a la entidad
            var categoryEntity = _mapper.Map<Category>(categoryCreateDTO);

            //crear la categoria
            var categoryCreated = await _categoryRepository.CreateCategoryAsync(categoryEntity);
            if (!categoryCreated)
            {
                throw new Exception("Error al crear la categoria");
            }

            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            //verificar si la categoria existe
            var existingCategory = await _categoryRepository.GetCategoryAsync(id);
            if (existingCategory == null)
            {
                throw new InvalidOperationException($"No se encontró la categoria con Id {id}");
            }

            //Eliminar la categoria
            var categoryDeleted = await _categoryRepository.DeleteCategoryAsync(id);
            if (!categoryDeleted)
            {
                throw new Exception("Error al actualizar la categoria");
            }

            return categoryDeleted;
        
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

        public async Task<CategoryDTO> UpdateCategoryAsync(CategoryCreateUpdateDto category, int id)
        {
            //verificar si la categoria existe
            var existingCategory = await _categoryRepository.GetCategoryAsync(id);
            if (existingCategory == null)
            {
                throw new KeyNotFoundException($"No se encontro la categoria con Id {id}");
            }

            //verificar si el nombre de la categoria ya existe en otra categoria
            var categoryExists = await _categoryRepository.CategoryExistsByNameAsync(category.Name);

            if (categoryExists)
            {
                throw new InvalidOperationException($"Ya existe una categoria con el nombre de '{category.Name}' ");
            }

            //mapear los cambios del DTO a la entidad existente
            _mapper.Map(category, existingCategory);

            //actualizar la categoria
            var categoryUpdated = await _categoryRepository.UpdateCategoryAsync(existingCategory);
            if (!categoryUpdated)
            {
                throw new Exception("Error al actualizar la categoria");
            }

            return _mapper.Map<CategoryDTO>(existingCategory);
        }



    }
}
