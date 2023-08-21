using ShoppingWeb.Models.DTOs;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;

namespace ShoppingWeb.Web.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly HttpClient httpClient;

        public ShoppingCartService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<CartItemDto> AddItemToCart(CartItemToAddDto cartItemToAddDto)
        {
            try
            {
                var result = await httpClient.PostAsJsonAsync<CartItemToAddDto>("api/ShoppingCart/add-item-to-cart", cartItemToAddDto);
                if (result.IsSuccessStatusCode)
                {
                    if (result.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(CartItemDto);
                    }
                    return await result.Content.ReadFromJsonAsync<CartItemDto>();
                }
                else
                {
                    var message = await result.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<IEnumerable<CartItemDto>> GetCartItems(Guid userId)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/ShoppingCart/{userId}/get-items");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        return null;
                    else
                        return await response.Content.ReadFromJsonAsync<IEnumerable<CartItemDto>>();
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CartItemDeleteDto> DeleteItem(int id)
        {
            try
            {
                var requestContent = new StringContent(id.ToString(), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("api/ShoppingCart/delete-item", requestContent);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        return null;
                    else
                        return await response.Content.ReadFromJsonAsync<CartItemDeleteDto?>();
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
