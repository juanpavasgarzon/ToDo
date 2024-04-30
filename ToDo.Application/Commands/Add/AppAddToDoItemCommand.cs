using ToDo.Domain.ToDoItem.Commands.Add;
using ToDo.Infrastructure.CommandDispatcher.Contracts;

namespace ToDo.Application.Commands.Add;

public record AppAddToDoItemCommand(string Title, string Description) : ICommand
{
    public AddToDoItemCommand GetAddToDoCommand() => new(Title, Description);
}

public record AppAddToDoItemCommandResponse(int Id)
{
    public static AppAddToDoItemCommandResponse FromId(int id) => new(id);
}