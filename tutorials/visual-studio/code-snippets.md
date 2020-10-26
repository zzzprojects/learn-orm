---
PermaID: 100006
Name: Code Snippets
---

# Code Snippets

Code snippets are ready-made snippets of code you can quickly insert into your code using a right-click menu (context menu) command or a combination of hotkeys. They typically contain commonly used code blocks such as `try-finally` or `if-else` blocks, but they can be used to insert entire classes or methods.

 - You can insert a code snippet at the cursor location, or insert a surround-with code snippet around the currently selected code. 
 - The Code Snippet Inserter is invoked through the **Insert Code Snippet** or **Surround With** commands on the IntelliSense menu, or by using the keyboard shortcuts **Ctrl+K, Ctrl+X** or **Ctrl+K, Ctrl+S** respectively.

Code snippets are available for a multitude of languages, including C#, C++, VB, XML, etc. To view all the available installed snippets for a language, select the **Tools > Code Snippets Manager...** 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/code-snippets-4.png">

You can see all the languages which contain code snippets, choose the **CSharp** from the **Language** drop-down and expand the **Visual C#**.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/code-snippets-5.png">

You can see all the available code snippets for the C# language.

## How to Insert Code Snippet

Code snippets can be accessed in the following general ways:

 - On the menu bar, choose **Edit > IntelliSense > Insert Snippet**
 - From the right-click or context menu in the code editor, choose **Snippet > Insert Snippet**
 - From the keyboard, press **Ctrl+K**, **Ctrl+X**

For example, the `for` code snippet creates an empty `for` loop. Let's open the `Main` method and press **Ctrl+K, Ctrl+KX**.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/code-snippets-1.png">

Now select the **Visual C#** option and you will see all the code snippets.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/code-snippets-2.png">

Double-click on the `for` and you will see an empty for loop is inserted.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/code-snippets-3.png">

## Create a Code Snippet

A snippet is nothing more than an XML file, with a `.snippet` extension, containing configuration settings. All the code snippets XML files are located in the Visual Studio installation directory and the path is also provided on the **Code Snippets Manager...**

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/code-snippets-6.png">

You can create your own code snippet with only a few steps. All you need to do is create an XML file, fill in the appropriate elements, and add your code to it.

Let's create a code snippet that checks the existence of a file. The first step is to create a new XML file in Visual Studio from **File > New > File...** menu.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/code-snippets-7.png">

Select **XML File**, and click **Open** button. Once the new XML file is opened, let's save it with a `.snippet` extension and call it `fexists.snippet`.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/code-snippets-8.png">

Now in our `fexists.snippet` file, we have only an XML declaration. Let's add the following basic snippet template to the XML file.

```csharp
<?xml version="1.0" encoding="utf-8"?>
<CodeSnippets xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
    <CodeSnippet Format="1.0.0">
        <Header>
            <Title></Title>
        </Header>
        <Snippet>
            <Code Language="">
                <![CDATA[]]>
            </Code>
        </Snippet>
    </CodeSnippet>
</CodeSnippets>
```

Now add the title of the snippet in the `Title` element also specify the language of the snippet in the `Language` attribute of the Code element.

```csharp
<?xml version="1.0" encoding="utf-8"?>
<CodeSnippets xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
  <CodeSnippet Format="1.0.0">
    <Header>
      <Title>File Exists</Title>
      <Shortcut>fexists</Shortcut>
    </Header>
    <Snippet>
      <Code Language="CSharp">
        <![CDATA[]]>
      </Code>
    </Snippet>
  </CodeSnippet>
</CodeSnippets>
``` 

You can also add the `ShortCut` tag which can be used to insert this snippet by writing this shortcut and press Tab `twice`.

Now, we need to add the snippet code in the `CDATA` section inside the `Code` element.

```csharp
<Code Language="CSharp">
  <![CDATA[var exists = File.Exists("C:\\Temp\\Notes.txt");]]>
</Code>
```

You can use a code snippet to add a using directive by including the `Imports` element.

```csharp
<Imports>
  <Import>
    <Namespace>System.IO</Namespace>
  </Import>
</Imports>
``` 

As you know that the method `File.Exists` is in the `System.IO` namespace so we need to define the `Imports` element to import the `System.IO` namespace. Here is the complete XML file.

```csharp
<?xml version="1.0" encoding="utf-8"?>
<CodeSnippets xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
  <CodeSnippet Format="1.0.0">
    <Header>
      <Title>File Exists</Title>
      <Shortcut>exists</Shortcut>
    </Header>
    <Snippet>
      <Code Language="CSharp">
        <![CDATA[var exists = File.Exists("C:\\Temp\\Notes.txt");]]>
      </Code>
      <Imports>
        <Import>
          <Namespace>System.IO</Namespace>
        </Import>
      </Imports>
    </Snippet>    
  </CodeSnippet>
</CodeSnippets>
```

## Import a Code Snippet

You can import a snippet to your Visual Studio installation by using the **Code Snippets Manager** by opening it from **Tools > Code Snippets Manager**.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/code-snippets-9.png">

Click the **Import...** button, browse to the location where you saved the code snippet, select the file and click the **Open** button.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/code-snippets-10.png">

The **Import Code Snippet** dialog opens, click the **Finish** button, then **OK**.

Let's try it by typing `fexists` and press the **Tab** button twice, or you can also use the keyboard by pressing **Ctrl+K** and **Ctrl+X**, and then select **My Code Snippets**.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/code-snippets-11.png">

Select the **File Exists** and you will see the following code snippet is inserted.

```csharp
var exists = File.Exists("C:\\Temp\\Notes.txt"); 
```

For more information about code snippets, visit the official documentation page [https://docs.microsoft.com/en-us/visualstudio/ide/code-snippets](https://docs.microsoft.com/en-us/visualstudio/ide/code-snippets) 