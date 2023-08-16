using Microsoft.AspNetCore.Components;
using ShoppingWeb.Models.DTOs;
using ShoppingWeb.Web.Services;

namespace ShoppingWeb.Web.Pages.ShoppingCart
{
    public class ShoppingCartBase : ComponentBase
    {
        [Inject]
        public IShoppingCartService _shoppingCartService { get; set; }
        public IEnumerable<CartItemDto> ShoppingItems { get; set; }
        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var result = await _shoppingCartService.GetCartItems(new Guid("92b237a2-05ab-4b1d-a232-982dce35a821"));
                ShoppingItems = result;
            }
            catch(Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
