using System.Reflection;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ETPackages.Endpoints
{
    public static class EndpointExtensions
    {
        public static IServiceCollection AddEndpoints(this IServiceCollection services, params Assembly[] assemblies)
        {
            Type endpointType = typeof(IEndpoint);

            ServiceDescriptor[] serviceDescriptors = assemblies
                .SelectMany(a => a.GetTypes())
                .Where(type => !type.IsAbstract &&
                               !type.IsInterface &&
                               type.IsAssignableTo(endpointType))
                .Select(type => ServiceDescriptor.Transient(endpointType, type))
                .ToArray();

            services.TryAddEnumerable(serviceDescriptors);

            return services;
        }

        #if NET6_0

        public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
        {
            IEnumerable<IEndpoint> endpoints = app.ServiceProvider.GetRequiredService<IEnumerable<IEndpoint>>();

            foreach (IEndpoint endpoint in endpoints)
            {
                endpoint.MapEndpoints(app);
            }

            return app;
        }

        #endif

        #if NET7_0_OR_GREATER

        public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app, RouteGroupBuilder? routeGroupBuilder = null)
        {
            IEnumerable<IEndpoint> endpoints = app.ServiceProvider.GetRequiredService<IEnumerable<IEndpoint>>();

            IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;

            foreach (IEndpoint endpoint in endpoints)
            {
                endpoint.MapEndpoints(builder);
            }

            return app;
        }

        #endif
    }
}
