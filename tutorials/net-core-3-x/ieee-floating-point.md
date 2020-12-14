---
PermaID: 100020
Name: IEEE Floating Point
---

# IEEE Floating Point

Floating-point APIs are being updated to comply with IEEE 754-2008 revision. The goal of these changes is to expose all required operations and ensure that they're behaviorally compliant with the IEEE spec. 

In .NET Core 3.0, the following fixes are included related to parsing and formatting. 

 - Correctly parse and round inputs of any length.
 - Correctly parse and format negative zero.
 - Correctly parse Infinity and NaN by doing a case-insensitive check and allowing an optional preceding + where applicable.

The following new `System.Math` APIs are also included.

## [BitIncrement(Double)](https://docs.microsoft.com/en-us/dotnet/api/system.math.bitincrement?view=net-5.0#System_Math_BitIncrement_System_Double_) and [BitDecrement(Double)](https://docs.microsoft.com/en-us/dotnet/api/system.math.bitdecrement?view=net-5.0#System_Math_BitDecrement_System_Double_)

Corresponds to the `nextUp` and `nextDown` IEEE operations. 

 - They return the next largest or smallest floating-point number that compares greater or lesser than the input respectively. 
 - For example, `Math.BitIncrement(0.0)` would return `double.Epsilon`.

## [MaxMagnitude(Double, Double)](https://docs.microsoft.com/en-us/dotnet/api/system.math.maxmagnitude?view=net-5.0#System_Math_MaxMagnitude_System_Double_System_Double_) and [MinMagnitude(Double, Double)](https://docs.microsoft.com/en-us/dotnet/api/system.math.minmagnitude?view=net-5.0#System_Math_MinMagnitude_System_Double_System_Double_)

Corresponds to the `maxNumMag` and `minNumMag` IEEE operations.

 - They return the value that is greater or lesser in the magnitude of the two inputs respectively. 
 - For example, `Math.MaxMagnitude(2.0, -3.0)` would return `-3.0`.

## [ILogB(Double)](https://docs.microsoft.com/en-us/dotnet/api/system.math.ilogb?view=net-5.0#System_Math_ILogB_System_Double_)

Corresponds to the `logB` IEEE operation.

 - It returns an integral value, it returns the integral base-2 log of the input parameter. 
 - This method is effectively the same as `floor(log2(x))`, but done with a minimal rounding error.

## [ScaleB(Double, Int32)](https://docs.microsoft.com/en-us/dotnet/api/system.math.scaleb?view=net-5.0#System_Math_ScaleB_System_Double_System_Int32_)

Corresponds to the `scaleB` IEEE operation. It takes an integral value, it returns effectively `x * pow(2, n)`, but is done with a minimal rounding error.

## [Log2(Double)](https://docs.microsoft.com/en-us/dotnet/api/system.math.log2?view=net-5.0#System_Math_Log2_System_Double_)

Corresponds to the `log2` IEEE operation, it returns the base-2 logarithm. It minimizes rounding errors.

## [FusedMultiplyAdd(Double, Double, Double)](https://docs.microsoft.com/en-us/dotnet/api/system.math.fusedmultiplyadd?view=net-5.0#System_Math_FusedMultiplyAdd_System_Double_System_Double_System_Double_)

Corresponds to the `fma` IEEE operation. 

 - It performs a fused multiply-add. That is, it does `(x * y) + z` as a single operation, thereby minimizing the rounding error. 
 - An example is `FusedMultiplyAdd(1e308, 2.0, -1e308)`, which returns `1e308`. 
 - The regular `(1e308 * 2.0) - 1e308` returns `double.PositiveInfinity`.

## [CopySign(Double, Double)](https://docs.microsoft.com/en-us/dotnet/api/system.math.copysign?view=net-5.0#System_Math_CopySign_System_Double_System_Double_)

Corresponds to the `copySign` IEEE operation, it returns the value of `x`, but with the sign of `y`.