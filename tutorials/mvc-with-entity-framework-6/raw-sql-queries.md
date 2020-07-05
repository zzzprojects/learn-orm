---
PermaID: 100018
Name: Raw SQL Queries
---

# Raw SQL Queries

The Entity Framework Code First API includes methods that enable you to pass SQL commands directly to the database. 

 - One of the advantages of using the Entity Framework is that it avoids tying your code too closely to a particular method of storing data. 
 - It does this by generating SQL queries and commands for you, which also frees you from having to write them yourself. 
 - But there are exceptional scenarios when you need to run specific SQL queries that you have manually created, and these methods make it possible for you to handle such exceptions.

## Precautions

 - When you execute SQL commands in a web application, you must take precautions to protect your site against SQL injection attacks. 
 - The best way is to use parameterized queries to make sure that strings submitted by a web page can't be interpreted as SQL commands.

## Methods to Execute Raw SQL
  
In Entity Framework, you can use any of the following methods to execute SQL commands directly to the database. 

 - **DbSet.SqlQuery:** Return entity types, and the returned objects must be of the type expected by the `DbSet` object.
 - **Database.SqlQuery:** Return types that aren't entities, and the returned data isn't tracked by the database context, even if you use this method to retrieve entity types.
 - **Database.ExecuteSqlCommand:** Use for non-query commands.

### DbSet.SqlQuery

The `DbSet<TEntity>` class provides a method `SqlQuery` that you can use to execute a query that returns an entity of type `TEntity`.

In `HttpGet` `Details` method of `AuthorController`, the `db.Authors.Find(id)` retrieves the author entity from the database. So let's replace this call with `db.Authors.SqlQuery` method call.

```csharp
// GET: Author/Details/5
public ActionResult Details(int? id)
{
    if (id == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }

    //Author author = db.Authors.Find(id);

    // Create and execute raw SQL query.
    string query = "SELECT * FROM Authors WHERE AuthorId = @p0";
    Author author = db.Authors.SqlQuery(query, id).SingleOrDefault();

    if (author == null)
    {
        return HttpNotFound();
    }
    return View(author);
}
```

To verify that the new code works correctly, run your application and go to the **Authors** tab and then click on the Details for one of the authors. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/mvc-with-entity-framework-6/images/raw-sql-queries-1.png">

Make sure all of the data displays as expected.

### Database.ExecuteSqlCommand

The `Database.ExecuteSqlCommnad()` method is useful in executing database commands, such as the `Insert`, `Update` and `Delete` command.

In `HttpPost` `Delete` method of `AuthorController`, the `db.Authors.Find(id)` retrieves the author entity from the database and then remove it from the database. So let's replace these call with `db.Database.ExecuteSqlCommand` method call.

```csharp
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Delete(int id)
{
    try
    {
        //Author author = db.Authors.Find(id);
        //db.Authors.Remove(author);
        //db.SaveChanges();

        string query = "DELETE FROM Authors WHERE AuthorId = @p0";
        int noOfRowDeleted = db.Database.ExecuteSqlCommand(query, id);
    }
    catch (RetryLimitExceededException/* dex */)
    {
        //Log the error (uncomment dex variable name and add a line here to write a log.
        return RedirectToAction("Delete", new { id = id, saveChangesError = true });
    }

    return RedirectToAction("Index");
}
```