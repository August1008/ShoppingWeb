using Microsoft.AspNetCore.Components;
using ShoppingWeb.Models.DTOs;
using ShoppingWeb.Web.Services;

namespace ShoppingWeb.Web.Pages.ProductDetails
{
    public class ProductDetailBase : ComponentBase
    {
        [Parameter]
        public int productId { get; set; }
        [Inject]
        public IProductService _productService { get; set; }
        public ProductDto Product { get; set; }
        public string Error { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Product = await _productService.GetProduct(productId);

            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }
    }
}
