using FansoftEcommerce.Application.Data;
using MediatR;

namespace FansoftEcommerce.Application.Products.GetProductById;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductResponse?>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdHandler(IProductRepository productRepository) => _productRepository = productRepository;

    public async Task<ProductResponse?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _productRepository.GetAsync(request.Id);

        if (data is null)
            return null;
        
        return new ProductResponse(data.Id.Value, data.Name, data.Price.Amount, data.Sku!.Value);
    }
}