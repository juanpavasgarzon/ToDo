using Microsoft.Extensions.DependencyInjection;
using ToDo.Infrastructure.QueryDispatcher.Contracts;

namespace ToDo.Infrastructure.QueryDispatcher;

public class QueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public QueryDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public TResult Query<TResult>() where TResult : class
    {
        var service = _serviceProvider.GetService<IQueryHandler<TResult>>();
        if (service is null)
        {
            throw new Exception($"No Handler Found For {typeof(IQueryHandler<TResult>).FullName}");
        }

        return service.Handle();
    }

    public TResult Query<TQuery, TResult>(TQuery query) where TQuery : class, IQuery where TResult : class
    {
        var service = _serviceProvider.GetService<IQueryHandler<TQuery, TResult>>();
        if (service is null)
        {
            throw new Exception($"No Handler Found For {typeof(IQueryHandler<TQuery, TResult>).FullName}");
        }

        return service.Handle(query);
    }
}