---
PermaID: 100010
Name: Code Editing
---

# Code Editing

Visual Studio Code is an editor first and foremost and includes the features you need for highly productive source code editing. 

 - Being able to keep your hands on the keyboard when writing code is crucial for high productivity. 
 - Visual Studio Code has a rich set of default keyboard shortcuts, as well as allowing you to customize them.

## Multiple Selections

Visual Studio Code supports multiple cursors for fast simultaneous edits. You can add secondary cursors (rendered thinner) with Alt+Click. Each cursor operates independently based on the context it sits in. A common way to add more cursors is with `Ctrl+Alt+Down` or `Ctrl+Alt+Up` that insert cursors below or above.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/code-editing-1.png">

The `Ctrl+D` selects the word at the cursor or the next occurrence of the current selection.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/code-editing-2.png">

## Shrink/Expand Selection

You can quickly shrink or expand the current selection using `Shift+Alt+Left` and `Shift+Alt+Right`.

## Column Selection

To use column box selection, place the cursor in one corner and then hold |Shift+Alt| while dragging to the opposite corner.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/code-editing-3.png">

There are also default key bindings for column selection on macOS and Windows, but not on Linux.

| Key                     | Command                           | Command ID                   |
|:------------------------|:----------------------------------|:-----------------------------|
|Ctrl+Shift+Alt+Down      | Column Select Down                | cursorColumnSelectDown       |
|Ctrl+Shift+Alt+Up        | Column Select Up                  | cursorColumnSelectUp         |
|Ctrl+Shift+Alt+Left      | Column Select Left                | cursorColumnSelectLeft       |
|Ctrl+Shift+Alt+Right     | Column Select Right               | cursorColumnSelectRight      |
|Ctrl+Shift+Alt+PageDown  | Column Select Page Down           | cursorColumnSelectPageDown   |
|Ctrl+Shift+Alt+PageUp    | Column Select Page Up             | cursorColumnSelectPageUp     |

You can edit your `keybindings.json` to bind them to something more familiar if you wish.

## Save/Auto Save

By default, Visual Studio Code requires an explicit action to save your changes to disk, `Ctrl+S` or use the **File > Save** menu option.

 - It is very easy to turn-on **Auto Save**, which will save your changes after a configured delay or when focus leaves the editor. 
 - With this option turned on, there is no need to explicitly save the file. The easiest way to turn on Auto Save is with the **File > Auto Save** toggle that turns on and off save after a delay.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/code-editing-4.png">

For more control over **Auto Save**, open **User or Workspace settings** and find the associated settings. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/code-editing-4.png">

You will see that the **Auto Save** drop-down has the following values.

 - **off:** To disable auto-save.
 - **afterDelay:** To save files after a configured delay (default 1000 ms).
 - **onFocusChange:** To save files when focus moves out of the editor of the dirty file.
 - **onWindowChange:** To save files when the focus moves out of the VS Code window.

The **Auto Save Delay** configures the delay in milliseconds when **Auto Save** is configured to **afterDelay**. The default is **1000 ms**.
