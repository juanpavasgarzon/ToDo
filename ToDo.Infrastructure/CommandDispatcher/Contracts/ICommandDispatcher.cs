namespace ToDo.Infrastructure.CommandDispatcher.Contracts;

public interface ICommandDispatcher
{
    void Exec<TCommand>(TCommand command) where TCommand : class, ICommand;

    TResult Exec<TCommand, TResult>(TCommand command) where TCommand : class, ICommand where TResult : class;
}