using ToDo.Infrastructure.CommandDispatcher.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace ToDo.Infrastructure.CommandDispatcher;

public class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public CommandDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void Exec<TCommand>(TCommand command) where TCommand : class, ICommand
    {
        var service = _serviceProvider.GetService<ICommandHandler<TCommand>>();
        if (service is null)
        {
            throw new Exception($"No Handler Found For {typeof(ICommandHandler<TCommand>).FullName}");
        }

        service.Handle(command);
    }

    public TResult Exec<TCommand, TResult>(TCommand command) where TCommand : class, ICommand where TResult : class
    {
        var service = _serviceProvider.GetService<ICommandHandler<TCommand, TResult>>();
        if (service is null)
        {
            throw new Exception($"No Handler Found For {typeof(ICommandHandler<TCommand>).FullName}");
        }

        return service.Handle(command);
    }
}