using System.Reflection;
using FansoftEcommerce.Application.Common;
using FansoftEcommerce.Application.Services;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FansoftEcommerce.Application;

public static class DepencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();
        });
        services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyReference>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }
}