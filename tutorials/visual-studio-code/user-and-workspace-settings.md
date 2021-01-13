---
PermaID: 100008
Name: User and Workspace Settings
---

# User and Workspace Settings

You can easily configure Visual Studio Code as you like through its various settings. Almost every part of the Visual Studio Code's editor, user interface, and functional behavior has options you can modify.

Visual Studio Code Code provides two different types of settings.

## User Settings

Settings that apply globally to any instance of VS Code you open.

## Workspace Settings

Workspace settings are stored inside your workspace and only apply when the workspace is opened. 

 - Workspace settings override user settings, and these settings are specific to a project and can be shared across developers on a project.
 - A workspace is usually just your project root folder, and workspace settings are stored at the root in a `.vscode` folder. 
 - You can also have more than one root folder in a VS Code workspace through a feature called Multi-root workspaces.

To open your user and workspace settings, go to the **File** menu and select **Preferences > Settings**

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/settings-1.png">

You can see two tabs for User and Workspace settings. Workspace settings are useful for sharing project-specific settings across a team. 

 - Default settings are represented in groups so that you can navigate them easily. 
 - It has a Commonly Used group at the top, which shows popular customizations. 
 - Each setting can be edited by either a checkbox, an input, or a drop-down. 
 - Edit the text or select the option you want to change to the desired settings.

Let's change the color theme from the drop-down list.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/settings-2.png">

The modified settings are now indicated with a blue line similar to modified lines in the editor. The gear icon opens a context menu with options to reset the setting to its default value as well as copy setting as JSON.

You can also search for and discover the settings you are looking for. When you search using the Search bar, it will show and highlight the settings matching your criteria and filter out those that are not matching.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/settings-3.png">

## Settings File Location

By default Visual Studio Code shows the Settings editor, but you can still edit the underlying `settings.json` file using the **Open Settings (JSON)** command or by changing your default settings editor with the `workbench.settings.editor` setting.

Depending on your platform, the user settings file is located here:

 - **Windows:** `%APPDATA%\Code\User\settings.json`
 - **macOS:** `$HOME/Library/Application Support/Code/User/settings.json`
 - **Linux:** `$HOME/.config/Code/User/settings.json`

The workspace settings file is located under the `.vscode` folder in your root folder.

## Reset User Settings

The easiest way to reset Visual Studio Code back to the default settings is to clear your user `settings.json` file contents in the **Settings** editor. Delete everything between the two curly braces, save the file, and Visual Studio Code will go back to using the default values.
