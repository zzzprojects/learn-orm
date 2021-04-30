---
PermaID: 100003
Name: Scripting APIs
---

# Scripting APIs


Roslyn is a .NET compiler platform that includes various compilers and code analysis APIs for .NET languages. 

 - It is the technology responsible for taking .NET source code and turning it into an executable binary. 
 - Its intended use is mostly concerning IDEs (Integrated Development Environments) and other development of tools. 
 - It also adds scripting API features, which allows you to add execution of the user-created code at runtime. 

The scripting APIs enable .NET applications to instantiate a C# engine and execute code snippets against host-supplied objects. 

You can't use the scripting APIs within Universal Windows Applications and .NET Native because these application model doesn't support loading code generated at runtime.

You can use the Roslyn scripting APIs in different scenarios, such as;

 - Evaluate a C# expression
 - Add references, namespace, and type imports as run-time to the script
 - You can parameterize a script
 - Create & build a C# script and execute it multiple times
 - Create a delegate to a script
 - Run a C# snippet and inspect defined script variables
 - Create and analyze a C# script
 - Customize assembly loading

