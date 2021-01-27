---
PermaID: 100004
Name: Keywords
---

# Keywords

A keyword is a reserved word with special meanings in the compiler, whose meaning cannot be changed. Therefore, these keywords cannot be used as an identifier in VB.NET programming such as class name, variable, function, module, etc.

In visual basic, there are two types of Keywords.

 - [Reserved Keywords](#reserved-keywords)
 - [Unreserved Keywords](#unreserved-keywords)

## Reserved Keywords

Reserved keywords cannot be used as names for programming elements such as variables, procedures, etc. You can bypass this restriction by enclosing the name in brackets (`[]`).

Here is the list of the most commonly used reserved keywords.

<table>
<tr>
    <td>AddHandler</td>
    <td>AddressOf</td>
    <td>Alias</td>
    <td>And</td>
    <td>AndAlso</td>
    <td>As</td>
</tr>
<tr>
    <td>Boolean</td>
    <td>ByRef</td>
    <td>Byte</td>
    <td>ByVal</td>
    <td>Call</td>
    <td>Case</td>
</tr>
<tr>
    <td>Catch</td>
    <td>CBool</td>
    <td>CByte</td>
    <td>CChar</td>
    <td>CDate</td>
    <td>CDbl</td>
</tr>
<tr>
    <td>CDec</td>
    <td>Char</td>
    <td>CInt</td>
    <td>Class</td>
    <td>CLng</td>
    <td>CObj</td>
</tr>
<tr>
    <td>Const</td>
    <td>Continue</td>
    <td>CSByte</td>
    <td>CShort</td>
    <td>CSng</td>
    <td>CStr</td>
</tr>
<tr>
    <td>CType</td>
    <td>CUInt</td>
    <td>CULng</td>
    <td>CUShort</td>
    <td>Date</td>
    <td>Decimal</td>
</tr>
<tr>
    <td>Declare</td>
    <td>Default</td>
    <td>Delegate</td>
    <td>Dim</td>
    <td>DirectCast</td>
    <td>Do</td>
</tr>
<tr>
    <td>Double</td>
    <td>Each</td>
    <td>Else</td>
    <td>ElseIf</td>
    <td>End</td>
    <td>EndIf</td>
</tr>
<tr>
    <td>Enum</td>
    <td>Erase</td>
    <td>Error</td>
    <td>Event</td>
    <td>Exit</td>
    <td>False</td>
</tr>
<tr>
    <td>Finally</td>
    <td>For</td>
    <td>For Each…Next</td>
    <td>Friend</td>
    <td>Function</td>
    <td>Get</td>
</tr>
<tr>
    <td>GetType</td>
    <td>GetXMLNamespace</td>
    <td>Global</td>
    <td>GoSub</td>
    <td>GoTo</td>
    <td>Handles</td>
</tr>
<tr>
    <td>If</td>
    <td>Implements</td>
    <td>Imports</td>
    <td>In</td>
    <td>Inherits</td>
    <td>Integer</td>
</tr>
<tr>
    <td>Interface</td>
    <td>Is</td>
    <td>IsNot</td>
    <td>Let</td>
    <td>Lib</td>
    <td>Like</td>
</tr>
<tr>
    <td>Long</td>
    <td>Loop</td>
    <td>Me</td>
    <td>Mod</td>
    <td>Module</td>
    <td>MustInherit</td>
</tr>
<tr>
    <td>MustOverride</td>
    <td>MyBase</td>
    <td>MyClass</td>
    <td>Namespace</td>
    <td>Narrowing</td>
    <td>New</td>
</tr>
<tr>
    <td>Next</td>
    <td>Not</td>
    <td>Nothing</td>
    <td>NotInheritable</td>
    <td>NotOverridable</td>
    <td>Object</td>
</tr>
<tr>
    <td>Of</td>
    <td>On</td>
    <td>Operator</td>
    <td>Option</td>
    <td>Optional</td>
    <td>Or</td>
</tr>
<tr>
    <td>OrElse</td>
    <td>Out</td>
    <td>Overloads</td>
    <td>Overridable</td>
    <td>Overrides</td>
    <td>ParamArray</td>
</tr>
<tr>
    <td>Partial</td>
    <td>Private</td>
    <td>Property</td>
    <td>Protected</td>
    <td>Public</td>
    <td>RaiseEvent</td>
</tr>
<tr>
    <td>ReadOnly</td>
    <td>ReDim</td>
    <td>REM</td>
    <td>RemoveHandler</td>
    <td>Resume</td>
    <td>Return</td>
</tr>
<tr>
    <td>SByte</td>
    <td>Select</td>
    <td>Set</td>
    <td>Shadows</td>
    <td>Shared</td>
    <td>Short</td>
</tr>
<tr>
    <td>Single</td>
    <td>Static</td>
    <td>Step</td>
    <td>Stop</td>
    <td>String</td>
    <td>Structure</td>
</tr>
<tr>
    <td>Sub</td>
    <td>SyncLock</td>
    <td>Then</td>
    <td>Throw</td>
    <td>To</td>
    <td>True</td>
</tr>
<tr>
    <td>Try</td>
    <td>TryCast</td>
    <td>TypeOf…Is</td>
    <td>UInteger</td>
    <td>ULong</td>
    <td>UShort</td>
</tr>
<tr>
    <td>Using</td>
    <td>Variant</td>
    <td>Wend</td>
    <td>When</td>
    <td>While</td>
    <td>Widening</td>
</tr>
<tr>
    <td>With</td>
    <td>WithEvents</td>
    <td>WriteOnly</td>
    <td>Xor</td>
    <td>#Const</td>
    <td>#Else</td>
</tr>
<tr>
    <td>#ElseIf</td>
    <td>#End</td>
    <td>#If</td>
    <td></td>
    <td></td>
    <td></td>
</tr>
</table>

## Unreserved Keywords

Unreserved keywords can be used as names for your programming elements. However, it is not recommended because it can make your code hard to read and can lead to subtle errors that can be difficult to find.

<table>
<tr>
    <td>Aggregate</td>
    <td>Ansi</td>
    <td>Assembly</td>
    <td>Async</td>
    <td>Auto</td>
    <td>Await</td>
</tr>
<tr>
    <td>Binary</td>
    <td>Compare</td>
    <td>Custom</td>
    <td>Distinct</td>
    <td>Equals</td>
    <td>Explicit</td>
</tr>
<tr>
    <td>From</td>
    <td>Group By</td>
    <td>Group Join</td>
    <td>Into</td>
    <td>IsFalse</td>
    <td>IsTrue</td>
</tr>
<tr>
    <td>Iterator</td>
    <td>Join</td>
    <td>Key</td>
    <td>Mid</td>
    <td>Off</td>
    <td>Order By</td>
</tr>
<tr>
    <td>Preserve</td>
    <td>Skip</td>
    <td>Skip While</td>
    <td>Strict</td>
    <td>Take</td>
    <td>Take While</td>
</tr>
<tr>
    <td>Text</td>
    <td>Unicode</td>
    <td>Until</td>
    <td>Where</td>
    <td>Yield</td>
    <td>#ExternalSource</td>
</tr>
<tr>
    <td>#Region</td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
</tr>
</table>			

## Use Keywords as Variable Names

If you want to use Keywords as variable names (identifiers), then we need to enclose the variable name in brackets ([]). For example, [Class] is a valid identifier, but Class is not because it’s a keyword and having a special meaning for the compiler.

The following example shows how to use the reserve keywords as a variable name by enclosing the variable name with brackets (`[]`).

```csharp
Imports System

Module Program
    Public Class [Class]
        Public name As String
    End Class

    Sub Main()
        Dim p1 As [Class] = New [Class]()
        p1.name = "John"
        Console.WriteLine("Age: " & p1.name)
    End Sub
End Module
```

As you can see a `Class` keyword is used as a variable name `[Class]` by enclosing it with brackets (`[]`).		
