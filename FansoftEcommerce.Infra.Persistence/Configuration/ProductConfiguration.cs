using FansoftEcommerce.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FansoftEcommerce.Infra.Persistence.Configuration;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.Property(c => c.Id).HasConversion(
            productId => productId.Value, value => new ProductId(value)
        );
        builder.Property(c => c.Name).HasMaxLength(100);
                builder.OwnsOne(
            li => li.Price,
            priceBuilder =>
                {
                    priceBuilder.Property(m => m.Currency).HasMaxLength(3);
                    priceBuilder.Property(p => p.Amount).HasColumnType("money");
                });
        
        builder.Property(c => c.Sku).HasConversion(
            sku => sku!.Value, value => Sku.Create(value)
        );

        builder.HasOne<Category>()
            .WithMany()
            .HasForeignKey(fk => fk.CategoryId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}