---
PermaID: 100007
Name: Data Annotation
---

# Data Annotation

Data annotation adds some extra meaning to the classes and properties by adding attribute tags. It is used to configure the classes, which will highlight the most commonly needed configurations.

The **Dapper.SimpleCRUD** library provides some optional attributes which are very helpful.

| Attribute      | Description                                                                                  |
| :--------------| :--------------------------------------------------------------------------------------------|
| Key            | To make the corresponding column a primary key (PK) column in the database.                  |
| Table          | Map a table with a specified name in the `Table` attribute for a given domain class.           |
| Column         | Map a column with a specified name in the `Column` attribute for a given property.           |
| Editable       | Specify if the property is editable or not.                                                 |
| Required       | You can mark a property as a `Required` if you want to specify the value yourself during the insert such as the primary key. |
| ReadOnly       | Specify if the property is decorated with ReadOnly(true) is only used for selects and is excluded from inserts and updates. |
| IgnoreSelect   | Excludes the property from selects            |
| IgnoreInsert   | Excludes the property from inserts            |
| IgnoreUpdate   | Excludes the property from updates            |
| NotMapped      | Excludes the property from all operations     |

## Key

The `Key` attribute specifies the property that is a primary key column in the database.

```csharp
class Author
{
    [Key]
    public int AuthorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Book> Books { get; set; }
}
```

## Table

By default, the database table name will match the class name. You can use another table name by specifying the `Table` attribute.

```csharp
[Table("tbl_Authors")]
class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Book> Books { get; set; }
}
```

## Column

By default, the column name will match the property name. You can use another property name by specifying the `Column` attribute.

```csharp
class Author
{
    public int Id { get; set; }

    [Column("FirstName")]
    public string FName { get; set; }

    [Column("FirstName")]
    public string LName { get; set; }
    public List<Book> Books { get; set; }
}
```

## Editable

The `Editable` attribute specifies that the property is editable or not to the database.

```csharp
class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [Editable(false)]
    public string FullName 
    { 
        get
        {
            return FirstName + " " + LastName;
        } 
    }

    [Editable(false)]
    public List<Book> Books { get; set; }
}
```

## Required

The `Required` attribute specifies that a data field value is required.

```csharp
class Author
{
    [Key]
    [Required]
    public int AuthorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Book> Books { get; set; }
}
```

## ReadOnly

Properties decorated with `ReadOnly(true)` are only used for selects and are excluded from inserts and updates.

```csharp
class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [ReadOnly(true)]
    public string FullName 
    { 
        get
        {
            return FirstName + " " + LastName;
        } 
    }

    [Write(false)]
    public List<Book> Books { get; set; }
}
```
