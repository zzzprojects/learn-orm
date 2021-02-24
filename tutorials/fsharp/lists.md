---
PermaID: 100019
Name: Lists
---

# Lists

A list in F# is an ordered, immutable series of elements of the same type. 

 - It is an ordered collection of related values and is roughly equivalent to a linked list data structure used in many other languages. 
 - For some basic operations, F# provides the `Microsoft.FSharp.Collections.List` module that is imported automatically by F# and is accessible from every F# application.

## Creating and Initializing Lists

There are a variety of ways to create lists in F#, the most straightforward way is to define a list by explicitly listing out the elements, separated by semicolons and enclosed in square brackets.

```csharp
let evenNumbers = [ 0; 2; 4; 6; 8; 10; ]
```

You can also put line breaks between elements, in which case the semicolons are optional.

```csharp
let oddNumber = [
    1
    3
    5
    7
    9 ]
```

The above syntax in more readable code when the element initialization expressions are longer, or when you want to include a comment for each element.

You can also define list elements by using a range indicated by integers separated by the range operator (`..`).

```csharp
let numbers = [ 1 .. 100 ]
```

You can also use a sequence expression to create a list. The following example creates a list of squares of integers from 1 to 10.

```csharp
let listOfSquares = [ for i in 1 .. 10 -> i*i ]
```

## Operators

You can attach elements to a list by using the `::` (cons) operator.

```csharp
let list1 = [1; 2; 3;]

let list2 = 0 :: list1
```

The above code creates `list2` as `[0; 1; 2; 3]`.

You can concatenate lists that have compatible types by using the `@` operator as shown below.

```csharp
let list1 = [1; 2;]
let list2 = [13; 14;]
let list3 = list1 @ list2
```

The above example creates `list3` as `[1; 2; 13; 14]`.

## Properties

The list type supports the following properties.

| Property  | Type              | Description                                                     |
| :---------| :-----------------| :---------------------------------------------------------------|
| Head      | `'T`              | The first element.                                              |
| Empty     | `'T list`        | A static property that returns an empty list of the appropriate type. |
| IsEmpty   | `bool`           | `true` if the list has no elements.                             |
| Item      | `'T`              | The element at the specified index (zero-based).                |
| Length    | `int`            | The number of elements.                                          |
| Tail      | `'T list`        | The list without the first element.                              |

The following code uses different properties of a list type.

```csharp
let mylist = [ 1; 2; 3; 4; 5 ]

Console.WriteLine("mylist.IsEmpty is {0}", mylist.IsEmpty)
Console.WriteLine("mylist.Length is {0}", mylist.Length)
Console.WriteLine("mylist.Head is {0}", mylist.Head)
Console.WriteLine("mylist.Tail.Head is {0}", mylist.Tail.Head)
Console.WriteLine("mylist.Tail.Tail.Head is {0}", mylist.Tail.Tail.Head)
Console.WriteLine("mylist.Item(1) is {0}", mylist.Item(1))
```

It will display the following output.

```csharp
list1.IsEmpty is False
list1.Length is 5
list1.Head is 1
list1.Tail.Head is 2
list1.Tail.Tail.Head is 3
list1.Item(1) is 2
```
