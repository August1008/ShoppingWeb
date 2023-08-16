using ShoppingWeb.Api.Entities;
using ShoppingWeb.Models.DTOs;

namespace ShoppingWeb.Api.Repositories.Interfaces
{
    public interface IShoppingCartRepository
    {
        Task<CartItem> GetItemAsync(int id);
        Task<IEnumerable<CartItemDto>> GetItemsInCartAsync(int cardId);
        Task<CartItemDto> AddItemAsync(CartItemToAddDto cartItemToAdd);
        Task<CartItem> UpdateItemQuantityAsync(int quantity);
        Task<CartItem> DeleteItem(int id);
        Task<IEnumerable<CartItemDto>> GetAllItemsAsync(Guid userId);
    }
}
