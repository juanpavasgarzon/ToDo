using ToDo.Domain.ToDoItem.Commands.Add;
using ToDo.Infrastructure.CommandDispatcher.Contracts;

namespace ToDo.Application.Commands.Add;

public class AppAddToDoItemCommandHandler(
    ICommandDispatcher dispatcher
) : ICommandHandler<AppAddToDoItemCommand, AppAddToDoItemCommandResponse>
{
    public AppAddToDoItemCommandResponse Handle(AppAddToDoItemCommand command)
    {
        var result = dispatcher.Exec<AddToDoItemCommand, AddToDoItemCommandResponse>(
            command.GetAddToDoCommand()
        );

        return AppAddToDoItemCommandResponse.FromId(result.Id);
    }
}