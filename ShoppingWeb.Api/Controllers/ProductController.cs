using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingWeb.Api.Repositories;

namespace ShoppingWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository) {
            _productRepository = productRepository;
        }
        [HttpGet("get-items")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _productRepository.GetProductDtos();
                return products != null ? Ok(products) : NotFound();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{productId:int}")]
        public async Task<IActionResult> GetProduct(int productId)
        {
            try
            {
                var product = await _productRepository.GetProductById(productId);
                return product != null ? Ok(product) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
