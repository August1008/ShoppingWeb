using ShoppingWeb.Api.Entities;
using ShoppingWeb.Models.DTOs;

namespace ShoppingWeb.Api.Repositories
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetProducts();
        public Task<IEnumerable<ProductDto>> GetProductDtos();
        public Task<ProductDto?> GetProductById(int id);
    }
}
