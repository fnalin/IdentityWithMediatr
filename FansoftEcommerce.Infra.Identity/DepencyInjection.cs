using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FansoftEcommerce.Infra.Identity;

public static class DepencyInjection
{
    public static IServiceCollection AddIdentity(
        this IServiceCollection services, 
        IConfiguration configuration) {
        
        services.AddDbContext<IdentityDataContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Identity"))
        );
        
        return services;
    } 
}