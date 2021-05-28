---
PermaID: 100006
Name: Dynamic Delegates
---

# Dynamic Delegates

You can use the `Interpreter.ParseAsDelegate<TDelegate>` method to directly parse an expression into a .NET delegate type that can be easily invoked. 

The following example generates a `Func<Customer, bool>` delegate that can be used in a LINQ where expression.

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
    Func<Person, bool> dynamicWhere = interpreter.ParseAsDelegate<Func<Person, bool>>(whereExpression, "person");

    var result = persons.Where(dynamicWhere);
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
