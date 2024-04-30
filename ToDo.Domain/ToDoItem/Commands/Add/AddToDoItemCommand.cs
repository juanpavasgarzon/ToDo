using ToDo.Infrastructure.CommandDispatcher.Contracts;

namespace ToDo.Domain.ToDoItem.Commands.Add;

public record AddToDoItemCommand(string Title, string Description) : ICommand
{
    public ToDoItem GetToDoItem() => new(Title, Description);
}

public record AddToDoItemCommandResponse(int Id)
{
    public static AddToDoItemCommandResponse FromId(int id) => new(id);
}