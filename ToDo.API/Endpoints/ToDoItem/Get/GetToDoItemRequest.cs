using ToDo.Application.Queries.GetById;

namespace ToDo.API.Endpoints.ToDoItem.Get;

public record GetToDoItemByIdRequest
{
    public static AppGetToDoItemByIdQuery AppGetToDoItemByIdQuery(int id) => new(id);
}

public record GetToDoItemRequestResponse(Domain.ToDoItem.ToDoItem ToDoItem)
{
    public static GetToDoItemRequestResponse FromToDoItem(
        Domain.ToDoItem.ToDoItem toDoItem
    ) => new(toDoItem);
}