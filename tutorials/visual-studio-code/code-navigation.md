---
PermaID: 100013
Name: Code Navigation
---

# Code Navigation

Visual Studio Code has a high productivity code editor. When it is combined with programming language services, it gives you the power of an IDE and the speed of a text editor. 

## Quick File Navigation

The Explorer is great for navigating between files when you are exploring a project. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/code-navigation-1.png">

However, when you are working on a task, you will find yourself quickly jumping between the same set of files. VS Code provides two powerful commands to navigate in and across files with easy-to-use key bindings.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/code-navigation-2.png">

Hold `Ctrl` and press `Tab` to view a list of all files open in an editor group. To open one of these files, use `Tab` again to pick the file you want to navigate to, then release `Ctrl` to open it.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/code-navigation-3.png">

Alternatively, you can use `Alt+Left` and `Alt+Right` to navigate between files and edit locations. If you are jumping around between different lines of the same file, these shortcuts allow you to navigate between those locations easily.

## Breadcrumbs

The editor has a navigation bar above its contents called Breadcrumbs. It shows the current location and allows you to quickly navigate between folders, files, and symbols.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/code-navigation-4.png">

Breadcrumbs always show the file path and, with the help of language extensions, the symbol path up to the cursor position. 

Selecting a breadcrumb in the path displays a dropdown with that level's siblings so you can quickly navigate to other folders and files.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/code-navigation-5.png">

## Go to Definition

If a language supports it, you can go to the definition of a symbol by pressing **F12** or right-click on it and select **Go To Definition**.

If you press `Ctrl` and hover over a symbol, a preview of the declaration will appear.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/code-navigation-6.png">

## Go to Type Definition

Some languages also support jumping to the type definition of a symbol by running the **Go to Type Definition** command from either the editor context menu or the **Command Palette**. 

 - It will take you to the definition of the type of a symbol. 
 - The command `editor.action.goToTypeDefinition` is not bound to a keyboard shortcut by default, but you can add your own custom keybinding.

## Go to Implementation

Languages can also support jumping to the implementation of a symbol by pressing `Ctrl+F12` or right-click on it and select **Go To Implementation**. For an interface, this shows all the implementors of that interface and for abstract methods, this shows all concrete implementations of that method.

## Peek

There is nothing worse than a big context switch when all you want is to quickly check something that's why VS Code support peeked editors. When you execute a **Go to References** search via `Shift+F12`, or a **Peek Definition** via `Alt+F12`, it embeds the result inline.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/code-navigation-7.png">
