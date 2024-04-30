using Microsoft.AspNetCore.Http.HttpResults;
using ToDo.Infrastructure.MinimalApi.Contracts;
using ToDo.API.Enums;
using ToDo.Application.Queries.GetAll;
using ToDo.Infrastructure.QueryDispatcher.Contracts;

namespace ToDo.API.Endpoints.ToDoItem.Get;

public class GetAllToDoItemRequestHandler : IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/todo-item", Handle)
            .WithTags(TagConstant.TodoItem)
            .WithOpenApi();
    }

    private static Results<Ok<GetAllToDoItemRequestResponse>, Conflict<object>> Handle(
        ILogger<GetToDoItemByIdRequestHandler> logger,
        IQueryDispatcher dispatcher
    )
    {
        try
        {
            var result = dispatcher.Query<AppGetAllToDoItemQueryResponse>();
            return TypedResults.Ok(GetAllToDoItemRequestResponse.FromToDoItems(result.ToDoItems));
        }
        catch (Exception e)
        {
            logger.LogError(e.Message);
            return TypedResults.Conflict<object>(new { e.Message });
        }
    }
}