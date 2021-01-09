---
PermaID: 100009
Name: Function Pointers
---

# Function Pointers

You have ever worked on C/C++, you will remember the term function pointer. It is a variable that stores the address of a function that can later be called through that function pointer. 

 - Function pointers can be invoked and passed arguments just as in a normal function call.
 - The C# function pointer allows for the declaration of function pointers using the `delegate*` syntax. 
 - It is similar to the syntax used by delegate declarations.

```csharp
unsafe class Example    
{    
  void Example(Action<int> a, delegate*<int, void> f)  
  {    
    a(42);    
    f(42);    
  }    
} 
```  

A `delegate*` type is a pointer type which means it has all of the capabilities and restrictions of a standard pointer type:

## Capabilities

 - Function pointers are only valid in an unsafe context.
 - You can call only those methods which contain a `delegate*` parameter or return type from an unsafe context.
 - It can not be converted to an object.
 - You can not use it as a generic argument.
 - It can implicitly convert from `delegate*` to `void*`.
 - It can explicitly convert from `void*` to `delegate*`.

## Restrictions

 - Custom attributes cannot be applied to a `delegate*` or any of its elements.
 - A `delegate*` parameter cannot be marked as params
 - A `delegate*` type has all of the restrictions of a normal pointer type.
 - Pointer arithmetic cannot be performed directly on function pointer types.

## Target Methods

Method groups will now be allowed as arguments to an address-of (`&`) operator. The type of such an expression will be a `delegate*` which has the equivalent signature of the target method and a managed calling convention. 

It means developers can depend on overload resolution rules to work in conjunction with the address-of operator as shown below.

```csharp
unsafe class Util
{
    public static void Log() 
    {
        Console.WriteLine("Log method without parameters.");
    }

    public static void Log(int val) 
    {
        Console.WriteLine("Log method with 1 int parameter and the value is {0}.", val);
    }

    public static void Use()
    {
        delegate*<void> a1 = &Log;      // Log()
        delegate*<int, void> a2 = &Log; // Log(int val)

        a1();
        a2(4);
    }
}
```
