using Microsoft.AspNetCore.Routing;

namespace ETPackages.Endpoints
{
    public interface IEndpoint
    {
        void MapEndpoints(IEndpointRouteBuilder app);
    }
}
