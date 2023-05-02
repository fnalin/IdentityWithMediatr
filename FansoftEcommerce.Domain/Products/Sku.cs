namespace FansoftEcommerce.Domain.Products;

public record Sku {

    private const int defaultLength = 15;
    private Sku(string value)=> Value = value;
    public string Value { get; init; }

    public static Sku? Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return null;
        }

        if (value.Length != defaultLength)
        {
            return null;
        }

        return new Sku(value);
    }

}