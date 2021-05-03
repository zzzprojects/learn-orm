---
PermaID: 100002
Name: SQL Builder
---

# SQL Builder

**Dapper.SqlBuilder** library provides various methods to build your SQL queries dynamically. The following example builds a simple `SELECT` query to retrieve all the authors from the database.

```csharp
private static List<Author> GetAuthors()
{
    using (IDbConnection connection = new SqlConnection(ConnectionString))
    {
        var builder = new SqlBuilder();
        builder.Select("Id");
        builder.Select("FirstName");
        builder.Select("LastName");

        var builderTemplate = builder.AddTemplate("Select /**select**/ from Authors");

        var authors = connection.Query<Author>(builderTemplate.RawSql).ToList();

        return authors;
    }
}
```

You can also build the SQL query containing the `WHERE` clause using the `DynamicParameters` as shown below.

```csharp
private static Author GetAuthor(int id)
{
    using (IDbConnection connection = new SqlConnection(ConnectionString))
    {
        var builder = new SqlBuilder();
        builder.Select("Id");
        builder.Select("FirstName");
        builder.Select("LastName");

        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@MyParam", id, DbType.Int32, ParameterDirection.Input);

        builder.Where("Id = @MyParam", parameters);

        var builderTemplate = builder.AddTemplate("Select /**select**/ from Authors /**where**/ ");

        var author = connection.Query<Author>(builderTemplate.RawSql, builderTemplate.Parameters).FirstOrDefault();

        return author;
    }
}
```

The following example builds the SQL query, which contains an inner join between `Authors` and `Books`.

```csharp
private static List<Author> GetAuthorWithBooks()
{
    var builder = new SqlBuilder();
    builder.Select("*");

    builder.InnerJoin("Books on Books.AuthorId=Authors.Id");

    var builderTemplate = builder.AddTemplate("Select /**select**/ from Authors /**innerjoin**/ ");

    var authorDictionary = new Dictionary<int, Author>();

    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        var authors = db.Query<Author, Book, Author>(
            builderTemplate.RawSql,
            (author, book) =>
            {
                Author authorEntry;

                if (!authorDictionary.TryGetValue(author.Id, out authorEntry))
                {
                    authorEntry = author;
                    authorEntry.Books = new List<Book>();
                    authorDictionary.Add(authorEntry.Id, authorEntry);
                }

                authorEntry.Books.Add(book);
                return authorEntry;
            },
            splitOn: "Id")
        .Distinct()
        .ToList();

        return authors;
    }
}
```
