using API.W.MOVIES_2.DAL;
using API.W.MOVIES_2.DAL.Models;
using API.W.MOVIES_2.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace API.W.MOVIES_2.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _context;

        public CategoryRepository(ApplicationDBContext context)
        {
            _context = context; 
        }

        public async Task<bool> CategoryExistsByIdAsync(int Id)
        {
            return await _context.Categories.
                AsNoTracking().
                AnyAsync(c => c.Id == Id);
        }

        public async Task<bool> CategoryExistsByNameAsync(string Name)
        {
            return await _context.Categories.
                AsNoTracking().
                AnyAsync(c => c.Name == Name);
        }

        public async Task<bool> CreateCategoryAsync(Category category)
        {
            category.CreatedDate = DateTime.UtcNow;

            var addedCategory = await _context.Categories.AddAsync(category);

            return await SaveAsync();

        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await GetCategoryAsync(id);  //first check if it exists in DB

            if (category == null)
            {
                return false; //category not found
            }

            _context.Categories.Remove(category);
            return await SaveAsync();
        }

        public async Task<ICollection<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.
                AsNoTracking().
                OrderBy(c => c.Name).
                ToListAsync(); 
        }

        public async Task<Category> GetCategoryAsync(int Id)
        {
            return await _context.Categories.
                AsNoTracking().
                FirstOrDefaultAsync(c => c.Id == Id); //lamda expressions
            //select * from categories Where Id = id
            
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            category.ModifiedDate = DateTime.UtcNow;

            _context.Categories.Update(category);

            return await SaveAsync();
        }

        private async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }
    }
}
