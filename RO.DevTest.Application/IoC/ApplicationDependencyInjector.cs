using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace RO.DevTest.Application.IoC;

public static class ApplicationDependencyInjector
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}