using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace ETPackages.Endpoints.Tests;

public class DummyEndpoint : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder builder)
    {
        builder.MapGet("/dummy", () => "Hello from Dummy!");
    }
}