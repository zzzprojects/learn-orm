---
PermaID: 100002
Name: Pattern Matching Improvements
---

# Pattern Matching Improvements

## What is Pattern Matching?

Pattern matching brings power to some existing language operators and statements. Pattern matching provides a more concise syntax for algorithms you already use today. You already create pattern matching algorithms using existing syntax.

In C# 9.0, the .NET development team is considering some enhancements to pattern matching that have a natural synergy and work well to address several common programming problems.

## Relational Patterns

Relational patterns permit the programmer to express that an input value must satisfy a relational constraint when compared to a constant value.

```csharp
public static LifeStage LifeStageAtAge(int age) => age switch
{
    < 0 =>  LifeStage.Prenatal,
    < 2 =>  LifeStage.Infant,
    < 4 =>  LifeStage.Toddler,
    < 6 =>  LifeStage.EarlyChild,
    < 12 => LifeStage.MiddleChild,
    < 20 => LifeStage.Adolescent,
    < 40 => LifeStage.EarlyAdult,
    < 65 => LifeStage.MiddleAdult,
    _ =>    LifeStage.LateAdult,
};
```

Relational patterns support the relational operators `<`, `<=`, `>`, and `>=` on all the built-in types that support such binary relational operators with two operands of the same type in an expression. 

## Pattern Combinators

Pattern combinators permit matching both of two different patterns using `and`, either of two different patterns using `or`, or the negation of a pattern using `not`.

```csharp
if (customer is not null)
{
    Console.WriteLine(customer.Name);
}
```

You can see that it clearly expresses that one is checking for a non-null value. The `and` and `or` combinators will be useful for testing ranges of values.

```csharp
bool IsLetter(char c) => c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z');
```

These combinators can be used in any context in which a pattern is expected, including nested patterns, the `is` pattern expression, the `switch` expression, and the pattern of a `switch` statement's `case` label.
