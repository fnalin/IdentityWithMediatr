using FansoftEcommerce.Application.Data;
using FansoftEcommerce.Infra.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FansoftEcommerce.Infra.Persistence;

public static class DepencyInjection
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services, 
        IConfiguration configuration) {
        
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Database"))
        );

        services.AddTransient<IProductRepository, ProductRepository>();
        return services;
    } 
}