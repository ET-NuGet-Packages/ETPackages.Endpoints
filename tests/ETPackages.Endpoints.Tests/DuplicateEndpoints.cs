using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace ETPackages.Endpoints.Tests;

public class DuplicateEndpoint1 : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder builder)
    {
        builder.MapGet("/dup", () => "First");
    }
}

public class DuplicateEndpoint2 : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder builder)
    {
        builder.MapGet("/dup", () => "Second");
    }
}
