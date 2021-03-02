---
PermaID: 100020
Name: Sequences
---

# Sequences

A sequence is a logical series of elements all of one type. It is similar to a list, and both are used to represent an ordered collection of values. 

 - However, unlike lists, elements in a sequence are computed as they are needed rather than computed all at once. 
 - It gives sequences some interesting properties, such as the capacity to represent infinite data structures.

## Why Sequences?

 - Sequences are particularly useful when you have a large, ordered collection of data but do not necessarily expect to use all of the elements. 
 - Individual sequence elements are computed only as required, so a sequence can provide better performance than a list in situations in which not all the elements are used.

## Sequence Expressions

A sequence expression is an expression that evaluates a sequence. Sequence expressions can take several forms. The following example shows the simplest form which specifies a range.

```csharp
let seq1 = seq { 1 .. 10 }
```

The above line creates a sequence that contains 10 elements, including endpoints 1 and 10.

You can also specify an increment/decrement between two double periods (`..`). The following code creates the sequence of multiples of 2.

```csharp
let seq2 = seq { 0 .. 2 .. 20 }
```

Sequence expressions are made up of F# expressions that produce values of the sequence. You can also generate values programmatically.

```csharp
let seq3 = seq { for i in 1 .. 10 -> i * i }
```

The `->` operator allows you to specify an expression whose value will become a part of the sequence. You can only use `->` if every part of the code that follows it returns a value.

You can specify the `do` keyword with an optional `yield` that follows.

```csharp
let seq4 = seq { for i in 1 .. 10 do yield i * i }

// The 'yield' is implicit and doesn't need to be specified in most cases.
let seq5 = seq { for i in 1 .. 10 do i * i }
```

