using ToDo.Infrastructure.PersistenceContext.Contracts;
using ToDo.Infrastructure.QueryDispatcher.Contracts;

namespace ToDo.Domain.ToDoItem.Queries.GetAll;

public class GetAllToDoItemQueryHandler(IRepository repository) : IQueryHandler<GetAllToDoItemQueryResponse>
{
    public GetAllToDoItemQueryResponse Handle()
    {
        var toDoItems = repository.GetAll<ToDoItem>();
        return GetAllToDoItemQueryResponse.FromToDoItems(toDoItems);
    }
}