---
PermaID: 100000
Name: Overview
---

# Overview

## What is C#?

C# is an object-oriented programming language developed by Microsoft. It is a simple and powerful language that enables the developer to build a variety of applications that run on the .NET Framework and .NET Core. It can be used to create different types of applications using Visual Studio, such as; 

 - Mobile applications
 - Desktop applications
 - Web applications
 - Web services
 - Web sites
 - Games
 - Database applications etc.

## Why C#?

C# is a simple and easy to learn language and it will be instantly recognizable to anyone familiar with C, C++, or Java. Those developers who have worked in any of these languages can easily start working in C# within a short time. 

 - The syntax of C# simplifies many of the complexities of C++ and provides powerful features such as nullable types, enumerations, delegates, lambda expressions, and direct memory access. 
 - It supports generic methods and types, which enable developers to define custom iteration behaviors that are simple to use by client code. 
 - It is an object-oriented programming language and supports the concepts of encapsulation, inheritance, and polymorphism.

Nowadays, C# is one of the most popular programming languages and is used by millions of developers worldwide. The C# language and the .NET platform are maintained and managed entirely by Microsoft and are not open to third parties. 

## What is the .NET Framework?

The C# language is not distributed as a standalone product, it is a part of the Microsoft .NET Framework platform. It generally consists of an environment for the development and execution of programs, written in C# or some other language. 

 - It contains the .NET programming languages, such as C#, VB.NET, C++, F#, etc.
 - It has an environment for the execution of managed code (CLR), which executes C# programs in a controlled manner.
 - It also contains a set of development tools, such as the `CSC` compiler, which turns C# programs into intermediate code (called MSIL) that the CLR can understand.
 - It has a set of standard libraries, like ADO.NET, which allows access to databases, such as MS SQL Server or MySQL, and WCF which connects applications through standard communication frameworks and protocols like HTTP, REST, JSON, SOAP, and TCP sockets.

### Architecture

 When you execute the C# program, the assembly is loaded into the CLR, and perform different actions based on the information provided in the manifest. 
 
 - If it satisfies the security requirements, the CLR performs Just-In-Time (JIT) compilation to convert the IL code to native machine instructions. 
 - The CLR also provides other services related to automatic garbage collection, exception handling, and resource management. 
 - The code executed by the CLR is called managed code, while unmanaged code is compiled into native machine language that targets a specific system. 
 
## What is the .NET Core?

.NET Core is a free and open-source, managed programming framework for Windows, Linux, and macOS operating systems. It is a cross-platform successor to .NET Framework. 

 - It can be used to build different types of applications such as mobile, desktop, web, cloud, IoT, machine learning, microservices, game, etc.
 - It is written from scratch to make it modular, lightweight, fast, and cross-platform Framework. 
 - It includes the core features that are required to run basic .NET Core applications. 
 - All other features are provided as NuGet packages, which you can add to your application as needed. 

### Architecture

The two main components of .NET Core are CoreCLR and CoreFX, respectively, which are comparable to the Common Language Runtime (CLR) and the Framework Class Library (FCL) of the .NET Framework's Common Language Infrastructure (CLI) implementation.

 - The CoreCLR is a complete runtime and virtual machine for managed execution of .NET programs and includes a just-in-time compiler called RyuJIT.
 - .NET Core also contains CoreRT, the .NET Native runtime optimized to be integrated into AOT compiled native binaries.
 - The CoreFX shares a subset of .NET Framework APIs, however, it also comes with its own APIs that are not part of the .NET Framework. 
 - The .NET Core command-line interface offers an execution entry point for operating systems and provides developer services like compilation and package management.

## How it Works?

The C# language is distributed together with a special environment called Common Language Runtime (CLR) on which it is executed. It is part of the platform .NET Framework, which includes CLR, a bundle of standard libraries providing basic functionality, compilers, debuggers, and other development tools. 

 - The CLR programs are portable and, once written they can function with little or no changes on various hardware platforms and operating systems. 
 - C# programs are most commonly run on MS Windows, but the .NET Framework and CLR also support mobile phones and other portable devices based on Windows Mobile, Windows Phone, and Windows. 
 - C# programs can still be run under Linux, FreeBSD, iOS, Android, macOS X, and other operating systems through the free .NET Framework implementation Mono, which, however, is not officially supported by Microsoft.
