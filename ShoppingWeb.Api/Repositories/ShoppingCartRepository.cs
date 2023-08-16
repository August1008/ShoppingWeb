using Microsoft.EntityFrameworkCore;
using ShoppingWeb.Api.DataContext;
using ShoppingWeb.Api.Entities;
using ShoppingWeb.Api.Repositories.Interfaces;
using ShoppingWeb.Models.DTOs;

namespace ShoppingWeb.Api.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ShoppingWebDataContext _dbContext;
        public ShoppingCartRepository(ShoppingWebDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        private async Task<bool> IsExistInCart(int cartId, int productId)
        {
            return await (from ci in _dbContext.CartItems
                          where ci.ProductId == productId && ci.ProductId == cartId
                          select ci.Id)
                          .AnyAsync();
        }
        public async Task<CartItemDto> AddItemAsync(CartItemToAddDto cartItemToAdd)
        {
            //need to check if item exist in cart
            if (!await IsExistInCart(cartItemToAdd.CardId, cartItemToAdd.ProductId))
            {
                CartItem newCartItem = new CartItem
                {
                    CartId = cartItemToAdd.CardId,
                    ProductId = cartItemToAdd.ProductId,
                    Quantity = cartItemToAdd.Quantity
                };
                var result = await _dbContext.CartItems.AddAsync(newCartItem);
                await _dbContext.SaveChangesAsync();
                return await (from p in _dbContext.Products
                              where p.Id == result.Entity.Id
                              select new CartItemDto
                              {
                                  CardId = result.Entity.Id,
                                  ProductId = p.Id,
                                  ProductName = p.Name,
                                  ProductPrice = p.Price,
                                  Quantity = result.Entity.Quantity,
                                  ImageUrl = p.ImageUrl
                              }).SingleOrDefaultAsync();
            }
            return null;
        }

        public async Task<CartItem> DeleteItem(int id)
        {
            var cartItem = await _dbContext.CartItems.FindAsync(id);
            if (cartItem != null)
            {
                var result = _dbContext.CartItems.Remove(cartItem);
                await _dbContext.SaveChangesAsync();
            }
            return cartItem;
        }

        public async Task<IEnumerable<CartItemDto>> GetAllItemsAsync(Guid userId)
        {
            return await (from ci in _dbContext.CartItems
                          join c in _dbContext.Carts
                          on ci.CartId equals c.Id
                          join p in _dbContext.Products
                          on ci.ProductId equals p.Id
                          where c.UserId == userId
                          select new CartItemDto
                          {
                              CardId = ci.CartId,
                              ProductId = ci.ProductId,
                              Quantity = ci.Quantity,
                              ProductName = p.Name,
                              ProductPrice = p.Price,
                              ImageUrl = p.ImageUrl
                          }).ToListAsync();
        }

        public async Task<CartItem> GetItemAsync(int id)
        {
            return await _dbContext.CartItems.FindAsync(id);
        }

        public Task<CartItem> UpdateItemQuantityAsync(int quantity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CartItemDto>> GetItemsInCartAsync(int cardId)
        {
            return await (from ci in _dbContext.CartItems
                          join p in _dbContext.Products
                          on ci.ProductId equals p.Id
                          where ci.CartId == cardId
                          select new CartItemDto
                          {
                              CardId = ci.Id,
                              ProductId = ci.ProductId,
                              ProductName = p.Name,
                              ProductPrice = p.Price,
                              Quantity = ci.Quantity,
                              ImageUrl = p.ImageUrl
                          }).ToListAsync();
        }
    }
}
