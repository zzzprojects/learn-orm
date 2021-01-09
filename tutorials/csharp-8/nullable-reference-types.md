---
PermaID: 100006
Name: Nullable Reference Types
---

# Nullable Reference Types

A reference type refers to an object that is on the heap. The value is `null` when there is no object to refer to. In some cases, you can expect a `null` value, but the often `null` value is problematic that leads to exceptions.

 - Mostly developers assumed that reference type is meant to accept both `null` and non-null.
 - There was not any explicit handling required and unfortunately it is one of the reasons for `NullReferenceException.

In C# 8.0, nullable reference types and non-nullable reference types are introduced that enable you to make important statements about the properties for reference type variables.

## Rules for Non-nullable Reference Type

When a variable is not supposed to be null, the compiler enforces some rules to make sure that it is safe to dereference that variable without checking that it is not a `null`.

 - The variable must be initialized to a non-null value.
 - The variable can never be assigned the `null` value.

## Rules for Nullable Reference Type

When a variable can be a `null`, in this case, the compiler enforces different rules to make sure that you have correctly checked for a `null` reference.

 - The variable may only be dereferenced when the compiler can guarantee that the value is not `null`.
 - It may be initialized with the default `null` value and may be assigned the value `null` in other code.

C# 8.0 allows you to specify whether a variable should be `null`, and when it cannot be null. Based on these annotations, the compiler will warn you when you are potentially using a null reference or passing a null reference to a function that will not accept it.

The nullable annotation context and nullable warning context can be set for a project using the `<Nullable>enable</Nullable>` element in your `.csproj` file. 

```csharp
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp3.0</TargetFramework>
    <LangVersion>8.0</LangVersion>
    <Nullable>enable</Nullable>
  </PropertyGroup>
</Project>
```

You can also use directives to set the nullable context anywhere in your project file. To enable per file, you can use `#nullable enable` where you want to enable the functionality and `#nullable disable` where you want to disable it.

By default, everything is non-nullable and if you want to declare a type as accepting null values, you need to add `?` after the `type`.

Let's consider the following simple example without a `#nullable` annotations context. 

```csharp
string Name = "Mark";
string? Autobiography = null;    // Warning CS8632  The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
string Address = null;
```

You can see a warning because the `#nullable` annotations context is disabled by default, let's add the `#nullable enable` at the start of the file.

```csharp
string Name = "Mark";
string? Autobiography = null;    
string Address = null;          // Warning CS8600  Converting null literal or possible null value to non - nullable type.
```

Now you can see that the first warning disappears but now you will see another warning of converting the `null` value to a non-nullable type.


Let's take a look into another example where a nullable reference is passed as a parameter.

```csharp
private static string? ToNiceString(string? value)
{
    return value.Replace(" ", "-"); // warning CS8602: Dereference of a possibly null reference
}
```

You will see a warning of the dereference of a possibly null reference.