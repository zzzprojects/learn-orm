---
PermaID: 110001
Name: DbContext Configuration
---

# DbContext Configuration

This article shows basic patterns for configuring a DbContext via a DbContextOptions to connect to a database using a specific EF Core provider and optional behaviors.

## Design-time DbContext Configuration

Some of the EF Core Tools commands such as the Migrations commands require a derived `DbContext` instance to be created at design time to gather details about the application's entity types and how they map to a database schema. In most cases, it is desirable that the DbContext thereby created is configured in a similar way to how it would be configured at run time.

There are various ways the tools try to create the DbContext:

### From application services

If your startup project uses the ASP.NET Core Web Host or .NET Core Generic Host, the tools try to obtain the `DbContext` object from the application's service provider.

The tools first try to obtain the service provider by invoking `Program.CreateHostBuilder()`, calling `Build()`, then accessing the `Services` property.

```csharp
public class Program
{
    public static void Main(string[] args)
        => CreateHostBuilder(args).Build().Run();

    // EF Core uses this method at design time to access the DbContext
    public static IHostBuilder CreateHostBuilder(string[] args)
        => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(
                webBuilder => webBuilder.UseStartup<Startup>());
}

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
        => services.AddDbContext<EntityContext>();
}

public class EntityContext : DbContext
{
    public EntityContext(DbContextOptions<EntityContext> options)
        : base(options)
    {
    }
}
```

When you create a new ASP.NET Core application, this hook is included by default. The `DbContext` itself and any dependencies in its constructor need to be registered as services in the application's service provider. This can be easily achieved by having a constructor on the `DbContext` that takes an instance of `DbContextOptions<TContext>` as an argument and using the `AddDbContext<TContext>` method.

### Using a constructor with no parameters

If the `DbContext` can't be obtained from the application service provider, the tools look for the derived `DbContext` type inside the project. Then they try to create an instance using a constructor with no parameters. This can be the default constructor if the `DbContext` is configured using the `OnConfiguring` method.

### From a design-time factory

You can also tell the tools how to create your `DbContext` by implementing the `IDesignTimeDbContextFactory<TContext>` interface. If a class implementing this interface is found in either the same project as the derived `DbContext` or in the application's startup project, the tools bypass the other ways of creating the `DbContext` and use the design-time factory instead.

```csharp
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MyProject
{
    public class EntityContextFactory : IDesignTimeDbContextFactory<EntityContext>
    {
        public EntityContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EntityContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=NewBookStore;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new EntityContext(optionsBuilder.Options);
        }
    }
}
```

Before EFCore 5.0, the `args` parameter was unused and it is fixed in EFCore 5.0 and any additional design-time arguments are passed into the application through that parameter.

A design-time factory can be especially useful if you need to configure the `DbContext` differently for design time than at run time, if the `DbContext` constructor takes additional parameters are not registered in DI, if you are not using DI at all, or if for some reason you prefer not to have a `BuildWebHost` method in your ASP.NET Core application's `Main` class. 

## Configuring DbContextOptions

The `DbContext` must have an instance of `DbContextOptions` to perform any work. The `DbContextOptions` instance carries configuration information such as:

 - The database provider to use, typically selected by invoking a method such as `UseSqlServer` or `UseSqlite` etc. These extension methods require the corresponding provider package, such as `Microsoft.EntityFrameworkCore.SqlServer` or `Microsoft.EntityFrameworkCore.Sqlite`. The methods are defined in the `Microsoft.EntityFrameworkCore` namespace.
 - Any necessary connection string or identifier of the database instance typically passed as an argument to the provider selection method mentioned above
 - Any provider-level optional behavior selectors, typically also chained inside the call to the provider selection method
 - Any general EF Core behavior selectors, typically chained after or before the provider selector method

The following example configures the DbContextOptions to use the SQL Server provider, a connection contained in the connectionString variable, a provider-level command timeout, and an EF Core behavior selector that makes all queries executed in the DbContext no-tracking by default:

```csharp
optionsBuilder
    .UseSqlServer(connectionString, providerOptions=>providerOptions.CommandTimeout(60))
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
```

The `DbContextOptions` can be supplied to the `DbContext` by overriding the `OnConfiguring` method or externally via a constructor argument.

If both are used, `OnConfiguring` is applied last and can overwrite options supplied to the constructor argument.

### Constructor argument

Your constructor can simply accept a `DbContextOptions` as follows:

```csharp
public class EntityContext : DbContext
{
    public EntityContext(DbContextOptions<EntityContext> options)
        : base(options)
    { }

    public DbSet<Author> Authors { get; set; }
}
```

The base constructor of `DbContext` also accepts the non-generic version of `DbContextOptions`, but using the non-generic version is not recommended for applications with multiple context types.

Your application can now pass the `DbContextOptions` when instantiating a context, as follows:

```csharp
var optionsBuilder = new DbContextOptionsBuilder<EntityContext>();
optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=NewBookStore;Trusted_Connection=True;MultipleActiveResultSets=true");

using (var context = new EntityContext(optionsBuilder.Options))
{
    // code here
}
```

### OnConfiguring

You can also initialize the `DbContextOptions` within the context itself. While you can use this technique for basic configuration, you will typically still need to get certain configuration details from the outside, e.g. a database connection string. This can be done with a configuration API or any other means.

To initialize `DbContextOptions` within the context, override the `OnConfiguring` method and call the methods on the provided `DbContextOptionsBuilder`:

```csharp
public class EntityContext : DbContext
{
    public DbSet<Author> Authors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=NewBookStore;Trusted_Connection=True;MultipleActiveResultSets=true");
    }
}
```

An application can simply instantiate such a context without passing anything to its constructor:

```csharp
using (var context = new EntityContext())
{
    // code here
}
```

### Using DbContext with dependency injection

EF Core supports using `DbContext` with a dependency injection container. Your `DbContext` type can be added to the service container by using the `AddDbContext<TContext>` method.

`AddDbContext<TContext>` will make both your `DbContext` type, `TContext`, and the corresponding `DbContextOptions<TContext>` available for injection from the service container.

Add the `DbContext` to dependency injection.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<EntityContext>(options => options.UseSqlServer(ConnectionString));
}
```

This requires adding a constructor argument to your `DbContext` type that accepts `DbContextOptions<TContext>`.

```csharp
public class EntityContext : DbContext
{
    public EntityContext(DbContextOptions<EntityContext> options)
      :base(options)
    { }

    public DbSet<Author> Authors { get; set; }
}
```
Here is the code used in ASP.NET Core application:

```csharp
public class AuthorController
{
    private readonly EntityContext _context;

    public AuthorController(EntityContext context)
    {
      _context = context;
    }

    ...
}
```

Here is the code using ServiceProvider directly which is less common:

```csharp
using (var context = serviceProvider.GetService<EntityContext>())
{
    // code here
}

var options = serviceProvider.GetService<DbContextOptions<EntityContext>>();
```