using ToDo.Infrastructure.PersistenceContext.Contracts;
using ToDo.Infrastructure.QueryDispatcher.Contracts;

namespace ToDo.Domain.ToDoItem.Queries.GetById;

public class GetByIdToDoItemQueryHandler(
    IRepository repository
) : IQueryHandler<GetToDoItemByIdQuery, GetByIdToDoItemQueryResponse>
{
    public GetByIdToDoItemQueryResponse Handle(GetToDoItemByIdQuery query)
    {
        var toDoItem = repository.GetById<ToDoItem>(query.Id);
        if (toDoItem is null)
        {
            throw new Exception($"ToDo Item With ID: {query.Id} Is Not Found");
        }

        return GetByIdToDoItemQueryResponse.FromToDoItem(toDoItem);
    }
}