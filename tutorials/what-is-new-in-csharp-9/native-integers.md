---
PermaID: 100008
Name: Native Integers
---

# Native Integers

The native-sized integers are designed to be an integer that allows us to use 32 bits on 32-bit systems, and 64 bits on 64-bit systems.

 - It supports native-sized signed and unsigned integer types.
 - The motivation here is for interop scenarios and low-level libraries.
 - The identifiers `nint` and `nuint` are new contextual keywords that represent native signed and unsigned integer types. 
 - The `nint` and `nuint` are represented by the underlying types `System.IntPtr` and `System.UIntPtr` with compiler surfacing additional conversions and operations for those types as native ints.

The identifiers are only treated as keywords when name lookup does not find a viable result at that program location.

```csharp
int x = 3;
nint y = 3;
nint z = y + 1;
z--;

var name1 = typeof(nint);              // System.IntPtr
var name2 = typeof(nuint);             // System.UIntPtr
var name3 = (x + 1).GetType();         // System.Int32
var name4 = (y + 1).GetType();         // System.IntPtr
var name5 = (x + y).GetType();         // System.IntPtr
                                       
long v = 10;                           
var name6 = (x + v).GetType();         // System.Int64

var result1 = nint.Equals(x, y);       // False
var result2 = nint.Equals((nint)x, y); // True
var result3 = y + 1 > x;               // True;
var result4 = y - 1 == x;              // False
```

As you can see that when you add an `int` to a `nint` the result is a `nint`, but if you add a `long` to a `nint` the result will be a `long`. This is because the native depending on the platform could be a 32-bit integer or a 64-bits integer.

An arrays support native-sized signed type as an index as shown below.

```csharp
string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

for (nint i = 0; i < 7; i++)
{
    Console.WriteLine(daysOfWeek[i]);
}
```

## Constants

Constant expressions may be of type `nint` or `nuint`. There is no direct syntax for native `int` literals. 

 - The `nint` constants are in the range [ `int.MinValue`, `int.MaxValue` ]
 - The `nuint` constants are in the range [ `uint.MinValue`, `uint.MaxValue` ].
 - There are no `MinValue` or `MaxValue` fields on `nint` or `nuint` because, other than `nuint.MinValue`, those values cannot be emitted as constants.
