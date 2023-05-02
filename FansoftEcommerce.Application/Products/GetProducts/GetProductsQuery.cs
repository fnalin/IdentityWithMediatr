using MediatR;

namespace FansoftEcommerce.Application.Products.GetProducts;

public record GetProductsQuery : IRequest<IEnumerable<ProductResponse>>;