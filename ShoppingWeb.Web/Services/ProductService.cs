using ShoppingWeb.Models.DTOs;
using System.Net.Http.Json;

namespace ShoppingWeb.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            try
            {
                var products = await _httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("/api/Product/get-items");
                return products;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
