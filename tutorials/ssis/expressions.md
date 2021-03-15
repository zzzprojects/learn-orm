---
PermaID: 100022
Name: Expressions
---

# Expressions

An expression is a combination of symbols-identifiers, literals, functions, and operators that yields a single data value. 

 - Simple expressions can be a single constant, variable, or function. 
 - Expressions are complex, using multiple operators and functions and referencing multiple columns and variables. 

In Integration Services, expressions can be used: 

 - To define conditions for `CASE` statements 
 - To create and update values in data columns
 - To assign values to variables
 - To update or populate properties at run time 
 - To define constraints in precedence constraints 
 - To provide the expressions used by the For Loop container.

Expressions are based on an expression language and the expression evaluator. The expression evaluator parses the expression and determines whether the expression follows the rules of the expression language. 

## Components that Use Expressions

The following elements in Integration Services can use expressions:

### Conditional Split Transformation

The Conditional Split transformation implements a decision structure based on expressions to direct data rows to different destinations. 

 - Expressions used in a **Conditional Split** transformation must evaluate to true or false. 
 - For example, rows that meet the condition in the expression `"Column1 > Column2"` can be routed to a separate output.

### Derived Column Transformation

 - The **Derived Column** transformation uses values created by using expressions either to populate new columns in a data flow or to update existing columns. 
 - For example, the expression `Column1 + " ABC"` can be used to update a value or to create a new value with the concatenated string.

### Variables

Variables use an expression to set their value. For example, `GETDATE()` sets the value of the variable to the current date.

### Precedence Constraints

Precedence constraints can use expressions to specify the conditions that determine whether the constrained task or container in a package runs. 

 - Expressions used in a precedence constraint must evaluate as `true` or `false`. 
 - For example, the expression `@A > @B` compares two user-defined variables to determine whether the constrained task runs.

### For Loop

The **For Loop** container can use expressions to build the initialization, evaluation, and incrementing statements that the looping structure uses. For example, the expression `@Counter = 1` initializes the loop counter.

## Implicit Data Conversion

The implicit conversion of a data type occurs when the expression evaluator automatically converts the data from one data type to another. 

 - For example, if a `smallint` is compared to an `int`, the `smallint` is implicitly converted to `int` before the comparison is performed.
 - The expression evaluator cannot perform implicit data conversion when the arguments and operands have incompatible data types. 
 - Also, the expression evaluator cannot implicitly convert any value to a Boolean. 
 - Instead, the arguments and operands must be explicitly converted by using the cast operator. 

