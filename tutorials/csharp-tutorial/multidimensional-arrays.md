---
PermaID: 100008
Name: Multidimensional Arrays
---

# Multidimensional Arrays

The one-dimensional arrays are known also as vectors in mathematics, but often we need arrays with more than one dimension. For example, we can easily represent the standard chessboard as a two-dimensional array with size 8 by 8.

## Declare Multidimensional Arrays

We declare a one-dimensional array of integer numbers using `int[]`, and we declare a two-dimensional with `int[,]` as shown below.

```csharp
int[,] twoDimensionalArray;
```

We will call it a two-dimensional because they have two dimensions. In general arrays with more than one dimension are known as multidimensional arrays. In mathematical terms, they are also known as matrices.

We can declare three-dimensional arrays by adding one more dimension as shown below.

```csharp
int[,,] threeDimensionalArray;
```

In theory, there is no limit for an array dimension, but in practice, we do not use many arrays with more than two dimensions therefore we will focus on two-dimensional arrays.

## Memory Allocation to Multidimensional Arrays

We are allocating memory for multidimensional arrays by using the `new` keyword and for each dimension, we set a length in the brackets as shown below.

```csharp
int[,] intMatrix = new int[3, 4];
float[,] floatMatrix = new float[8, 2];
string[,,] stringCube = new string[5, 5, 5];
```

In this example, `intMatrix` is a two-dimensional array with 3 elements of type int[] and each of those 3 elements has a length of 4. 

## Initialization of Multidimensional Arrays

We initialize two-dimensional arrays in the same way as we initialize one-dimensional arrays. We can list the element values straight after the declaration.

```csharp
int[,] matrix =
{
    {1, 2, 3, 4}, // row 0 values
    {5, 6, 7, 8}, // row 1 values
};
// The matrix size is 2 x 4 (2 rows, 4 cols)
```

In the above example, we initialize a two-dimensional array of type integer with a size of 2 rows and 4 columns. 

 - In the outer brackets we place the elements of the first dimension, i.e. the rows of the array. 
 - Each row contains a one-dimensional array, which we know how to initialize.

## Accessing Multidimensional Arrays

In two dimensional array, we access each element by using two indices i.e. one for the rows and one for the columns. Multidimensional arrays have different indices for each dimension.

Let's examine the next example.

```csharp
int[,] myArray =
{
    {1, 2, 3, 4},
    {5, 6, 7, 8},
};
```

The `myArray` has 8 elements, stored in 2 rows and 4 columns. Each element can be accessed in the following way.

```csharp
myArray[0, 0] myArray[0, 1] myArray[0, 2] myArray[0, 3]
myArray[1, 0] myArray[1, 1] myArray[1, 2] myArray[1, 3]
```

The following example assigns a value to a particular array element.

```csharp
myArray[2, 1] = 25;
```

Similarly, the following example gets the value of a particular array element and assigns it to variable `val`.

```
int val = myArray[2, 1];
```