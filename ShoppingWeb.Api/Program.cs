using Microsoft.EntityFrameworkCore;
using ShoppingWeb.Api.DataContext;
using ShoppingWeb.Api.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultPolicy", builder => builder.WithOrigins("*").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<ShoppingWebDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionConnection"))
);

builder.Services.AddScoped<IProductRepository, ProductRepository>();
var app = builder.Build();

app.UseCors("DefaultPolicy");
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
