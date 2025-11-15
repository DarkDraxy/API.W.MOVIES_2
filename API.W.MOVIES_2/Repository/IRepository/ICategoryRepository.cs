using API.W.MOVIES_2.DAL.Models;

namespace API.W.MOVIES_2.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetCategoriesAsync();//Me retorna una lista de categorias
        
        Task<Category> GetCategoryAsync(int Id);//Me retorna una categoria por su Id

        Task<bool> CategoryExistsByIdAsync(int Id);//Me retorna true o false si existe la categoria por su Id

        Task<bool> CategoryExistsByNameAsync(string Name);//Me retorna true o false si existe la categoria por su Nombre


        Task<bool> CreateCategoryAsync(Category category);//Me crea una nueva categoria

        Task<bool> UpdateCategoryAsync(Category category);//Me actualiza una categoria existente

        Task<bool> DeleteCategoryAsync(int id);//Me elimina una categoria existente

       
    }
}
