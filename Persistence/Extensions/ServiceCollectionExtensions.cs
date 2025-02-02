using Domain.Abstraction;
using Domain.Abstraction.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>()
            .AddScoped(typeof(IProjectRepository), typeof(ProjectRepository))
            .AddScoped(typeof(ITaskRepository), typeof(TaskRepository))
            .AddScoped(typeof(IUserRepository), typeof(UserRepository))
            ;

        return services;
    }
}