using Microsoft.AspNetCore.Components;
using ShoppingWeb.Models.DTOs;
using ShoppingWeb.Web.Pages.Notifications;
using ShoppingWeb.Web.Pages.Utilities;
using ShoppingWeb.Web.Services;

namespace ShoppingWeb.Web.Pages.ShoppingCart
{
    public class ShoppingCartBase : ComponentBase
    {
        [Inject]
        public IShoppingCartService _shoppingCartService { get; set; }
        public List<CartItemDto> ShoppingItems { get; set; }
        public string ErrorMessage { get; set; }

        #region notify when delete
        public bool IsVisible { get; set; }
        public string Message { get; set; }
        public DeleteNotification deleteNotification { get; set; }
        #endregion

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var result = await _shoppingCartService.GetCartItems(new Guid("92b237a2-05ab-4b1d-a232-982dce35a821"));
                ShoppingItems = result.ToList();
            }
            catch(Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        //protected override void OnAfterRender(bool firstRender)
        //{
        //    if(!firstRender)
        //    {
        //        Task.Delay(5000);
        //    }
        //}

        protected async void DeleteItem(int id)
        {

            try
            {
                var result = await _shoppingCartService.DeleteItem(id);
                if (result == null)
                    deleteNotification.ShowFailureDeleteNotification();
                else
                {
                    ShoppingItems.RemoveAll(i => i.Id == result.Id);
                    StateHasChanged();
                    deleteNotification.ShowSuccessDeleteNotification();
                }   
            }
            catch (Exception ex)
            {
                deleteNotification.ShowFailureDeleteNotification();

            }
            
        }


        
    }
}
