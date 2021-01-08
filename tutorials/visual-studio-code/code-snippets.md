---
PermaID: 100018
Name: Code Snippets
---

# Code snippets

Code snippets are templates that make it easier to enter repeating code patterns, such as loops or conditional-statements.

 - In Visual Studio Code, snippets appear in IntelliSense using the keyboard shortcut `Ctrl+Space` mixed with other suggestions, as well as in a dedicated snippet picker.
 - You can also use the **Insert Snippet** command in the **Command Palette**. 
 - There is also support for tab-completion, you can enable it with `"editor.tabCompletion": "on"` in **User Settings**, type a snippet prefix, and press **Tab** to insert a snippet.

For example, type `cw` in the editor and you will see a snippet name appears on the right side.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/code-snippets-1.png">

Press **Tab** and you will see `Console.WriteLine();` is inserted.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/code-snippets-2.png">

## Create a Code Snippet

You can easily define your snippets without any extension. To create or edit your snippets, select **User Snippets** under **File > Preferences** menu.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/code-snippets-3.png">

Select the language (by language identifier) for which the snippets should appear, here will see select `csharp (C#)`. You can also select the **New Global Snippets** file option if they should appear for all languages. VS Code manages the creation and refreshing of the underlying snippets file(s) for you.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/code-snippets-4.png">

Snippets files are written in JSON, support C-style comments, and can define an unlimited number of snippets. Snippets support most TextMate syntax for dynamic behavior, intelligently format whitespace based on the insertion context, and allow easy multiline editing.

Let's add the following script which will add a code snippet for checking whether the specified file exists or not.

```csharp
"File Exists": {
    "prefix": "fexist",
    "body": [
        "var exists = System.IO.File.Exists($0);"
    ],
    "description": "Determines whether the specified file exists."
}
```

In the above code:

 - `"File Exists"` is the snippet name. It is displayed via IntelliSense if no description is provided.
 - `prefix` defines one or more trigger words that display the snippet in IntelliSense. 
 - `body` is one or more lines of content, which will be joined as multiple lines upon insertion. Newlines and embedded tabs will be formatted according to the context in which the snippet is inserted.
 - `description` is an optional description of the snippet displayed by IntelliSense.

Let's save the `csharp.json` file and type `fexist` in the C# code file.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/code-snippets-5.png">

Now press **Tab** and you will see the following code line is inserted.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/code-snippets-6.png">

## Snippet Scope

Snippets are scoped so that only relevant snippets are suggested. Snippets can be scoped by either:

 - The **language(s)** to which snippets are scoped (possibly all)
 - The **project(s)** to which snippets are scoped (probably all)

### Language Snippet Scope

Every snippet is scoped to one, several, or all ("global") languages based on whether it is defined in:

 - A language snippet file
 - A global snippet file