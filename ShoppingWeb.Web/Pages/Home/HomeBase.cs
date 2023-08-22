using Microsoft.AspNetCore.Components;
using ShoppingWeb.Models.DTOs;
using ShoppingWeb.Web.Services;

namespace ShoppingWeb.Web.Pages.Home
{
    public class HomeBase : ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }
        [Inject]
        public IShoppingCartService _shoppingCartService { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Products = await ProductService.GetProducts();
            var result = await _shoppingCartService.GetCartItems(new Guid("92b237a2-05ab-4b1d-a232-982dce35a821"));
            var ShoppingItems = result.ToList();
            var totalQuantity = ShoppingItems.Sum(x => x.Quantity);
            _shoppingCartService.RaiseEventOnShoppingCartChanged(totalQuantity);
        }
    }
}
