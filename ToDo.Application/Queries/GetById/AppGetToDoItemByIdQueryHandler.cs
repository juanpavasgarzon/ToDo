using ToDo.Domain.ToDoItem.Queries.GetById;
using ToDo.Infrastructure.QueryDispatcher.Contracts;

namespace ToDo.Application.Queries.GetById;

public class AppGetToDoItemByIdQueryHandler(
    IQueryDispatcher dispatcher
) : IQueryHandler<AppGetToDoItemByIdQuery, AppGetToDoItemByIdQueryResponse>
{
    public AppGetToDoItemByIdQueryResponse Handle(AppGetToDoItemByIdQuery query)
    {
        var result = dispatcher.Query<GetToDoItemByIdQuery, GetByIdToDoItemQueryResponse>(
            query.FromGetByIdToDoItemQuery()
        );
        return AppGetToDoItemByIdQueryResponse.FromToDoItem(result.ToDoItem);
    }
}