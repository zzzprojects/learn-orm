---
PermaID: 100004
Name: Basics of VS Code
---

# Basics of VS Code

In this article, we will set up the Visual Studio Code and give an overview of the basic features. Once the Visual Studio Code is installed, open it, and you will see a welcome screen.

<img src="images/basics-of-vs-code-1.png">

You can open a folder or create a new file by clicking on the **New file** link.

<img src="images/basics-of-vs-code-2.png">

It will open a blank file, now let's use a C# code here by adding the following code, which will print **"Hello, World!"** message on the console.

```csharp
using System;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
```

To save the file, select the **File > Save** menu option.

<img src="images/basics-of-vs-code-3.png">

Enter `HelloWorld.cs` as a **File name** and click the Save button.

<img src="images/basics-of-vs-code-4.png">

Now you will see a color change of the code.

If you look at the interface, at the bottom, you will see the status bar where you will find helpful information, such as **Errors and Warnings**, **Current line number**, and **Programming language**, etc.

<img src="images/basics-of-vs-code-5.png">

On the left side, we have an activity bar that contains **File Explorer**, **Search**, **Source Control**, etc.

If you need to find where the things are, go to the welcome screen.

<img src="images/basics-of-vs-code-6.png">

Select the **Interface overview** under a **Learn** section.

<img src="images/basics-of-vs-code-7.png">

You will see parts of the interface overlaid on top.

On the Visual Studio Code you can also: 

 - Install support for your favorite programming language.
 - Change your keyboard shortcuts and easily migrate from other editors using keybinding extensions.
 - Customize your editor with themes.
 - Explore VS Code features in the Interactive Editor Playground.

