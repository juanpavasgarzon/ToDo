using ToDo.Infrastructure.CommandDispatcher.Contracts;

namespace ToDo.Domain.ToDoItem.Commands.MarkAsCompleted;

public record MarkAsCompletedCommand(int Id, string CompletedNote) : ICommand;