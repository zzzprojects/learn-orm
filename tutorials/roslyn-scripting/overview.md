---
PermaID: 100000
Name: Overview
---

# Overview

A compiler is a black box, it takes source code as an input, magic happens in the middle, and object files or assemblies come out as an output. 

 - As compilers perform some processing and build up a deep understanding of the code, but that knowledge is only available to the compiler implementation wizards. 
 - The information is promptly forgotten after the translated output is produced.

Roslyn exposes the C# and Visual Basic compiler's code analysis to you as a consumer by providing an API layer that mirrors a traditional compiler pipeline.

<img src="images/Overview.png" alt="Compiler pipeline">

Each phase of the above pipeline is now a separate component. 

 - In the parser phase, the source is tokenized and parsed into syntax that follows the language grammar. 
 - In the declaration phase, the declarations from source and imported metadata are analyzed to form named symbols. 
 - The binding phase, the identifiers in the code are matched to symbols. 
 - Finally, in the emit phase, all the information built up by the compiler is emitted as an assembly.
