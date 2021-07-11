---
PermaID: 100006
Name: Configuration using Fluent API
---

# Configuration using Fluent API

The **Audit.EntityFramework.Core** also allows you to configure the settings via a Fluent API provided by the method `Audit.EntityFramework.Configuration.Setup()`. It is the easiest way to configure the library.

The following example configures a `BookStore` context by including the objects on the output, using the `OptOut` mode, and it will also exclude entities whose name ends with History from the audit.

```csharp
Audit.EntityFramework.Configuration.Setup()
    .ForContext<BookStore>(config => config
        .IncludeEntityObjects()
        .AuditEventType("{BookStore}:{BookStoreDb}"))
    .UseOptOut()
        .IgnoreAny(t => t.Name.EndsWith("History"));
```

You can configure to ignore any specific property to save to the database. The following example ignore the **Photo** column. 
```csharp
Audit.EntityFramework.Configuration.Setup()
    .ForContext<BookStore>(config => config
        .ForEntity<Author>(_ => _
            .Ignore(a => a.Photo)));
```

You can also override and format the column values.

```csharp
Audit.EntityFramework.Configuration.Setup()
    .ForContext<BookStore>(config => config
        .ForEntity<User>(_ => _
            .Override(user => user.OldPassword, null)
            .Format(user => user.Password, pass => new String('*', pass.Length))));
```

As a result of the above configuration, the `OldPassword` will be always `null` and the `Password` will be set to several stars (`*`) equal to the number of password characters.