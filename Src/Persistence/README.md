# Persistence Layer

This layer contains classes for storing and retrieving data from a data store such as a database.

These classes should be based on interfaces defined within the application layer and entity objects defined within the domain layer.

## [Service lifetimes](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.0)

Choose an appropriate lifetime for each registered service. ASP.NET Core services can be configured with the following lifetimes:

### Transient

Transient lifetime services (AddTransient) are created each time they're requested from the service container. This lifetime works best for lightweight, stateless services.

### Scoped

Scoped lifetime services (AddScoped) are created once per client request (connection).

>**Warning**
When using a scoped service in a middleware, inject the service into the Invoke or InvokeAsync method. Don't inject via constructor injection because it forces the service to behave like a singleton. For more information, see Write custom ASP.NET Core middleware.

### Singleton

Singleton lifetime services (AddSingleton) are created the first time they're requested (or when Startup.ConfigureServices is run and an instance is specified with the service registration). Every subsequent request uses the same instance. If the app requires singleton behavior, allowing the service container to manage the service's lifetime is recommended. Don't implement the singleton design pattern and provide user code to manage the object's lifetime in the class.

>**Warning**
It's dangerous to resolve a scoped service from a singleton. It may cause the service to have incorrect state when processing subsequent requests.

## Database Migrations

Use following commands.

>dotnet ef migrations add InitialCreate
>dotnet ef database update
