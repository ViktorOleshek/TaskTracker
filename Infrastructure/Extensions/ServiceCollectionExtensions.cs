using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
                   cfg.RegisterServicesFromAssemblies(
                       Assembly.GetExecutingAssembly()
                   ));

        return services;
    }
}