namespace ToDo.Domain.ToDoItem.Queries.GetAll;

public record GetAllToDoItemQueryResponse(List<ToDoItem> ToDoItems)
{
    public static GetAllToDoItemQueryResponse FromToDoItems(List<ToDoItem> toDoItems) => new(toDoItems);
}