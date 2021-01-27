---
PermaID: 100023
Name: List
---

# List

The `List` class is a collection and defined in the `System.Collections.Generic` namespace and it provides the methods and properties like other `Collection` classes such as `Add`, `Insert`, `Remove`, etc.

 - It is used to store generic types of collections objects. By using a generic class on the list, we can store one type of object. 
 - The `List` size can be dynamically different depending on the need of the application, such as adding, searching, or inserting elements into a list. 

The following example shows how to create and initialize a `List` and how to display its values.

```csharp
Private Sub Example1()
    Dim customers As List(Of Customer) = New List(Of Customer)()
    customers.Add(New Customer With {
        .Id = 1,
        .Name = "John"
    })
    customers.Add(New Customer With {
        .Id = 2,
        .Name = "Mark"
    })
    customers.Add(New Customer With {
        .Id = 3,
        .Name = "Stella"
    })

    For Each customer In customers
        Console.WriteLine("{0}, {1}", customer.Id, customer.Name)
    Next
End Sub
```

Let's run the above code and you will see the following output.

```csharp
1, John
2, Mark
3, Stella
```

The following example demonstrates several properties and methods of the `List` generic class of type `String`.

```csharp
Public Sub Example2()
    Dim dinosaurs As List(Of String) = New List(Of String)()
    Console.WriteLine(vbLf & "Capacity: {0}", dinosaurs.Capacity)
    dinosaurs.Add("Tyrannosaurus")
    dinosaurs.Add("Amargasaurus")
    dinosaurs.Add("Mamenchisaurus")
    dinosaurs.Add("Deinonychus")
    dinosaurs.Add("Compsognathus")
    Console.WriteLine()

    For Each dinosaur As String In dinosaurs
        Console.WriteLine(dinosaur)
    Next

    Console.WriteLine(vbLf & "Capacity: {0}", dinosaurs.Capacity)
    Console.WriteLine("Count: {0}", dinosaurs.Count)
    Console.WriteLine(vbLf & "Contains(""Deinonychus""): {0}", dinosaurs.Contains("Deinonychus"))
    Console.WriteLine(vbLf & "Insert(2, ""Compsognathus"")")
    dinosaurs.Insert(2, "Compsognathus")
    Console.WriteLine()

    For Each dinosaur As String In dinosaurs
        Console.WriteLine(dinosaur)
    Next

    Console.WriteLine(vbLf & "dinosaurs[3]: {0}", dinosaurs(3))
    Console.WriteLine(vbLf & "Remove(""Compsognathus"")")
    dinosaurs.Remove("Compsognathus")
    Console.WriteLine()

    For Each dinosaur As String In dinosaurs
        Console.WriteLine(dinosaur)
    Next

    dinosaurs.TrimExcess()
    Console.WriteLine(vbLf & "TrimExcess()")
    Console.WriteLine("Capacity: {0}", dinosaurs.Capacity)
    Console.WriteLine("Count: {0}", dinosaurs.Count)
    dinosaurs.Clear()
    Console.WriteLine(vbLf & "Clear()")
    Console.WriteLine("Capacity: {0}", dinosaurs.Capacity)
    Console.WriteLine("Count: {0}", dinosaurs.Count)
End Sub
```

Let's run the above code and you will see the following output.

```csharp
Capacity: 0

Tyrannosaurus
Amargasaurus
Mamenchisaurus
Deinonychus
Compsognathus

Capacity: 8
Count: 5

Contains("Deinonychus"): True

Insert(2, "Compsognathus")

Tyrannosaurus
Amargasaurus
Compsognathus
Mamenchisaurus
Deinonychus
Compsognathus

dinosaurs[3]: Mamenchisaurus

Remove("Compsognathus")

Tyrannosaurus
Amargasaurus
Mamenchisaurus
Deinonychus
Compsognathus

TrimExcess()
Capacity: 5
Count: 5

Clear()
Capacity: 5
Count: 0
```
