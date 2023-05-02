using FansoftEcommerce.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace FansoftEcommerce.Infra.Persistence;

public class ApplicationDbContext : DbContext
{
    // dotnet ef migrations add NAME -v -s ../FansoftEcommerce.Api

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
    
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}