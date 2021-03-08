---
PermaID: 100034
Name: Constructors
---

# Constructors

The constructor is a code that creates an instance of the class type. Constructors for classes work differently in F# than they do in other .NET languages. 

There are two kinds of constructors. One is the primary constructor, whose parameters appear in parentheses just after the type name. 

## Primary Constructor

 - In F# class, there is always a primary constructor whose arguments are described in the `parameter-list` that follows the type name and whose body consists of the `let` and `let rec` bindings at the start of the class declaration and the do bindings that follow. 
 - The arguments of the primary constructor are in scope throughout the class declaration.

The following code shows a very simple class declaration.

```csharp
type Author (firstName, lastName, age) =
    member this.FirstName = firstName
    member this.LastName = lastName
    member this.Age = age
```

 - In the F#, the primary constructor is not a separate method but is embedded into the class declaration itself. 
 - The class declaration has the same parameters as the constructor, and the parameters automatically become immutable private fields that store the original values that were passed in.

### Specify Types for Parameters in the Constructor

In general, type inference from usage will probably force the values to be strings and int, etc., but if you do need to specify the types explicitly, you can do so in the usual way with a colon followed by the type name.

```csharp
type Author (firstName:string, lastName:string, age:int) =
    member this.FirstName = firstName
    member this.LastName = lastName
    member this.Age = age
```

The following example declares a class that contains a primary constructor.

```csharp
type Author (firstName:string, lastName:string, age:int) =
    member this.FirstName = firstName
    member this.LastName = lastName
    member this.Age = age

let author1 = new Author("Mark", "Upston", 25)
```

## Addition Constructor

You can specify additional constructors by using the `new` keyword. 

The following code defines an additional constructor using the `new` keyword.

```csharp
type Point3D =
    class
       val X : int
       val Y : int
       val Z : int
       new(x, y, z) = { X = x; Y = y; Z = z }
    end

let point = new Point3D(1, 2, 3)
```

All those fields defined by using the val keyword can also be initialized in additional constructors by using record expressions as shown in the above code.
