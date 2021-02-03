---
PermaID: 100014
Name: Directives
---

# Directives

The VB.Net compiler directives give instructions to the compiler to preprocess the information before the actual compilation starts. 

 - All these directives begin with `#`, and only white-space characters may appear before a directive on a line. 
 - These directives are not statements.
 - VB.Net compiler does not have a separate preprocessor, but the directives work like a preprocessor. 
 - It also helps in conditional compilation. 

In VB.Net, the following types of directives are available. 

 - [`#Const` Directive](#const-directive)
 - [`#ExternalSource` Directive](#externalsource-directive)
 - [`#If...Then...#Else` Directive](#ifthenelse-directive)
 - [`#Region` Directive](#region-directive)

## `#Const` Directive

The `#Const` directive defines conditional compiler constants, and these constants are always private to the file in which they appear. 

 - You cannot create public compiler constants using the `#Const` directive. 
 - You can create them only in the user interface or with the `/define` compiler option.
 - You can use only conditional compiler constants and literals in `expression`.

The following code uses the `#Const` directive.

```csharp
#Const MyLocation = "USA"
#Const Version = 10.0

    Sub ConstDirective()

#If Version > 9.0 Then
        Console.WriteLine("Latest version installed")
#Else
        Console.WriteLine("Latest version not installed")
#End If

    End Sub
```

You can use constants defined with the #Const keyword only for conditional compilation. Constants can also be undefined, in which case they have a value of Nothing.

## `#ExternalSource` Directive

The #ExternalSource` Directive indicates a mapping between specific lines of source code and text external to the source.

 - It is used only by the compiler and the debugger.
 - A source file may include external source directives, which indicate a mapping between specific lines of code in the source file and text external to the source file. 
 - If errors are encountered in the designated source code during compilation, they are identified as coming from the external source.

The following code uses the `#ExternalSource` directive.

```csharp
    Sub ExternalSourceDirective()

#ExternalSource ("c:\vbprogs\directives.vb", 5)
        Console.WriteLine("This is External Code. ")
#End ExternalSource

    End Sub
```

External source directives do not affect a compilation and cannot be nested. They are intended for internal use by the application only.

## `#If...Then...#Else` Directive

The `#If...Then...#Else` directive conditionally compiles selected blocks of Visual Basic code. The behavior of the `#If...Then...#Else` directives appears the same as that of the `If...Then...Else` statements. However, the `#If...Then...#Else` directives evaluate at compile-time, whereas the `If...Then...Else` statements evaluate conditions at run time.

 - Conditional compilation is typically used to compile the same program for different platforms. 
 - It is also used to prevent debugging code from appearing in an executable file. 
 - Code excluded during conditional compilation is completely omitted from the final executable file, so it does not affect size or performance.

The following code uses the `#If...Then...#Else` directive.

```csharp
#Const MyLocation = "USA"
#Const Version = 10.0

    Sub ConstDirective()

#If Version > 9.0 Then
        Console.WriteLine("Latest version installed")
#Else
        Console.WriteLine("Latest version not installed")
#End If

    End Sub
```

## `#Region` Directive

The `#Region` directive collapses and hides sections of code in Visual Basic files.

 - Use the `#Region` directive to specify a block of code to expand or collapse when using the Visual Studio Code Editor's outlining feature.
 - You can place, or nest, regions within other regions to group similar regions together.

The following code uses the `#Region` directive.

#Region "MathFunctions"
    ' Insert code for the Math functions here.
#End Region
