using System.Net.NetworkInformation;

namespace ShoppingWeb.Web.Pages.Utilities
{
    public static class NotificationMessage
    {
        public static string SuccessDeleteItemMessage { get; } = "Delete item successfully!";
        public static string FailureDeleteItemMessage { get; } = "Delete item fail!";
    }
}
