using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ShoppingWeb.Models.DTOs;
using ShoppingWeb.Web.Services;

namespace ShoppingWeb.Web.Pages
{
    public class CheckOutBase : ComponentBase
    {
        [Inject]
        private IShoppingCartService _shoppingCartService { get; set; }
        [Inject]
        private IJSRuntime JS { get; set; }
        public List<CartItemDto> ShoppingItems { get; set; }


        protected override async Task OnInitializedAsync()
        {

            try
            {
                var result = await _shoppingCartService.GetCartItems(new Guid("92b237a2-05ab-4b1d-a232-982dce35a821"));
                ShoppingItems = result.ToList();
            }
            catch (Exception ex)
            {
                //ErrorMessage = ex.Message;
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            try
            {
                if (firstRender)
                {
                    await JS.InvokeVoidAsync("renderPaypalButton");

                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
