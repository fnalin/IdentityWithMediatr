using FansoftEcommerce.Domain.Products;
using FansoftEcommerce.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FansoftEcommerce.Api.Extensions;


public static class MigrationExtensions
{
    public static void ApplyMigrations(this WebApplication app) {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate();

        // if (!dbContext.Products.Any()) {
        //     var products = new Product[] {
        //         //Product.Create(),
        //        
        //     };
        //     dbContext.Products.AddRange(products);
        //     dbContext.SaveChanges();
        // }
    }
}