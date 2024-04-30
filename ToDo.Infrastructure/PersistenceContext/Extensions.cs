using Microsoft.Extensions.DependencyInjection;
using ToDo.Infrastructure.PersistenceContext.Contracts;

namespace ToDo.Infrastructure.PersistenceContext;

public static class Extensions
{
    public static void AddRepository(this IServiceCollection services)
    {
        services.AddSingleton<IRepository, Repository>();
    }
}