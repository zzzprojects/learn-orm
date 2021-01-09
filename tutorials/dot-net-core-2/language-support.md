---
PermaID: 100002
Name: Language Support
---

# Language Support

In addition to supporting C# and F#, .NET Core 2.0 also supports Visual Basic.

## Visual Basic

With version 2.0, .NET Core now supports Visual Basic 2017. You can use Visual Basic to create the following project types:

 - .NET Core console apps
 - .NET Core class libraries
 - .NET Standard class libraries
 - .NET Core unit test projects
 - .NET Core xUnit test projects

For example, to create a Visual Basic **Hello World** application, open a console window, create a directory for your project, and make it the current directory.

Enter the following command on console.

```csharp
dotnet new console -lang vb.
```

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/net-core-2-x/images/lang-support-1.png">

The command creates a project file with a `.vbproj` file extension, along with a Visual Basic source code file named `Program.vb`. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/net-core-2-x/images/lang-support-2.png">

The `Program.vb` file contains the source code to write the string "Hello World!" to the console window.

```csharp
Imports System

Module Program
    Sub Main(args As String())
        Console.WriteLine("Hello World!")
    End Sub
End Module
```

Enter the command dotnet run. The .NET Core CLI automatically compiles and executes the application, which displays the message "Hello World!" in the console window.

## Support for C# 7.1

.NET Core 2.0 supports C# 7.1, which adds a number of new features, including:

 - The Main method, the application entry point, can be marked with the async keyword.
 - Inferred tuple names.
 - Default expressions.