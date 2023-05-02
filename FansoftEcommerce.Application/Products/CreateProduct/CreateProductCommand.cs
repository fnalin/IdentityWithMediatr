using MediatR;

namespace FansoftEcommerce.Application.Products.CreateProduct;

public record CreateProductCommand(string Name, decimal Price, string Sku, int CategoryId) : IRequest<ProductResponse>;