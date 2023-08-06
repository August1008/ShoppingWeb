using Microsoft.EntityFrameworkCore;
using ShoppingWeb.Api.DataContext;
using ShoppingWeb.Api.Entities;

namespace ShoppingWeb.Api.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShoppingWebDataContext _dbContext;
        public CategoryRepository(ShoppingWebDataContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await _dbContext.Categories.ToListAsync();
            return categories;
        }

        public Task<Category> GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
