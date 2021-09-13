---
PermaID: 100013
Name: Disconnected Entities
---

# Disconnected Entities

A `DbContext` instance automatically tracks entities returned from the database, and any changes made to these entities are detected when `SaveChanges` is called, and the database is also updated as needed.

 - Sometimes entities are queried using one context instance and then saved using a different instance. 
 - In this case, the second context instance needs to know whether the entities are new (should be inserted) or existing (should be updated).

## Insert or Update Single Entities

It is necessary to determine whether to insert or update an entity. 

### Using Auto-generated Keys

The value of an automatically generated key can often be used to determine whether an entity needs to be inserted or updated.

 - If the key has not been set, then the entity must be new and needs inserting. 
 - On the other hand, if the key-value has been set, then it must have already been previously saved and now needs updating. 

It is easy to check for an unset key when the entity type is known.

```csharp
using (var context = new EntityContext())
{
    if (author.AuthorId == 0)
    {
        context.Authors.Add(author);
    }
    else
    {
        context.Authors.Update(author);
    }

    context.SaveChanges();
}
```

You can use a built-in way to do this for any entity type and key type.

```csharp
using (var context = new EntityContext())
{
    if (!context.Entry(author).IsKeySet)
    {
        context.Authors.Add(author);
    }
    else
    {
        context.Authors.Update(author);
    }

    context.SaveChanges();
}
```

In the case of auto-generated key values, the `Update` method can also be used for both cases. 

 - The `Update` method normally marks the entity for the update, not insert.
 - If the entity has an auto-generated key, and no key value has been set, then the entity is automatically marked for the insert.

```csharp
public static void InsertOrUpdate(DbContext context, object entity)
{
    context.Update(entity);
    context.SaveChanges();
}
```

### Other Keys

When the key values are not generated automatically, then you can use the `Find()` method to query for the entity.

```csharp
using (var context = new EntityContext())
{
    var existingAuthor = context.Authors.Find(author.AuthorId);
    if (existingAuthor == null)
    {
        context.Add(author);
    }
    else
    {
        context.Entry(existingAuthor).CurrentValues.SetValues(author);
    }

    context.SaveChanges();
}
```

## Entity Graph

Entity Framework Core provides different methods, like `Add`, `Attach`, `Entry`, `Remove` and `Update` for entity graph-traversal and determine whether an entity should be marked as `Added`, `Modified`, `Unchanged`, or `Deleted`. These methods work well for individual entities or in cases where you don't mind all properties being included in an `UPDATE` statement whether they were changed or not.

Here is a simple object graph.

```csharp
var author = new Author()
{
    AuthorId = 1,
    FirstName = "Elizabeth",
    LastName = "Lincoln",
    Books = new List<Book>()
    {
        new Book()
        {
            Id = 1,
            Title = "Book 1 Title"
        },
        new Book()
        {
            Id =2,
            Title = "Book 2 Title"
        }
    }
};
```

In this object graph, we have two books of an author, and the `Title` property for both books has been changed. To update the database for the above object graph, we can use the `Update()` method, and it will do the job. 


```csharp
using(var context = new EntityContext())
{
    context.Update(author);
    context.SaveChanges();
}
```

 - The `Update` method will mark the root entity and all its related entities as `Modified`. 
 - SQL will be generated to update all of their properties (whether they have been changed or not) to the values that have been assigned to the entities. 
 - That means that all of the values for all of the entities have to be present; otherwise, they will be overwritten with null or default values.

### TrackGraph

In Entity Framework Core, the `ChangeTracker.TrackGraph()` method was introduced to track the entire entity graph and set custom entity states to each entity in a graph. It is designed for use in disconnected scenarios where entities are retrieved using one instance of the context and then changes are saved using a different instance of the context.

 - It starts tracking an entity and any entities that are reachable by traversing its navigation properties. 
 - Traversal is recursive, so the navigation properties of any discovered entities will also be scanned. 
 - The specified `callback` is called for each discovered entity and must set the state that each entity should be tracked in. If no state is set, the entity remains untracked.
 - If an entity is discovered that is already tracked by the context, that entity is not processed and its navigation properties are not traversed.

 The `TrackGraph` method provides easy access to each entity in the graph.
 
```csharp
using (var context = new EntityContext())
{
    context.ChangeTracker.TrackGraph(author, e =>
    {
        e.Entry.State = EntityState.Unchanged;

        if((e.Entry.Entity as Book) != null)
        {
            if (e.Entry.IsKeySet)
            {
                e.Entry.State = EntityState.Modified;
            }
            else
            {
                e.Entry.State = EntityState.Added;
            }
        }
    });

    foreach (var entry in context.ChangeTracker.Entries())
    {
        Console.WriteLine("Entity: {0}, State: {1}", entry.Entity.GetType().Name, entry.State.ToString());
    }
    context.SaveChanges();
}
```

The `TrackGraph` method is new in Entity Framework Core and offers a simple way to iterate over a graph of objects that you want the context to begin tracking, and to apply customized code based on the type of entity and other criteria.
