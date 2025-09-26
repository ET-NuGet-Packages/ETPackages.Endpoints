﻿📌 ETPackages.Endpoints

**ETPackages.Endpoints** is a lightweight extension library designed to make .NET 6+ Minimal API endpoints more **readable, organized, and reusable**.

---

## ✨ Features
- ✅ Minimal API support  
- ✅ Group and organize endpoint definitions  
- ✅ Automatic discovery via reflection
- ✅ Support for single or multiple assemblies
- ✅ Cleaner code with extension methods  
- ✅ Full Swagger / OpenAPI compatibility

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

## 🤝 Contributing

Fork the repository

Create a new branch (feature/xyz)

Commit your changes

Open a pull request

---

## 📜 License

This project is licensed under the MIT License. ,