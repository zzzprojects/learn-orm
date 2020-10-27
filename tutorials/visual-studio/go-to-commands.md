---
PermaID: 100009
Name: Go To Commands
---

# Go To Commands

In Visual Studio, **Go To** commands perform a focused search of your code to help you quickly find specified types, members, or symbols in your code. You can also use it to navigate to certain files or lines of code.

Go To has the following commands, which are available in the **Edit > Go To** menu.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/go-to-commands.png">

## Go To All

The **Go To All** command can be used from the **Edit > Go To > Go To All** menu or you can also use the keyboard shortcut **Ctrl + T**. A small window is displayed at the top right of your code editor.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/go-to-commands-1.png">

By default, **Go To All** will display any item in your solution that matches your search term.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/go-to-commands-2.png">

As you type in the text box, the results appear in a drop-down list below the text box. To go to an element, choose it in the list.

## Filtering to a Specific Type

You can also filter your code search to specific element types by prefacing your search term with certain characters or selecting one of the icons above the search box.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/go-to-commands-3.png">

Here is the prefix you can use in the search box.

|Prefix  | Shortcut              |Description                                 |
|:-------|:----------------------|:--------------------------                 |
| :      | Ctrl+G                | Go to the specified line number            |
| f	     | Ctrl+1, Ctrl+F        | Go to the specified file                   |
| r	     | Ctrl+1, Ctrl+R        | Go to the specified, recently visited file |
| t      | Ctrl+1, Ctrl+T        | Go to the specified type                   |
| m      | Ctrl+1, Ctrl+M        | Go to the specified member                 |
| #	     |Ctrl+1, Ctrl+S         | Go to the specified symbol                 |

## Filtering to a Specific Location

To narrow your search to a specific location, select one of the two document icons.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/go-to-commands-4.png">

 - **Current Document**: Search current document only
 - **External Documents**: Search external documents in addition to those located in the project/solution.

## Camel Casing

In your code, you can find code elements faster by entering only the capital letters of the code element name. For example, if your code has a type called `SitePageNav`, you can narrow down the search by entering just the capital letters of the name `SPM` in the Go To dialog box. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/go-to-commands-5.png">

This feature can be helpful if your code has long names.