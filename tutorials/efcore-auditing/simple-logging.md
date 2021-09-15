---
PermaID: 100003
Name: Simple Logging
---

# Simple Logging

`EFCoreAuditing` provides the infrastructure to log various kinds of operations with the EF `DbContext`. It allows you to store detailed information about insert, update and delete operations in your database.

To use logging in your application, you need to change your context class to inherit from `AuditingDbContext` instead of `DbContext`, as shown below.

```csharp
public class BookStore : AuditingDbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=BookStoreDb;");
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
}
```

Let's run your application and create the following table in your database containing all the related log information when you perform database operations.

```csharp
CREATE TABLE [audit].[AuditLogs] (
    [AuditLogId]    BIGINT         IDENTITY (1, 1) NOT NULL,
    [UserName]      NVARCHAR (MAX) NULL,
    [EventDateTime] DATETIME2 (3)  NOT NULL,
    [EventType]     NVARCHAR (MAX) NULL,
    [SchemaName]    NVARCHAR (MAX) NULL,
    [TableName]     NVARCHAR (MAX) NULL,
    [KeyNames]      NVARCHAR (MAX) NULL,
    [KeyValues]     NVARCHAR (MAX) NULL,
    [ColumnName]    NVARCHAR (MAX) NULL,
    [OriginalValue] NVARCHAR (MAX) NULL,
    [NewValue]      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AuditLogs] PRIMARY KEY CLUSTERED ([AuditLogId] ASC)
);
```

