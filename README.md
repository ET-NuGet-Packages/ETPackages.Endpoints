﻿📌 ETPackages.Endpoints

[![Build & Publish](https://github.com/ET-NuGet-Packages/ETPackages.Endpoints/actions/workflows/nuget-publish.yml/badge.svg)](https://github.com/ET-NuGet-Packages/ETPackages.Endpoints/actions)
[![NuGet Version](https://img.shields.io/nuget/v/ETPackages.Endpoints.svg?logo=nuget)](https://www.nuget.org/packages/ETPackages.Endpoints/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/ETPackages.Endpoints.svg)](https://www.nuget.org/packages/ETPackages.Endpoints/)
[![Target Frameworks](https://img.shields.io/badge/.NET-6%20%7C%207%20%7C%208%20%7C%209-blue?logo=dotnet)](https://dotnet.microsoft.com/)

**ETPackages.Endpoints** is a lightweight extension library designed to make .NET 6+ Minimal API endpoints more **readable, organized, and reusable**.

---

## ✨ Features
- ✅ Minimal API support  
- ✅ Define endpoints in separate classes implementing `IEndpoint`
- ✅ Auto-discover and map endpoints with `AddEndpoints()` and `MapEndpoints()`
- ✅ Support for single or multiple assemblies
- ✅ Cleaner code with extension methods  
- ✅ Easily testable and extendable
- ✅ Full Swagger / OpenAPI compatibility

---

## ✨ Why use ETPackages.Endpoints?

- **Cleaner `Program.cs`**  
  No more huge lists of `app.MapGet(...)` calls.
- **Separation of concerns**  
  Each endpoint lives in its own class.
- **Auto-discovery**  
  Endpoints are automatically discovered and mapped.
- **Testability**  
  Endpoints can be tested independently.
- **Scalability**  
  Easy to maintain even in large projects.

---

## 📋 Requirements

- .NET 6.0 or higher  

---

## 📦 Installation

Install via [NuGet](https://www.nuget.org/packages/ETPackages.Endpoints):

```dash
Install-Package ETPackages.Endpoints
```

Or via the .NET Core command line interface:

```dash
dotnet add package ETPackages.Endpoints
```

---

## 🚀 Usage

```csharp
using ETPackages.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpoints(typeof(Program).Assembly);

var app = builder.Build();

// Use the extension method to map endpoints
app.MapEndpoints();

app.Run();

```

---

## 📂 Example Endpoint Group

```csharp
using Microsoft.AspNetCore.Routing;
using ETPackages.Endpoints;

public class UserEndpoints : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder builder)
    {
        var group = builder
            .MapGroup("/users")
            .WithTags("Users");

        group.MapGet("/", () => Results.Ok("Get all users"));

        group.MapPost("/", () => Results.Ok("Create user"));
    }
}

```

---

## 🧪 Running Tests

This project includes a dedicated test project located in:

tests/ETPackages.Endpoints.Tests

### Run all tests

```
dotnet test
```

### Run tests with detailed output

```
dotnet test -v n
```

### Run a specific test class

```
dotnet test --filter "FullyQualifiedName~ETPackages.Endpoints.Tests.EndpointTests"
```

### Notes

- Tests use xUnit + FluentAssertions for better readability.
- Microsoft.AspNetCore.Mvc.Testing and TestServer are used to run in-memory Minimal API applications.
- Covered scenarios:
    - Endpoint discovery (AddEndpoints)
    - Single & multiple endpoints mapping
    - Duplicate endpoint conflict
    - No endpoints case (graceful handling)

---

## 🤝 Contributing

Fork the repository

Create a new branch (feature/xyz)

Commit your changes

Open a pull request

---

## 📜 License

This project is licensed under the MIT License. ,