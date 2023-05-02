using FansoftEcommerce.Application.Data;
using FansoftEcommerce.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace FansoftEcommerce.Infra.Persistence.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _ctx;
    public ProductRepository(ApplicationDbContext ctx) => _ctx = ctx;
    public async Task<IEnumerable<Product>> GetAsync()
    {
        return await _ctx.Products.ToListAsync();
    }

    public async Task<Product?> GetAsync(int id)
    {
        return await _ctx.Products.FirstOrDefaultAsync(x=>x.Id == new ProductId(id));
    }

    public async Task AddAsync(Product product)
    {
        await _ctx.Products.AddAsync(product);
        await _ctx.SaveChangesAsync();
    }
}