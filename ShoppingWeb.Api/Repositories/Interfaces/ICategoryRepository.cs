using ShoppingWeb.Api.Entities;

namespace ShoppingWeb.Api.Repositories
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetCategories();
        public Task<Category> GetCategoryById(int id);
    }
}
