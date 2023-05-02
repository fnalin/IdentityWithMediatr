namespace FansoftEcommerce.Domain.Products;

public class Category {
    public CategoryId Id { get; private set; } = null!;
    public string Name { get; private set; } = string.Empty;
}