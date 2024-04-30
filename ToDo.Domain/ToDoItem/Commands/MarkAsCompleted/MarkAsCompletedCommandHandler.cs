using ToDo.Infrastructure.CommandDispatcher.Contracts;
using ToDo.Infrastructure.PersistenceContext.Contracts;

namespace ToDo.Domain.ToDoItem.Commands.MarkAsCompleted;

public class MarkAsCompletedCommandHandler(IRepository repository) : ICommandHandler<MarkAsCompletedCommand>
{
    public void Handle(MarkAsCompletedCommand command)
    {
        var toDoItem = repository.GetById<ToDoItem>(command.Id);
        if (toDoItem is null)
        {
            throw new Exception($"ToDo Item With ID: {command.Id} Is Not Found");
        }

        if (toDoItem.IsCompleted)
        {
            throw new Exception($"ToDo Item With ID: {command.Id} Is Already Marked As Completed");
        }

        toDoItem.MarkAsCompleted(command.CompletedNote);
        repository.Update(toDoItem);
    }
}