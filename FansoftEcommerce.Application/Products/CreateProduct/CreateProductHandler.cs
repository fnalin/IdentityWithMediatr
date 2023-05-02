using FansoftEcommerce.Application.Data;
using FansoftEcommerce.Domain.Products;
using MediatR;

namespace FansoftEcommerce.Application.Products.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResponse>
{
    private readonly IProductRepository _productRepository;

    public CreateProductHandler(IProductRepository productRepository) => _productRepository = productRepository;

    public  async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var newProduct = Product.Create(
            request.Name,
            new Money("R$", request.Price),
             Sku.Create(request.Sku)!,
            new CategoryId(request.CategoryId)
        );

        await _productRepository.AddAsync(newProduct);

        return new ProductResponse(newProduct.Id.Value, newProduct.Name, newProduct.Price.Amount, newProduct.Sku!.Value);
    }
}