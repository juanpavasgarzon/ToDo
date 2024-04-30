using Microsoft.AspNetCore.Routing;

namespace ToDo.Infrastructure.MinimalApi.Contracts;

public interface IEndpoint
{
    void Configure(IEndpointRouteBuilder endpoints);
}