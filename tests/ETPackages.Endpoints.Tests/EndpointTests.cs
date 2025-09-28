using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace ETPackages.Endpoints.Tests;

public class EndpointTests
{
    [Fact]
    public async Task MapEndpoints_ShouldDiscoverAndMapDummyEndpoint()
    {
        var builder = new WebHostBuilder()
            .ConfigureServices(services =>
            {
                services.AddRouting();
                services.AddEndpoints(typeof(EndpointTests).Assembly);
            })
            .Configure(app =>
            {
                app.UseRouting();
                app.UseEndpoints(e => e.MapEndpoints());
            });

        using var server = new TestServer(builder);
        using var client = server.CreateClient();

        var response = await client.GetStringAsync("/dummy");

        Assert.Equal("Hello from Dummy!", response);
    }

    [Fact]
    public async Task MapEndpoints_ShouldDiscoverAndMapMultipleEndpoint()
    {
        var builder = new WebHostBuilder()
            .ConfigureServices(services =>
            {
                services.AddRouting();
                services.AddEndpoints(typeof(EndpointTests).Assembly);
            })
            .Configure(app =>
            {
                app.UseRouting();
                app.UseEndpoints(e => e.MapEndpoints());
            });

        using var server = new TestServer(builder);
        using var client = server.CreateClient();

        var fooResponse = await client.GetStringAsync("/foo");
        var barResponse = await client.GetStringAsync("/bar");

        Assert.Equal("Foo response", fooResponse);
        Assert.Equal("Bar response", barResponse);
    }

    [Fact]
    public async Task MapEndpoints_ShouldThrow_WhenDuplicateEndpointsExist()
    {
        var builder = new WebHostBuilder()
            .ConfigureServices(services =>
            {
                services.AddRouting();
                services.AddEndpoints(typeof(EndpointTests).Assembly);
            })
            .Configure(app =>
            {
                app.UseRouting();
                app.UseEndpoints(e => e.MapEndpoints());
            });

        Func<Task> act = async () =>
        {
            using var server = new TestServer(builder);
            using var client = server.CreateClient();

            var response = await client.GetStringAsync("/dup");
        };

        var exception = await Assert.ThrowsAnyAsync<Exception>(act);

        Assert.Contains("The request matched multiple endpoints", exception.Message);
    }

    [Fact]
    public void AddEndpoints_ShouldRegisterIEndpointImplementations()
    {
        var builder = WebApplication.CreateBuilder();

        builder.Services.AddEndpoints(typeof(EndpointTests).Assembly);

        var services = builder.Services.BuildServiceProvider();

        var endpoints = services.GetServices<IEndpoint>();

        Assert.NotEmpty(endpoints);

        Assert.Contains(endpoints, e => e.GetType() == typeof(DummyEndpoint));
    }

    [Fact]
    public void MapEndpoints_ShouldWork_WhenNoEndpointsExist()
    {
        var builder = WebApplication.CreateBuilder();

        builder.Services.AddEndpoints(typeof(EndpointTests).Assembly);

        var app = builder.Build();

        var exception = Record.Exception(() => app.MapEndpoints());

        Assert.Null(exception);
    }
}
