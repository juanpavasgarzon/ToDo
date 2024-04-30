namespace ToDo.Infrastructure.CommandDispatcher.Contracts;

public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
{
    void Handle(TCommand command);
}

public interface ICommandHandler<in TCommand, out TResult> where TCommand : class, ICommand
{
    TResult Handle(TCommand command);
}