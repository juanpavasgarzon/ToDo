using ToDo.Domain.ToDoItem.Commands.MarkAsCompleted;
using ToDo.Infrastructure.CommandDispatcher.Contracts;

namespace ToDo.Application.Commands.MarkAsCompleted;

public record AppMarkAsCompletedCommand(int Id, string CompletedNote) : ICommand
{
    public MarkAsCompletedCommand GetMarkAsCompletedCommand() => new(Id, CompletedNote);
};