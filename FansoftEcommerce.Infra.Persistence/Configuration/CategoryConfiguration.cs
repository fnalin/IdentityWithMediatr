using FansoftEcommerce.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FansoftEcommerce.Infra.Persistence.Configuration;

internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.Property(c => c.Id).HasConversion(
            categoryId => categoryId.Value, value => new CategoryId(value)
        );

        builder.Property(c => c.Name).HasMaxLength(100);
    }
}