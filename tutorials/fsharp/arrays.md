---
PermaID: 100025
Name: Arrays
---

# Arrays

Arrays are fixed-size, zero-based, mutable collections of consecutive data elements that are all of the same types.

There are various ways to create an array. The simplest way is to list consecutive values between `[|` and `|]` and separated by semicolons (`;`) as shown below.

```csharp
let array1 = [| 1; 2; 3; 4; 5 |]
```

You can also put each element on a separate line and in this case, the semicolon separator is optional.

```csharp
let array2 =
    [|
        'a'
        'b'
        'c'
     |]
```

The type of array elements is inferred from the literals used and must be consistent. If you specify different types in an array as shown below.

```csharp
let array3 = [| 'a'; 2; 3 |]
```

It will give you the following error.

```csharp
Error FS0001: All elements of an array must be of the same type as the first element, which here is 'char'. This element has type 'int'.
```

You can also use sequence expressions to create arrays. The following example creates an array of cubes of integers from 1 to 5.

```csharp
let array4 = [| for i in 1 .. 10 -> i * i * i |]
```

You can create and initialize all elements of an array to zero by using `Array.zeroCreate`.

```csharp
let array5 : int array = Array.zeroCreate 5
```

It will create an array of 5 and initialize it to 0.

You can access array elements by using a dot operator (`.`) and brackets (`[` and `]`).

```csharp
let val1 = array4.[0]
let val2 = array4.[1]
```

You can also access array elements by using slice notation, which enables you to specify a subrange of the array.

```csharp
// Accesses elements from 0 to 3.
let ar1 = array4.[0..3]

// Accesses elements from the beginning of the array to 4.
let ar2 = array4.[..4]

// Accesses elements from 3 to the end of the array.
let ar3 = array4.[3..]
```

## Array Types and Modules

The type of all F# arrays is the .NET Framework type `System.Array`. Therefore, F# arrays support all the functionality available in `System.Array`.

The following are the most commonly used functions in the `FSharp.Collections.Array` module.

| Function                    | Description                                                                     |
| :---------------------------| :-------------------------------------------------------------------------------|
| Array.append                | Builds a new array that contains the elements of the first array followed by the elements of the second array. |
| Array.average               | Returns the average of the elements in the array. |
| Array.concat                | Builds a new array that contains the elements of each of the given sequence of arrays. |
| Array.contains              | Tests if the array contains the specified element. |
| Array.copy                  | Builds a new array that contains the elements of the given array. |
| Array.create                | Creates an array whose elements are all initially the given value. |
| Array.distinct              | Returns an array that contains no duplicate entries according to generic hash and equality comparisons on the entries. If an element occurs multiple times in the array then the later occurrences are discarded. |
| Array.empty                 | Returns an empty array of the given type.  |
| Array.exists                | Tests if any element of the array satisfies the given predicate. |
| Array.fill                  | Fills a range of elements of the array with the given value. |
| Array.find                  | Returns the first element for which the given function returns `true`. Raise KeyNotFoundException if no such element exists. |
| Array.findIndex             | Returns the index of the first element in the array that satisfies the given predicate. Raise KeyNotFoundException if none of the elements satisfy the predicate. |
| Array.get                   | Gets an element from an array. |
| Array.head                  | Returns the first element of the array. |
| Array.init                  | Creates an array given the dimension and a generator function to compute the elements. |
| Array.isEmpty               | Returns true if the given array is empty, otherwise false. |
| Array.item                  | Gets an element from an array.   |
| Array.iter                  | Applies the given function to each element of the array. |
| Array.iteri                 | Applies the given function to each element of the array. The integer passed to the function indicates the index of the element. |
| Array.length                | Returns the length of an array. You can also use property arr.Length. |
| Array.rev                   | Returns a new array with the elements in reverse order. |
| Array.set                   | Sets an element of an array. |
| Array.singleton             | Returns an array that contains one item only. |
| Array.skip                  | Builds a new array that contains the elements of the given array, excluding the first N elements. |
| Array.sort                  | Sorts the elements of an array, returning a new array. Elements are compared using `Operators.compare`. |
| Array.sortDescending        | Sorts the elements of an array, in descending order, returning a new array. Elements are compared using Operators.compare. |
| Array.splitAt               | Splits an array into two arrays, at the given index. |
| Array.splitInto             | Splits the input array into at most count chunks. |
| Array.sub                   | Builds a new array that contains the given subrange specified by starting index and length. |
| Array.take                  | Returns the first N elements of the array. | 
| Array.toList                | Builds a list from the given array.       | 
| Array.toSeq                 | Builds a sequence from the given array. | 

The following example uses some of these functions.

```csharp
let arrayName = Array.create 5 0  
Array.set arrayName 1 12            // Set element to given index using set function  

for i in [0..arrayName.Length-1] do  
   printfn "%d" arrayName.[i]   
```

## Multidimensional Arrays

F# allows us to create a multidimensional array. The multidimensional array is also known as the array of array. It can be 2 dimensional, 3 dimensional, or more.

 - In F#, a multidimensional array can be created, but there is no syntax for writing a multidimensional array. 
 - F# use array2D operator to create a two-dimensional array from a sequence of sequences of array elements. 
 - The sequences can be array or list.

The following example is using array2D operator to create a 2D array.

```csharp
let arr = array2D [ [0; 0]; [0; 1];[1; 0]; [1; 1]]  
for i = 0 to 3 do  
 for j = 0 to 1 do  
   printf "%d " arr.[i,j]  
 printf "\n"  
```
