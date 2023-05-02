using FansoftEcommerce.Application.Data;
using MediatR;

namespace FansoftEcommerce.Application.Products.GetProducts;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductResponse>>
{
    private readonly IProductRepository _productRepository;

    public GetProductsQueryHandler(IProductRepository productRepository) => _productRepository = productRepository;

    public async Task<IEnumerable<ProductResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var data = await _productRepository.GetAsync();
        return data.Select(p => 
            new ProductResponse(
                p.Id.Value, 
                p.Name,
                p.Price.Amount,
                p.Sku!.Value
                ));
    }
}