using FansoftEcommerce.Domain.Products;

// ReSharper disable once IdentifierTypo
namespace FansoftEcommerce.Application.Data;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAsync();
    Task<Product?> GetAsync(int id);

    Task AddAsync(Product product);
}