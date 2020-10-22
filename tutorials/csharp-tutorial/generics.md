---
PermaID: 100038
Name: Generics
---

# Generics

In C#, generics introduce the concept of type parameters which make it possible to design classes and methods that defer the specification of one or more types until the class or method is declared and instantiated.

A generic type is declared by specifying a type parameter `T` in angle brackets which can be used as a type of field, properties, method parameters, return types, and delegates, etc. The following example, define a generic class.

```cshap
class MyClass<T>
{
    public T Val { get; set; }
}
```

In the above code, `MyClass` is a generic class and `T` is a type parameter. The `Val` is a generic property because we have used a type parameter `T` as its type instead of the specific data type.

You can create an instance of generic classes by specifying the data type in angle brackets. Let's consider the following code.

```csharp
MyClass<int> myClassInt = new MyClass<int>();
MyClass<string> myClassString = new MyClass<string>();
MyClass<DateTime> myClassDateTime = new MyClass<DateTime>();

myClassInt.Val = 34;                       
myClassString.Val = "This is a C# Tutorial";
myClassDateTime.Val = DateTime.Today;

Console.WriteLine("Type: {0}, \t Value: {1}", myClassInt, myClassInt.Val);
Console.WriteLine("Type: {0}, \t Value: {1}", myClassString, myClassString.Val);
Console.WriteLine("Type: {0}, \t Value: {1}", myClassDateTime, myClassDateTime.Val);
```

In the above code, you can see that we have created three instances of the `MyClass` for different data types i.e. integer, string, and date-time. When the instances are created `T` will be replaced with a specified type, wherever `T` is used in the entire class at compile-time. The three instances of `MyClass` have been created by replacing `T` with `int`, `string`, and `DateTime` data types, and these objects are used to store `int`, `string`, and `DateTime` values respectively.

Let's run the above code and you will see the following code.

```csharp
Type: CSharpTutorialDemo.Generics+MyClass`1[System.Int32],       Value: 34
Type: CSharpTutorialDemo.Generics+MyClass`1[System.String],      Value: This is a C# Tutorial
Type: CSharpTutorialDemo.Generics+MyClass`1[System.DateTime],    Value: 10/22/2020 12:00:00 AM
```

## Generic Collections

In C#, the generic collections represent the `System.Collections.Generic` namespace which contains interfaces and classes that define generic collections, which allow users to create strongly typed collections that provide better type safety and performance than non-generic strongly typed collections.

 - It will enforce a type of safety so you can store only the elements which are having the same data type.
 - It provides a generic implementation of standard data structures like linked lists, stacks, queues, and dictionaries. 
 - These are type-safe because you can store only those items that are type-compatible with the type of collection in a generic collection.

The following table lists some of the frequently used classes in the `System.Collections.Generic` namespace.

| Class           | Description                                                                |
|:----------------|:---------------------------------------------------------------------------|
| Dictionary      | Represents a collection of keys and values.                                |
| List            | Represents a strongly typed list of objects that can be accessed by index. Provides methods to search, sort, and manipulate lists. |
| Queue           | Represents a first-in, first-out (FIFO) collection of objects.                |
| SortedList      | Represents a collection of key/value pairs that are sorted by the keys and are accessible by key and by index. |
| Stack           | Represents a last-in, first-out (LIFO) collection of objects.                |
| HashSet         | It is an unordered collection of unique elements. It prevents duplicates from being inserted into the collection. |
| LinkedList      | It allows fast inserting and removing of elements. It implements a classic linked list. |

The following example shows how to create and initialize a `List` and how to display its values.

```csharp
List<Customer> customers = new List<Customer>();
customers.Add(new Customer { Id = 1, Name = "John" });
customers.Add(new Customer { Id = 2, Name = "Mark"});
customers.Add(new Customer { Id = 3, Name = "Stella"});

foreach (var customer in customers)
{
    Console.WriteLine("{0}, {1}", customer.Id, customer.Name);
}
```

Let's run the above code and you will see the following code.

```csharp
1, John
2, Mark
3, Stella
```

In C#, many of the generic collection types are direct analogs of non-generic types. 

 - `Dictionary<TKey,TValue>` is a generic version of `Hashtable`, it uses the generic structure `KeyValuePair<TKey,TValue>` for enumeration instead of `DictionaryEntry`. 
 - `List<T>` is a generic version of `ArrayList`. 
 - There are generic `Queue<T>` and `Stack<T>` classes that correspond to the nongeneric versions. 
 - There are generic and nongeneric versions of `SortedList<TKey, TValue>`, both versions are hybrids of a dictionary and a list. 
 - The `SortedDictionary<TKey, TValue>` generic class is a pure dictionary and has no nongeneric counterpart. 
 - The `LinkedList<T>` generic class is a true linked list and has no nongeneric counterpart.

For more information, visit the following 

 - Generics - [https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/)
 - Generic Collections - [https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic)

All the examples related to the generics and generic collections are available in the `Generics.cs` file of the source code. Download the source code and try out all the examples for better understanding.
