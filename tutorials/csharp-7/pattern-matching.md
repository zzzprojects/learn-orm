---
PermaID: 100000
Name: Pattern Matching
---

# Pattern Matching

Pattern matching concept was first introduced in C# 7.0, and it checks if an object reflects a certain shape. It will also check that it can extract information from the value when it has the matching shape. 

 - It provides more concise syntax for algorithms you already use today. 
 - You already create pattern matching algorithms using existing syntax such as `if` or `switch` statements that test values, when those statements match, you extract and use information from that value. 
 - The new syntax elements are extensions to statements you are already familiar with i.e. `is` and `switch`. 
 - These new extensions combine testing a value and extracting that information.

## `is` Type Pattern

Before C# 7.0, you would need to test each type in a series of `if` and `is` statements. Let's consider the following simple example, which a classic expression of the type pattern. 

```csharp
if (person is Teacher)
{
    Console.WriteLine("Salary: {0}", ((Teacher)person).Salary);
}
else if (person is Student)
{
    Console.WriteLine("GPA: {0}", ((Student)person).GPA);
}
```

As you can see, it is testing a variable to determine its type and taking a different action based on that type. 

In C# 7.0, this code becomes simpler using extensions to the `is` expression to assign a variable if the test succeeds.

```csharp
if (person is Teacher t)
{
    Console.WriteLine("Salary: {0}", t.Salary);
}
else if (person is Student s)
{
    Console.WriteLine("GPA: {0}", s.GPA);
}
```

The `is` expression tests both the variable and assigns it to a new variable of the proper type in C# 7.0 and later. 

 - The new `is` expression works with value types as well as reference types.
 - The variables `t` and `s` are only in scope and definitely assigned when the respective pattern match expressions have true results. 
 - If you try to use either variable in another location, it will generate compiler errors.

## `switch` Type Pattern

The traditional `switch` statement was a pattern expression, and it supported the constant pattern by comparing a variable to any constant used in a `case` statement.

```csharp
int caseSwitch = 1;

switch (caseSwitch)
{
    case 1:
        Console.WriteLine("Case 1");
        break;
    case 2:
        Console.WriteLine("Case 2");
        break;
    default:
        Console.WriteLine("Default case");
        break;
}
```

The only pattern supported was the constant pattern, and it was also limited to numeric types and the string type. 

In C# 7.0, those restrictions have been removed, and you can now write a `switch` statement using the type pattern as shown below.

```csharp
switch (person)
{
    case Teacher t:
        return "Salary: " + t.Salary;
    case Student s:
        return "GPA: " + s.GPA;
    default:
        throw new ArgumentException(message: "It is not a recognized person", paramName: nameof(person));
}
```

Each `case` is evaluated, and the code beneath the condition that matches the input variable is executed. The case statement statement requires that each case end with a `break`, `return`, or `goto`.

### `when` Clause

You can also use a `when` clause on the case label to specify an additional condition. Let's consider the following example in which we specified a condition using a `when` clause on the case label.

```csharp
switch (person)
{
    case Teacher t when t.Salary == 0.0:
    case Student s when s.GPA == 0.0:
        return "";

    case Teacher t:
        return "Salary: " + t.Salary;
    case Student s:
        return "GPA: " + s.GPA;
    default:
        throw new ArgumentException(message: "It is not a recognized person", paramName: nameof(person));
}
```

You can also add a `null` case to ensure the argument is not null as shown below.

```csharp
switch (person)
{
    case Teacher t when t.Salary == 0.0:
    case Student s when s.GPA == 0.0:
        return "";

    case Teacher t:
        return "Salary: " + t.Salary;
    case Student s:
        return "GPA: " + s.GPA;
    case null:
        throw new ArgumentNullException(paramName: nameof(person), message: "Person must not be null");
    default:
        throw new ArgumentException(message: "It is not a recognized person", paramName: nameof(person));
}
```

The special behavior for the `null` pattern is interesting because the constant `null` in the pattern doesn't have a type but can be converted to any reference type or nullable value type.
