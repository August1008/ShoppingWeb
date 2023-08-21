using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingWeb.Api.Repositories.Interfaces;
using ShoppingWeb.Models.DTOs;

namespace ShoppingWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartRepository shoppingCartRepository;

        public ShoppingCartController(IShoppingCartRepository _shoppingCartRepository)
        {
            shoppingCartRepository = _shoppingCartRepository;
        }

        [HttpGet("{userId}/get-items")]
        public async Task<IActionResult> GetItems(Guid userId)
        {
            try
            {
                var result = await shoppingCartRepository.GetAllItemsAsync(userId);
                return result is not null ? Ok(result) : NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("add-item-to-cart")]
        public async Task<IActionResult> AddItemToCart([FromBody] CartItemToAddDto item)
        {
            try
            {
                var result = await shoppingCartRepository.AddItemAsync(item);
                if (result == null)
                {
                    return NoContent();
                }
                return Ok(new { status = StatusCodes.Status200OK, data = result });
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
        [HttpPost("delete-item")]
        public async Task<IActionResult> DeleteItem([FromBody]int id)
        {
            try
            {
                var result = await shoppingCartRepository.DeleteItem(id);
                if (result == null)
                {
                    return NoContent();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
