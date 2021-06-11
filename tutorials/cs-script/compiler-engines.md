---
PermaID: 100006
Name: Compiler Engines
---

# Compiler Engines

The **CS-Script** allows hosting/executing the scripts by any of the three supported compilers. 

 - CodeDom
 - Mono
 - Roslyn

The **CS-Script** offers identical developer experience for all these three compilers, but the compilers themselves are not entirely identical. 

 - The initial **CS-Script** hosting model was based on **CodeDom** compilation, and support for **Mono** and **Roslyn** was added much later when these technologies became available. 
 - The **CodeDom** based API is not 100% aligned with the **Mono** and **Roslyn** native API. 
 - he native TAPI of all three compilers is extremely inconsistent that it was quite a challenge to define a common interface that can reconcile all the differences.

This challenge has been answered in the latest version, and the main hosting interface can be accessed using `CSScript.Evaluator`. 

 - It is the entry point for all three compilers, and this is the API that you should rely on in most cases. 
 - This common interface is referred through all the documentation as `CSScript.Evaluator`.

## CSScript.Evaluator

`CSScript.Evaluator` exposes the scripting functionality, which is common for all supported compilers. The following table explains certain runtime differences between the compilers.

| Features             | CodeDom        | Mono         | Roslyn               |
| :--------------------| :--------------| :------------| :--------------------|
| Performance (remote) | good           | very good    | poor                 |
| Performance (local)  | good/excellent | very good    | very good            |
| Debugging            | yes            | no           | yes                  |
| C# 6 (and above)     | yes4           | no           | yes                  |
| CS-Script directives | yes            | no           | no                   |
| Unloading support    | full           | partial      | partial              |
