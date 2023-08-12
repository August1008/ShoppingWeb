using ShoppingWeb.Models.DTOs;

namespace ShoppingWeb.Web.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProduct(int productId);
    }
}
