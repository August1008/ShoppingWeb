using Microsoft.EntityFrameworkCore;
using ShoppingWeb.Api.DataContext;
using ShoppingWeb.Api.Entities;
using ShoppingWeb.Models.DTOs;

namespace ShoppingWeb.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShoppingWebDataContext _dbContext;
        public ProductRepository(ShoppingWebDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ProductDto?> GetProductById(int id)
        {
            var product = await _dbContext.Products.Include(p => p.Category)
                .Where(p => p.Id == id)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Category = p.Category.Name,
                    CategoryId = p.CategoryId,
                    Price = p.Price,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    IsDeleted = p.IsDeleted,
                    Name = p.Name,
                    Quantity = p.Quantity

                })
                .FirstOrDefaultAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _dbContext.Products.ToListAsync();
            return products;
        }

        public async Task<IEnumerable<ProductDto>> GetProductDtos()
        {
            var products = await (from product in _dbContext.Products
                                  join category in _dbContext.Categories
                                  on product.CategoryId equals category.Id
                                  select new ProductDto
                                  {
                                      Id = product.Id,
                                      Name = product.Name,
                                      Description = product.Description,
                                      IsDeleted = product.IsDeleted,
                                      //Category = category.IsActive ? category.Name : String.Empty,
                                      Category = category.Name,
                                      CategoryId = product.CategoryId,
                                      ImageUrl = product.ImageUrl,
                                      Quantity = product.Quantity,
                                      Price = product.Price
                                  }).ToListAsync();
            return products;
        }
    }
}
