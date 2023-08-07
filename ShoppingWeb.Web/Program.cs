using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ShoppingWeb.Web;
using ShoppingWeb.Web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://august-shoppingweb.azurewebsites.net") });
builder.Services.AddScoped<IProductService, ProductService>();
await builder.Build().RunAsync();
