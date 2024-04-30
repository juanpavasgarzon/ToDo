using ToDo.Infrastructure.CommandDispatcher.Contracts;

namespace ToDo.Application.Commands.MarkAsCompleted;

public class AppMarkAsCompletedCommandHandler(
    ICommandDispatcher dispatcher
) : ICommandHandler<AppMarkAsCompletedCommand>
{
    public void Handle(AppMarkAsCompletedCommand command)
    {
        dispatcher.Exec(command.GetMarkAsCompletedCommand());
    }
}