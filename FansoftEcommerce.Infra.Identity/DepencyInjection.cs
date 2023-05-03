using System.Text;
using FansoftEcommerce.Application.Data;
using FansoftEcommerce.Application.Services;
using FansoftEcommerce.Infra.Identity.Configuration;
using FansoftEcommerce.Infra.Identity.Repository;
using FansoftEcommerce.Infra.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace FansoftEcommerce.Infra.Identity;

public static class DepencyInjection
{
    public static IServiceCollection AddIdentityPersistence(
        this IServiceCollection services, 
        IConfiguration configuration) {
        
        services.AddDbContext<IdentityDataContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Identity"))
        );

        services.AddTransient<IUserRepository, UserRepository>();
        services.AddIdentity();
        services.AddAuthenticationSetup(configuration);
        
        return services;
    }

    private static void AddIdentity(this IServiceCollection services)
    {
        services.AddTransient<ITokenService, TokenService>();

        services.AddDefaultIdentity<IdentityUser>
            (options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<IdentityDataContext>()
            .AddDefaultTokenProviders();
    }

    private static void AddAuthenticationSetup(this IServiceCollection services, IConfiguration configuration)
    {

        var jwtAppSettingsSection = configuration.GetSection(nameof(JwtOptions));
        var jwtAppSettings = jwtAppSettingsSection.Get<JwtOptions>();
        
        var securityKey =
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("JwtOptions:SecurityKey").Value!));
        services.Configure<JwtOptions>(options =>
        {
            options.Issuer = jwtAppSettings!.Issuer;
            options.Audience = jwtAppSettings!.Audience;
            options.SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
            options.Expiration = jwtAppSettings!.Expiration;
        });

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtAppSettings!.Issuer,
            
            ValidateAudience = true,
            ValidAudience = jwtAppSettings!.Audience,
            
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = securityKey,
            
            RequireExpirationTime = true,
            ValidateLifetime = true,
            
            ClockSkew = TimeSpan.Zero
        };

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = tokenValidationParameters;
        });
    }
}