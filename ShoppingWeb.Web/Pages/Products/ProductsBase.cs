using Microsoft.AspNetCore.Components;
using ShoppingWeb.Models.DTOs;
using ShoppingWeb.Web.Services;

namespace ShoppingWeb.Web.Pages.Products
{
    public class ProductsBase : ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Products = await ProductService.GetProducts();

        }
    }
}
