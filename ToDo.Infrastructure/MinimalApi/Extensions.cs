using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Infrastructure.MinimalApi.Contracts;

namespace ToDo.Infrastructure.MinimalApi;

public static class Extensions
{
    public static void AddEndpoints(this IServiceCollection services)
    {
        var endpoints = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(t => t.GetInterfaces().Contains(typeof(IEndpoint)))
            .Where(t => !t.IsInterface);

        foreach (var implementationType in endpoints)
        {
            services.AddScoped(typeof(IEndpoint), implementationType);
        }
    }

    public static void MapEndpoints(this WebApplication builder)
    {
        foreach (var service in builder.Services.CreateScope().ServiceProvider.GetServices<IEndpoint>())
        {
            service.Configure(builder);
        }
    }
}