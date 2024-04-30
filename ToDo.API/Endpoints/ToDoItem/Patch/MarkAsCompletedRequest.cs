using ToDo.Application.Commands.MarkAsCompleted;

namespace ToDo.API.Endpoints.ToDoItem.Patch;

public record MarkAsCompletedRequest(string CompletedNote)
{
    public AppMarkAsCompletedCommand GetAppMarkAsCompletedCommand(int id) => new(id, CompletedNote);
}