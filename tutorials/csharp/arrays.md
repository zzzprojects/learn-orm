---
PermaID: 100007
Name: Arrays
---

# Arrays 

An array stores a fixed-size sequential collection of elements of the same type. It is used to store a collection of data of the same type stored at contiguous memory locations.

The array can be declared using the following syntax.

```csharp
datatype[] arrayName;
```

 - **datatype:** Used to specify the type of elements in the array.
 - **[]:** Specifies the size of the array.
 - **arrayName:** Specifies the name of the array.
 
## Declaration and Memory Allocation for Arrays

In C# the arrays have fixed length, which is set at the time of their instantiation and determines the total number of elements. Once the length of an array is set we cannot change it anymore.

### Delare Array

You can declare an array in C# in the following way.

```csharp
int[] myArray;
```

In the above example, the variable myArray is the name of the array, which is of integer type `int[]`. 

 - It means that we declared an array of integer numbers. 
 - With [] we indicate, that the variable, which we are declaring, is an array of elements, not a single element.
 - When we declare an array type variable, it is a reference, which does not have a value, it is because the memory for the elements is not allocated yet.

### Array Creation

In C# we create an array with the help of the keyword `new`, which is used to allocate memory.

```csharp
int[] myArray = new int[6];
```

In this example, we allocate an array with a length of 6 elements of type `int`. In the heap, an area of 6 integer numbers is allocated and they all are initialized with the value 0.

## Array Initialization with Default Values

Before using an element of a given array, it has to be initialized or to have a default value. In C# all variables, including the elements of arrays have a default initial value. This value is either 0 for the numeral types or its equivalent for the non-primitive types (for example null for a reference type and false for the bool type).

You can also set initial values explicitly.

```csharp
int[] myArray = { 1, 2, 3, 4, 5, 6 };
string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday","Thursday", "Friday", "Saturday", "Sunday" };
```

## Access an Array

You can access the array elements directly using their indices. Each element can be accessed through the name of the array and the element's index (a consecutive number) placed in the brackets. We can access given elements of the array both for reading and for writing, which means we can treat elements as variables.

```csharp
myArray[index] = 100;
```

In the example above we set a value of 100 to the element, which is at the position index. The following example will print the value located at the 4th location of an array.

```csharp
Console.WriteLine(myArray[3]);
```

All the examples related to the arrays are available in the `Arrays.cs` file of the source code. Download the source code and try out all the examples for better understanding.
