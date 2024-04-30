using ToDo.API.Enums;
using ToDo.Infrastructure.MinimalApi.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;
using ToDo.Infrastructure.CommandDispatcher.Contracts;

namespace ToDo.API.Endpoints.ToDoItem.Patch;

public class MarkAsCompletedRequestHandler : IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPatch("/todo-item/by-id/{id:int}", Handle)
            .WithTags(TagConstant.TodoItem)
            .WithOpenApi();
    }

    private static Results<Ok<bool>, Conflict<object>> Handle(
        ILogger<MarkAsCompletedRequestHandler> logger,
        ICommandDispatcher dispatcher,
        MarkAsCompletedRequest request,
        int id
    )
    {
        try
        {
            dispatcher.Exec(request.GetAppMarkAsCompletedCommand(id));
            return TypedResults.Ok(true);
        }
        catch (Exception e)
        {
            logger.LogError(e.Message);
            return TypedResults.Conflict<object>(new { e.Message });
        }
    }
}