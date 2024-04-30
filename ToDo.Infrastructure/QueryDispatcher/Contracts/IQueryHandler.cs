namespace ToDo.Infrastructure.QueryDispatcher.Contracts;

public interface IQueryHandler<out TResult> where TResult : class
{
    TResult Handle();
}

public interface IQueryHandler<in TCommand, out TResult> where TCommand : class, IQuery
{
    TResult Handle(TCommand query);
}