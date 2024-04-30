using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using ToDo.Infrastructure.QueryDispatcher.Contracts;

namespace ToDo.Infrastructure.QueryDispatcher;

public static class Extensions
{
    public static void AddQueries(this IServiceCollection services)
    {
        services.AddScoped<IQueryDispatcher, QueryDispatcher>();

        services.Scan(scan => scan.FromApplicationDependencies()
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<>)))
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );
    }
}