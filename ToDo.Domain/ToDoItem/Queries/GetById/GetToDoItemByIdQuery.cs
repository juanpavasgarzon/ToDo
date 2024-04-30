using ToDo.Infrastructure.QueryDispatcher.Contracts;

namespace ToDo.Domain.ToDoItem.Queries.GetById;

public record GetToDoItemByIdQuery(int Id) : IQuery;

public record GetByIdToDoItemQueryResponse(ToDoItem ToDoItem)
{
    public static GetByIdToDoItemQueryResponse FromToDoItem(ToDoItem toDoItem) => new(toDoItem);
}