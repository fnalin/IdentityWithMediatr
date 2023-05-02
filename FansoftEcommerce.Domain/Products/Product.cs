namespace FansoftEcommerce.Domain.Products;

public class Product
{

    public static Product Create(string name, Money price, Sku sku, CategoryId categoryId)
    {
        return new Product
        {
            Name = name,
            Price = price,
            Sku = sku,
            CategoryId = categoryId
        };

    }

    public ProductId Id { get; private set; } = null!;
    public string Name { get; private set; } = string.Empty;
    public Money Price { get; private set; } = null!;
    public Sku? Sku { get; private set; }

    public CategoryId CategoryId { get; private set; } = null!;
}