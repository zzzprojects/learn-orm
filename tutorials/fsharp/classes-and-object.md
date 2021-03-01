---
PermaID: 100033
Name: Classes and Object
---

# Classes and Object

## What is Class?

Classes are types that represent objects that can have properties, methods, and events. Classes represent the fundamental description of .NET object types; the class is the primary type concept that supports object-oriented programming in F#.

The basic syntax of the class declaration is as follows.

```csharp
type [access-modifier] type-name [type-params] [access-modifier] ( parameter-list ) [ as identifier ] =
    [ class ]
        [ inherit base-type-name(base-constructor-args) ]
        [ let-bindings ]
        [ do-bindings ]
        member-list
        ...
    [ end ]

// Mutually recursive class definitions:
type [access-modifier] type-name1 ...
and [access-modifier] type-name2 ...
...
```

 - **`type-name`:** It is any valid identifier. 
 - **`type-params`:** Describes optional generic type parameters. It consists of type parameter names and constraints enclosed in angle brackets (`<` and `>`). 
 - **`parameter-list`:** Describes constructor parameters. The first access modifier pertains to the type; the second pertains to the primary constructor. In both cases, the default is `public`.
 - **`inherit`:** You specify the base class for a class by using the `inherit` keyword. You must supply arguments, in parentheses, for the base class constructor.
 - **`let`:** You declare fields or function values that are local to the class by using `let` bindings. 
 - **`do`:** The `do-bindings` section includes code to be executed upon object construction.
 - **`member-list`:** Consists of additional constructors, instance and static method declarations, interface declarations, abstract bindings, and property and event declarations.
 - **`identifier`:** It is used with the optional `as` keyword gives a name to the instance variable, or self identifier, which can be used in the type definition to refer to the instance of the type.
 - **`class` and `end`:** The `class` and `end` mark the start and end of the definition are optional.

The following code shows a very simple class declaration.

```csharp
type Author (firstName, lastName, age) =
    member this.FirstName = firstName
    member this.LastName = lastName
    member this.Age = age
```

## What is Object?

The object is an instance of a class to access the defined properties and methods. It is a concrete entity based on a class and is created at runtime. You can create an object using the `new` keyword followed by the name of the class. 

```csharp
type Author (firstName, lastName, age) =
    member this.FirstName = firstName
    member this.LastName = lastName
    member this.Age = age

let author1 = new Author("Mark", "Upston", 25)
```

In F#, the constructor is considered to be just another function, so you can also call the constructor function without using the `new` keyword.

```csharp
let author2 = Author("Adrian", "Christian", 31)
```

## Initialize and Display Data through Method

You can also initialize and display data through the method as shown below.
 
```csharp
type Author() =
 class
     let mutable firstName = ""
     let mutable lastName = ""
     let mutable age = 0
 
     member x.Insert(fName, lName, aAge) =   
         firstName <- fName  
         lastName <- lName
         age <- aAge
 
     member x.Display = Console.WriteLine(firstName + " " + lastName + " (" + age.ToString() + ")") 
 end

let author1 = new Author()
author1.Insert("Mark", "Upston", 25)
author1.Display
```
