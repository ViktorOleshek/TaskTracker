namespace WebApi;

using WebApi.Extensions;
using Application.Extensions;
using Infrastructure.Extensions;
using Persistence.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Database;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        this.Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddApplication()
            .AddInfrastructure()
            .AddPersistence(Configuration)
            .AddApi()
            .AddCorsPolicy()
            .ConfigureAuthentication(Configuration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task Tracker API v1"));
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseCors("AllowAllOrigins");

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        using var scope = app.ApplicationServices.CreateScope();
        new DatabaseInitializer(
            Configuration.GetConnectionString("SqlConnectionString"),
            scope.ServiceProvider.GetRequiredService<ILogger<DatabaseInitializer>>()
        ).Initialize();
    }
}