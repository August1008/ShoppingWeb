using Microsoft.AspNetCore.Components;
using ShoppingWeb.Models.DTOs;

namespace ShoppingWeb.Web.Pages.Products
{
    public class ProductsBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<ProductDto> Products { get; set; }

    }
}
