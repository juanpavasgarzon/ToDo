using ToDo.Application.Commands.Add;

namespace ToDo.API.Endpoints.ToDoItem.Post;

public record AddToDoItemRequest(string Title, string Description)
{
    public AppAddToDoItemCommand GetAppAddToDoCommand() => new(Title, Description);
}

public record AddToDoItemRequestResponse(int Id)
{
    public static AddToDoItemRequestResponse FromId(int id) => new(id);
}