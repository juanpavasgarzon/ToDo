using ToDo.Domain.ToDoItem;

namespace ToDo.Application.Queries.GetAll;

public record AppGetAllToDoItemQueryResponse(List<ToDoItem> ToDoItems)
{
    public static AppGetAllToDoItemQueryResponse FromToDoItems(List<ToDoItem> toDoItems) => new(toDoItems);
}