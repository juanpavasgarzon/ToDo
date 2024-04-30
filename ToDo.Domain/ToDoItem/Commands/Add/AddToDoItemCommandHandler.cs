using ToDo.Infrastructure.CommandDispatcher.Contracts;
using ToDo.Infrastructure.PersistenceContext.Contracts;

namespace ToDo.Domain.ToDoItem.Commands.Add;

public class AddToDoItemCommandHandler(
    IRepository repository
) : ICommandHandler<AddToDoItemCommand, AddToDoItemCommandResponse>
{
    public AddToDoItemCommandResponse Handle(AddToDoItemCommand command)
    {
        var toDoItem = repository.Add(command.GetToDoItem());
        return AddToDoItemCommandResponse.FromId(toDoItem.Id);
    }
}