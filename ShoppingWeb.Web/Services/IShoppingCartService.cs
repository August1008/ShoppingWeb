using ShoppingWeb.Models.DTOs;

namespace ShoppingWeb.Web.Services
{
    public interface IShoppingCartService
    {
        public Task<CartItemDto> AddItemToCart(CartItemToAddDto cartItemToAddDto);
        public Task<IEnumerable<CartItemDto>> GetCartItems(Guid userId);
    }
}
