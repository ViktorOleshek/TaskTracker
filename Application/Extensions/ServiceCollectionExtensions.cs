using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services.AddMediatR(cfg =>
                   cfg.RegisterServicesFromAssemblies(
                       Assembly.GetExecutingAssembly()
                   ));
    }
}