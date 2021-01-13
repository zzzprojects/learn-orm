---
PermaID: 100009
Name: Keyboard Shortcuts
---

# Keyboard Shortcuts

Visual Studio Code lets you perform most tasks directly from the keyboard. Visual Studio Code provides a rich and easy keyboard shortcuts editing experience using Keyboard Shortcuts editor. 

 - It lists all available commands with and without keybindings, and you can easily change/remove/reset their keybindings using the available actions. 
 - It also has a search box on the top that helps you in finding commands or keybindings. 

You can open this editor by going to the menu under **File > Preferences > Keyboard Shortcuts**.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/keyboard-shortcuts-1.png">

You can change the keyboard shortcut by right-clicking on the command and select the **Change Keybinding...** option.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/keyboard-shortcuts-2.png">

For demo purposes, let's update the **Copy** keyboard shortcut from `Ctrl + C` to `Shift + C` and press **Enter**.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/keyboard-shortcuts-3.png">

## Keyboard Rules

Each rule consists of:

 - A `key` that describes the pressed keys.
 - A `command` containing the identifier of the command to execute.
 - An **optional** `when` clause containing a boolean expression that will be evaluated depending on the current context.
 - Chords (two separate keypress actions) are described by separating the two keypresses with space. For example, `Ctrl+K Ctrl+C`.

When a key is pressed:

 - The rules are evaluated from bottom to top.
 - The first rule that matches, both the `key` and in terms of `when`, is accepted.
 - No more rules are processed.
 - If a rule is found and has a `command` set, the `command` is executed.

The additional `keybindings.json` rules are appended at runtime to the bottom of the default rules, allowing them to overwrite the default rules. The `keybindings.json` file is watched by VS Code, so editing it while VS Code is running will update the rules at runtime.

```csharp
// Place your key bindings in this file to override the defaults
[
    {
        "key": "shift+c",
        "command": "editor.action.clipboardCopyAction"
    },
    {
        "key": "ctrl+c",
        "command": "-editor.action.clipboardCopyAction"
    }
]
```

## Keymap Extensions

Keyboard shortcuts are vital to productivity, and changing keyboarding habits can be tough. To help with this, **File > Preferences > Keymaps** shows you a list of popular keymap extensions. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/keyboard-shortcuts-4.png">

These extensions modify the Visual Studio Code shortcuts to match those of other editors, so you don't need to learn new keyboard shortcuts. There is also a Keymaps category of extensions in the Marketplace.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/keyboard-shortcuts-5.png">

