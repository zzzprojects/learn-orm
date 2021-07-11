---
PermaID: 100002
Name: Configuration
---

# Configuration

## Setup Connection String

For local development, the ASP.NET Core configuration system reads the connection string from the ***appsettings.json*** file. So let's add the connection to that file, as shown below.

```csharp
{
  "ConnectionStrings": {
    "MyConnection": "Data Source=D:\\BookStoreDB.db"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
```

To resolve the connection strings from the config file, we need to enable the extension by calling `UseConfigurationManager` inside the `OnConfiguring` method of the `DbContext` type. 

```csharp
public class BookStore : DbContext
{
    public BookStore(DbContextOptions<BookStore> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options
            .UseConfigurationManager()
            .UseSqlite("Name=MyConnection");
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
}
```

You can also specify the connection string from the config file when scaffolding a `DbContext` at design time.

```csharp
Scaffold-DbContext Name=MyConnection Microsoft.EntityFrameworkCore.Sqlite
```
