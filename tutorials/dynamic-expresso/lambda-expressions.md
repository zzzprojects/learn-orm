---
PermaID: 100007
Name: Lambda Expressions
---

# Lambda Expressions

You can use the `Interpreter.ParseAsExpression<TDelegate>` method to directly parse an expression into a .NET lambda expression (`Expression<TDelegate>`).

The following example generates a `Expression<Func<Customer, bool>>` expression that can be used in a `Queryable` LINQ where expression or in any other place where an expression is required like Entity Framework or other similar libraries.

```csharp
public static void Example1()
{
    var persons = new List<Person>
    {
        new Person() { Name = "David", Age = 31, Gender = 'M', Country = "US" },
        new Person() { Name = "Mary", Age = 29, Gender = 'F', Country = "UK" },
        new Person() { Name = "Jack", Age = 12, Gender = 'M', Country = "Germany" },
        new Person() { Name = "Marta", Age = 1, Gender = 'F', Country = "Japan" },
        new Person() { Name = "Moses", Age = 23, Gender = 'M', Country = "US" },
    };

    string whereExpression = "person.Age > 18 && person.Gender == 'F'";

    var interpreter = new Interpreter();
    Expression<Func<Person, bool>> expression = interpreter.ParseAsExpression<Func<Person, bool>>(whereExpression, "person");

    var result = persons.AsQueryable().Where(expression);

    foreach (var person in result)
    {
        Console.WriteLine("Name: {0}\nGender: {1}\nAge: {2}\nCountry: {3}", person.Name, person.Gender, person.Age, person.Country);
    }
}

public class Person
{
    public string Name { get; set; }
    public char Gender { get; set; }
    public int Age { get; set; }
    public string Country { get; set; }
}
```

Let's execute the above code, and you will see the following output.

```csharp
Name: Mary
Gender: F
Age: 29
Country: UK
```
