---
PermaID: 100001
Name: API Layers
---

# API Layers

Roslyn consists of two main layers of APIs.

 - [Compiler APIs](#compiler-apis)
 - [Workspaces APIs](#workspaces-apis)

## Compiler APIs

The compiler layer contains the object models that correspond with information exposed at each phase of the compiler pipeline. 

 - It contains an immutable snapshot of a single invocation of a compiler, including assembly references, compiler options, and source code files. 
 - There are two distinct APIs that represent the C# language and the Visual Basic language. 
 - These two APIs are similar in shape but tailored for high-fidelity to each individual language. 
 - This layer has no dependencies on Visual Studio components.

<img src="images/api-layers-1.png" alt="Compiler pipeline">

Corresponding to each of those phases, an object model is surfaced that allows access to the information at that phase. 

 - The parsing phase is exposed as a syntax tree.
 - The declaration phase as a hierarchical symbol table. 
 - The binding phase as a model that exposes the result of the compiler's semantic analysis
 - The emit phase as an API that produces IL byte codes.

### Diagnostic APIs

The compiler may produce a set of diagnostics covering everything from syntax, semantic, and definite assignment errors to various warnings and informational diagnostics. 

### Scripting APIs

As a part of the compiler layer, the hosting/scripting APIs are created  for executing code snippets and accumulating a runtime execution context. 

## Workspaces APIs

The Workspaces layer contains the Workspace API, which is the starting point for doing code analysis and refactoring over entire solutions. 

 - It assists you in organizing all the information about the projects in a solution into single object model, offering you direct access to the compiler layer object models without needing to parse files, configure options or manage project to project dependencies.
 - In addition, the Workspaces layer surfaces a set of commonly used APIs used when implementing code analysis and refactoring tools that function within a host environment like the Visual Studio IDE, such as the **Find All References**, **Formatting**, and **Code Generation APIs**.
 - This layer has no dependencies on Visual Studio components.

