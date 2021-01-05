---
PermaID: 100002
Name: Installation on macOS
---

# Installation on macOS

To install Visual Studio Code on macOS, download Visual Studio Code for macOS from the [official download](https://code.visualstudio.com/Download) page. Open the browser's download list and locate the downloaded archive.

Double-click on the downloaded archive to expand its contents.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/installation-on-macos-1.png">

Double-click on the **Visual Studio Code.app** file, and it will open the Visual Studio code.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/installation-on-macos-2.png">

Drag `Visual Studio Code.app` to the **Applications** folder, making it available in the macOS Launchpad.

Add VS Code to your **Dock** by right-clicking on the icon to bring up the context menu and choosing **Options, Keep in Dock**.

## Launching from the Command Line

You can also run Visual Studio Code from the terminal by typing `code` after adding it to the path.

 - Launch VS Code.
 - Open the Command Palette (`Ctrl+Shift+P`) and type `shell command` to find the **Shell Command: Install 'code' command in PATH command**.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/installation-on-macos-3.png">

Restart the terminal for the new `$PATH` value to take effect. You will be able to type `code .` in any folder to start editing files in that folder.

## Manual Instructions

Instead of running the command above, you can manually add the Visual Studio Code to your path by running the following commands:

```csharp
cat << EOF >> ~/.bash_profile
# Add Visual Studio Code (code)
export PATH="\$PATH:/Applications/Visual Studio Code.app/Contents/Resources/app/bin"
EOF
```

Start a new terminal to pick up your `.bash_profile` changes.

 - The leading slash `\` is required to prevent `$PATH` from expanding during the concatenation. 
 - Remove the leading slash if you want to run the export command directly in a terminal.

Since `zsh` became the default shell in macOS Catalina, run the following commands to add the Visual Studio Code to your path.

```csharp
cat << EOF >> ~/.zprofile
# Add Visual Studio Code (code)
export PATH="\$PATH:/Applications/Visual Studio Code.app/Contents/Resources/app/bin"
EOF
```
