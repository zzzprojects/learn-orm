---
PermaID: 100008
Name: Default Literal Expressions
---

# Default Literal Expressions

A default literal expression produces the default value of a type. The `default` keyword is not a new one, it is being used for a long time. However, some enhancement has been done for **default literal expression**.

 - The default literal expressions are an enhancement to default value expressions. 
 - These expressions initialize a variable to the default value.

Before C# 7.1, we were able to use the `default` keyword as `default(T)` where `T` can be a value type or reference type.

```csharp
int intValue = default(int);
double doubleValue = default(double);
bool boolValue = default(bool);
string str = default(string);
int? nullableInt = default(int?);

Action<int, bool> action = default(Action<int, bool>);
Predicate<string> predicate = default(Predicate<string>);
List<string> list = default(List<string>);
Dictionary<int, string> dictionary = default(Dictionary<int, string>);
```

In C# 7.1, the default value expressions are enhanced by removing the need to pass `T` as a parameter while finding the default value of type. 

```csharp
double doubleValue = default;
bool boolValue = default;
string str = default;
int? nullableInt = default;

Action<int, bool> action = default;
Predicate<string> predicate = default;
List<string> list = default;
Dictionary<int, string> dictionary = default;
````

The Type is now inferred rather than passed as an argument. The default literal expressions also work with method arguments and return values.

```csharp
public int Add(int x, int y = default, int z = default)
{
    return x + y + z;
}
```

 - As you can see that the new default literal expressions let us write a little bit shorter code that is also easier to read as there are fewer parentheses and type names involved.
 - The `default` literal expression produces the same value as the `default(T)` expression where `T` is the inferred type. 