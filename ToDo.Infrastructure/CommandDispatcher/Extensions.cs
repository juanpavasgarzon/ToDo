using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using ToDo.Infrastructure.CommandDispatcher.Contracts;

namespace ToDo.Infrastructure.CommandDispatcher;

public static class Extensions
{
    public static void AddCommands(this IServiceCollection services)
    {
        services.AddScoped<ICommandDispatcher, CommandDispatcher>();

        services.Scan(scan => scan.FromApplicationDependencies()
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<,>)))
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );
    }
}