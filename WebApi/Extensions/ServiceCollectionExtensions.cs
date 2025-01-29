using Database;
using Microsoft.OpenApi.Models;

namespace WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services
                .AddEndpointsApiExplorer()
                .AddSwaggerGen(c =>
                    {
                        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Task Tracker API", Version = "v1" });
                    })
                .AddControllers()
                ;

            return services;
        }
    }
}
