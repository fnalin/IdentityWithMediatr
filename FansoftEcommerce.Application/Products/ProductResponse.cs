using FansoftEcommerce.Application.Common;

namespace FansoftEcommerce.Application.Products;

public record ProductResponse(int Id, string Name, decimal Price, string Sku) : IResponse;