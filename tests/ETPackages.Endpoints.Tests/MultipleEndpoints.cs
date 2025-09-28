using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace ETPackages.Endpoints.Tests;

public class FooEndpoint : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder builder)
    {
        builder.MapGet("/foo", () => "Foo response");
    }
}

public class BarEndpoint : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder builder)
    {
        builder.MapGet("/bar", () => "Bar response");
    }
}
