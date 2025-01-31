using Application.Abstraction.IServices;
using Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services
            .AddScoped<IJwtProvider, JwtProvider>();
    }
}