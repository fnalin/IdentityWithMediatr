using MediatR;

namespace FansoftEcommerce.Application.Products.GetProductById;

public record GetProductByIdQuery(int Id) : IRequest<ProductResponse>;
