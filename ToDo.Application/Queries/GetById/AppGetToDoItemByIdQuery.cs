using ToDo.Domain.ToDoItem;
using ToDo.Domain.ToDoItem.Queries.GetById;
using ToDo.Infrastructure.QueryDispatcher.Contracts;

namespace ToDo.Application.Queries.GetById;

public record AppGetToDoItemByIdQuery(int Id) : IQuery
{
    public GetToDoItemByIdQuery FromGetByIdToDoItemQuery() => new(Id);
}

public record AppGetToDoItemByIdQueryResponse(ToDoItem ToDoItem)
{
    public static AppGetToDoItemByIdQueryResponse FromToDoItem(ToDoItem toDoItem) => new(toDoItem);
}