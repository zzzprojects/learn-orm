---
PermaID: 100031
Name: Arrays
---

# Arrays

An array stores a fixed-size sequential collection of elements of the same type. It is used to store a collection of data of the same type stored at contiguous memory locations.

The array can be declared using the following syntax.

```csharp
Dim arrayName As datatype()
```

 - **datatype:** Used to specify the type of elements in the array.
 - **():** Specifies the size of the array.
 - **arrayName:** Specifies the name of the array.

An array is a set of values, which are termed elements, that are logically related to each other. 

## Declaration and Memory Allocation for Arrays

In VB.NET, the arrays have fixed length, which is set at the time of their instantiation and determines the total number of elements.

### Delare Array

You can declare an array in VB.NET in the following way.

```csharp
Dim myArray1 As Integer()
```

In the above example, the variable myArray is the name of the array, which is of integer type `Integer()`. 

 - It means that we declared an array of integer numbers. 
 - With `()` we indicate, that the variable, which we are declaring, is an array of elements, not a single element.
 - When we declare an array type variable, it is a reference, which does not have a value, it is because the memory for the elements is not allocated yet.

### Array Creation

In VB.NET we create an array with the help of the keyword `new`, which is used to allocate memory.

```csharp
Dim myArray2 As Integer() = New Integer(5) {}
```

You can specify the size when the array is declared.

```csharp
Dim myArray3(5) As Double
```

In the above examples, we allocate an array with a length of 6 elements (it specifies 5 as the last index) of type `int`. 

## Array Initialization with Default Values

Before using an element of a given array, it has to be initialized or to have a default value. In C# all variables, including the elements of arrays have a default initial value. This value is either 0 for the numeral types or its equivalent for the non-primitive types (for example null for a reference type and false for the bool type).

You can also set initial values explicitly.

```csharp
Dim myArray4 As Integer() = {1, 2, 3, 4, 5, 6}
Dim daysOfWeek As String() = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"}
```

If you have an existing array, you can redefine its size by using the `ReDim` statement. You can specify that the `ReDim` statement keeps the values that are in the array, or you can specify that it creates an empty array. 

The following example shows different uses of the `ReDim` statement to modify the size of an existing array.

```csharp
Dim myArray4 As Integer() = {1, 2, 3, 4, 5, 6}

' Assign a new array size and retain the current values.
ReDim Preserve myArray4(20)

' Assign a new array size and retain only the first five values.
ReDim Preserve myArray4(4)

' Assign a new array size and discard all current element values.
ReDim myArray4(15)
```

## Access an Array

You can access the array elements directly using their indices. Each element can be accessed through the name of the array and the element's index (a consecutive number) placed in the brackets. We can access given elements of the array both for reading and for writing, which means we can treat elements as variables.

```csharp
myArray4(3) = 100
```

In the example above we set a value of 100 to the element, which is at the position index. The following example will print the value located at the 4th location of an array.

```csharp
Console.WriteLine(myArray4(3))
```

The following example shows some statements that store and retrieve values in arrays.

```csharp
' Create a 10-element integer array.
Dim numbers(9) As Integer
Dim value As Integer = 2

' Write values to it.
For ctr As Integer = 0 To 9
    numbers(ctr) = value
    value *= 2
Next

' Read and sum the array values.  
Dim sum As Integer
For ctr As Integer = 0 To 9
    sum += numbers(ctr)
Next
Console.WriteLine($"The sum of the values is {sum:N0}")
```
