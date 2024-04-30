namespace ToDo.API.Endpoints.ToDoItem.Get;

public record GetAllToDoItemRequestResponse(List<Domain.ToDoItem.ToDoItem> ToDoItems)
{
    public static GetAllToDoItemRequestResponse FromToDoItems(List<Domain.ToDoItem.ToDoItem> toDoItems) => new(toDoItems);
};