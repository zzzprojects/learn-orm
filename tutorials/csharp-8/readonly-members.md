---
PermaID: 100002
Name: Readonly Members
---

# Readonly Members

In C# 8.0, a new feature is introduced which allows you to declare members of a `struct` is read-only. 

 - If you do not want to declare the whole structure type as read-only, use the `readonly` modifier to mark the instance members that don't modify the state of the `struct`.
 - It indicates that the member doesn't modify the state. 
 - It is more granular than applying the `readonly` modifier to a `struct` declaration.

Let's consider the following mutable structure that has two properties `Height` and `Width`. It calculates the area in another field `Area`. The `ToString()` method which returns a string that contains information about the rectangle object.

```csharp
public struct Rectangle
{
    public double Height { get; set; }
    public double Width { get; set; }
    public double Area => (Height * Width);
    public Rectangle(double height, double width)
    {
        Height = height;
        Width = width;
    }
    public override string ToString()
    {
        return $"(Total area for height: {Height}, width: {Width}) is {Area}";
    }                
}
```

As you can see the `ToString()` method doesn't modify the state, so we can add the `readonly` modifier to the declaration of `ToString()`.

```csharp
public struct Rectangle
{
    public double Height { get; set; }
    public double Width { get; set; }
    public double Area => (Height * Width);
    public Rectangle(double height, double width)
    {
        Height = height;
        Width = width;
    }
    public readonly override string ToString()
    {
        return $"(Total area for height: {Height}, width: {Width}) is {Area}";
    }                
}
```

After adding the `readonly` modifier to the `ToString()` declaration, you will see the following warning.

```csharp
Warning CS8656: Call to non-readonly member 'Rectangle.Area.get' from a 'readonly' member results in an implicit copy of 'this'.
```

The compiler warns you when it needs to create a defensive copy. The `Area` property doesn't change state, so you can fix this warning by adding the `readonly` modifier to the declaration.

```csharp
public struct Rectangle
{
    public double Height { get; set; }
    public double Width { get; set; }
    public readonly double Area => (Height * Width);
    public Rectangle(double height, double width)
    {
        Height = height;
        Width = width;
    }
    public readonly override string ToString()
    {
        return $"(Total area for height: {Height}, width: {Width}) is {Area}";
    }                
}
```

 - The `readonly` modifier is necessary on a read-only property. 
 - The compiler doesn't assume get accessors don't modify state, you must declare `readonly` explicitly. 
 - Auto-implemented properties are an exception, the compiler will treat all auto-implemented getters as readonly, so in the above example, there is no need to add the `readonly` modifier to the `Height` and `Width` properties.