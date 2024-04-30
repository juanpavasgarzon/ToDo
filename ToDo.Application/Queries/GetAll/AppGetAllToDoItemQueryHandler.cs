using ToDo.Domain.ToDoItem.Queries.GetAll;
using ToDo.Infrastructure.QueryDispatcher.Contracts;

namespace ToDo.Application.Queries.GetAll;

public class AppGetAllToDoItemQueryHandler(IQueryDispatcher dispatcher) : IQueryHandler<AppGetAllToDoItemQueryResponse>
{
    public AppGetAllToDoItemQueryResponse Handle()
    {
        var result = dispatcher.Query<GetAllToDoItemQueryResponse>();
        return AppGetAllToDoItemQueryResponse.FromToDoItems(result.ToDoItems);
    }
}