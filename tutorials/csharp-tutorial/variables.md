---
PermaID: 100002
Name: Variables
---

# Variables

## What Is a Variable?

A variable is like a container in a C# program in which a data value can be stored inside the computer's memory. The stored value can be referenced using the variable's name.

## Variable Naming Conventions

The programmer can choose any name for a variable as per C# naming conventions, such as; 

 - Variable names contain letters, digits, and underscore.
 - It must begin with a letter, underscore, or @ character. 
 - The C# keywords must be avoided. 
 - It is good practice to choose meaningful names to make the code more comprehensible.
 - Variable names are case-sensitive, so variables named `num`, `Num`, and `NUM` are treated as three individual variables. 
 - Traditionally, C# variable names are created in all lowercase characters.
 - Character values of the `char` data type must be enclosed in single quotes, but character strings of the `string` data type must be enclosed between double-quotes.
 - The decimal data type is preferred for the storage of monetary values.

## Variable Declaration

To create a new variable in a program it must be declared, specifying the type of data it may contain and its chosen name. The following is a variable declaration syntax.

```csharp
data-type variable-name;
```

### Examples

The following `number` variable of `int` type is declared in the first line and then initialized in the next line.

```csharp
int number;      // Declared number variable
number = 100 ;   // Initialized.
```

The following `body` variable of the `float` type is declared and initialized simultaneously.

```csharp
float body = 98.6f ; // Declared and initialized.
```

## Multiple Variable Declaration

Multiple variables of the same data type can be created in a single declaration as a comma-separated list.

```csharp
data-type variable-name1 , variable-name2 , variable-name3;
```

### Examples

The following multiple variables of the `int` type are created in a single declaration.

```csharp
int a, b, c;
a = 100;
b = 200;
c = 300;
```