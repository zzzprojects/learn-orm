---
PermaID: 100019
Name: EFCore.BulkExtensions
---

In the world of database management, there is always a need to handle data in bulk. The traditional way of dealing with this is by writing custom code for each operation, which can be time-consuming and error-prone. Fortunately, there are many libraries that simplify these operations and one of them are [Z.EntityFramework.Extensions](https://entityframework-extensions.net/bulk-extensions). In this article, we will explore the BulkInsert, BulkUpdate, BulkDelete, and BulkMerge methods offered by thos library and how they can be used to efficiently handle bulk operations.

## Introduction

[Z.EntityFramework.Extensions](https://entityframework-extensions.net/bulk-extensions) is a popular library that extends the functionality of EF Core. The library provides various extensions method to Entity Framework Core, including the ability to perform bulk operations like BulkInsert, BulkDelete, BulkUpdate, and BulkMerge.

## Warning

We originally wrote the text for the [EFCore.BulkExtensions](https://nugetmusthaves.com/package/EFCore.BulkExtensions) package but we do not longer recommand using it.

Since 2023, the library costs between **$500 to $4000** to an enterprise.

Because the package is no longer free, there is no longer any good reason to use it over [Z.EntityFramework.Extensions](https://entityframework-extensions.net/bulk-extensions).

You can learn more about our package comparison on: [EFCore.BulkExtensions vs EF Extensions](https://riptutorial.com/ef-core-advanced-topics/learn/100018/efcore-bulkextensions-vs-ef-extensions)

## Benefits of using Bulk Operations

Before diving into the specifics of these operations, it's worth noting the benefits of using bulk operations. Bulk operations can help you to:

- Improve performance by minimizing the number of round trips to the database
- Reduce network traffic by sending data in bulk instead of one at a time
- Simplify code by abstracting away the details of each operation

## BulkInsert

The BulkInsert method allows you to insert a large number of records into the database. This method generates a SQL statement optimized for inserting multiple entities. This statement is then executed in a single round trip to the database, which makes it much faster than inserting each record individually.

### How to Use BulkInsert

To use BulkInsert, you first need to create a list of entities that you want to insert into the database. Once you have the list, you can call the BulkInsert method on your EF Core DbContext instance, passing in the list as a parameter. Here is an example:

```csharp
using (var context = new MyDbContext())
{
    var recordsToInsert = new List<MyEntity>
    {
        new MyEntity { Property1 = "Value1", Property2 = "Value2" },
        new MyEntity { Property1 = "Value3", Property2 = "Value4" }
    };

    context.BulkInsert(recordsToInsert);
}
```

This will generate a SQL statement that inserts two records into the database.

## BulkUpdate

The BulkUpdate method allows you to update a large number of records in the database. This method generates a SQL statement optimized for updating multiple entities. This statement is then executed in a single round trip to the database, which makes it much faster than updating each record individually.

### How to Use BulkUpdate

To use BulkUpdate, you first need to create a list of entities that you want to update in the database or directly retrieve it by querying your context. Once you have the list, you can call the BulkUpdate method on your EF Core DbContext instance, passing in the list as a parameter. Here is an example:

```csharp
using (var context = new MyDbContext())
{
    var recordsToUpdate = new List<MyEntity>
    {
        new MyEntity { Id = 1, Property1 = "Value1", Property2 = "Value2" },
        new MyEntity { Id = 2, Property1 = "Value3", Property2 = "Value4" }
    };

    context.BulkInsert(recordsToInsert);
}
```

This will generate a SQL statement that updates records from the MyEntity table with the corresponding values.

## BulkDelete

The BulkDelete method allows you to delete a large number of records from the database at once. This method generates a SQL statement that includes a single DELETE statement with a WHERE clause that specifies the records to be deleted. This statement is then executed in a single round trip to the database, which makes it much faster than deleting each record individually.

### How to Use BulkDelete

To use BulkDelete, you first need to create a list of entities that you want to delete from the database or directly retrieve it by querying your context. Once you have the list, you can call the BulkDelete method on your EF Core DbContext instance, passing in the list as a parameter. Here is an example:

```csharp
using (var context = new MyDbContext())
{
    var recordsToDelete = new List<MyEntity>
    {
        new MyEntity { Id = 1 },
        new MyEntity { Id = 2 }
    };

    context.BulkInsert(recordsToDelete);
}
```

This will generate a SQL statement that deletes all records from the MyEntity table where Property1 equals "Value1".

## BulkMerge

The BulkMerge method allows you to insert or update a large number of records in the database. The BulkMerge method also often have other name such as `Upsert`, `InsertOrUpdate`, or `AddOrUpdate`. This method generates a SQL statement that combines an INSERT and UPDATE statement, inserting new records or updating existing ones, depending on whether the record already exists in the database or not. This statement is then executed in a single round trip to the database, which makes it much faster than performing individual inserts or updates.

### How to Use BulkMerge

To use BulkMerge, you first need to create a list of objects that you want to insert or update in the database. Once you have the list, you can call the BulkMerge method on your Entity Framework Core DbContext instance, passing in the list as a parameter. Here is an example:

```csharp
using (var context = new MyDbContext())
{
    var recordsToMerge = new List<MyEntity>
    {
        new MyEntity { Id = 1, Property1 = "Value1", Property2 = "Value2" },
        new MyEntity { Id = 2, Property1 = "Value3", Property2 = "Value4" }
    };

    context.BulkMerge(recordsToMerge);
}
```

This will generate a SQL statement that inserts or updates two records into the database, depending on whether a record with the same Id already exists or not.

## Conclusion

Z.EntityFramework.Extensions provides efficient and easy-to-use methods for handling bulk operations in Entity Framework. The BulkInsert, BulkUpdate, BulkDelete, and BulkMerge methods are particularly useful for inserting, updating, and deleting large amounts of data in a single round trip to the database. By using these methods, you can improve performance, reduce network traffic, and simplify your code.