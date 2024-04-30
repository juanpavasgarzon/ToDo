namespace ToDo.Infrastructure.QueryDispatcher.Contracts;

public interface IQueryDispatcher
{
    public TResult Query<TResult>() where TResult : class;

    public TResult Query<TQuery, TResult>(TQuery query) where TQuery : class, IQuery where TResult : class;
}