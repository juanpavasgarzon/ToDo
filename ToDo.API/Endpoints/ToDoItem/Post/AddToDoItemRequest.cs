using ToDo.Application.Commands.Add;

namespace ToDo.API.Endpoints.ToDoItem.Post;

public record AddToDoItemRequest(string Title, string Description)
{
    public AppAddToDoItemCommand GetAppAddToDoCommand() => new(Title, Description);
}

public record AddToDoItemRequestResult(int Id)
{
    public static AddToDoItemRequestResult FromId(int id) => new(id);
}