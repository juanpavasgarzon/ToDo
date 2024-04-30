using Microsoft.AspNetCore.Http.HttpResults;
using ToDo.Application.Commands.Add;
using ToDo.Infrastructure.CommandDispatcher.Contracts;
using ToDo.Infrastructure.MinimalApi.Contracts;
using ToDo.API.Enums;

namespace ToDo.API.Endpoints.ToDoItem.Post;

public class AddToDoItemRequestHandler : IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/todo-item", Handle)
            .WithTags(TagConstant.TodoItem)
            .WithOpenApi();
    }

    private static Results<Created<AddToDoItemRequestResponse>, Conflict<object>> Handle(
        ILogger<AddToDoItemRequestHandler> logger,
        ICommandDispatcher dispatcher,
        AddToDoItemRequest request
    )
    {
        try
        {
            var result = dispatcher.Exec<AppAddToDoItemCommand, AppAddToDoItemCommandResponse>(
                request.GetAppAddToDoCommand()
            );
            return TypedResults.Created($"/todo-item/{result.Id}", AddToDoItemRequestResponse.FromId(result.Id));
        }
        catch (Exception e)
        {
            logger.LogError(e.Message);
            return TypedResults.Conflict<object>(new { e.Message });
        }
    }
}