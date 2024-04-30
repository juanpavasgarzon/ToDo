using Microsoft.AspNetCore.Http.HttpResults;
using ToDo.Infrastructure.MinimalApi.Contracts;
using ToDo.API.Enums;
using ToDo.Application.Queries.GetById;
using ToDo.Infrastructure.QueryDispatcher.Contracts;

namespace ToDo.API.Endpoints.ToDoItem.Get;

public class GetToDoItemByIdRequestHandler : IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/todo-item/by-id/{id:int}", Handle)
            .WithTags(TagConstant.TodoItem)
            .WithOpenApi();
    }

    private static Results<Ok<GetToDoItemRequestResponse>, Conflict<object>> Handle(
        ILogger<GetToDoItemByIdRequestHandler> logger,
        IQueryDispatcher dispatcher,
        int id
    )
    {
        try
        {
            var result = dispatcher.Query<AppGetToDoItemByIdQuery, AppGetToDoItemByIdQueryResponse>(
                GetToDoItemByIdRequest.AppGetToDoItemByIdQuery(id)
            );
            return TypedResults.Ok(GetToDoItemRequestResponse.FromToDoItem(result.ToDoItem));
        }
        catch (Exception e)
        {
            logger.LogError(e.Message);
            return TypedResults.Conflict<object>(new { e.Message });
        }
    }
}