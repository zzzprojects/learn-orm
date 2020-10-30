---
PermaID: 100018
Name: Code Style Preferences
---

# Code Style Preferences

You can define and maintain consistent code style in your codebase by defining .NET code style rule options in an `EditorConfig` file. 

 - Code style settings can be specified by adding an `EditorConfig` file to your project. 
 - The editor configuration file is associated with a codebase rather than a Visual Studio personalization account. 
 - Settings in an `EditorConfig` file take precedence over code styles that are specified in the `Options` dialog box. 
 - It is useful when you want to enforce coding styles for all contributors to your project.

The code style preferences can be set on the Options dialog box from the **Tools > Options > Text Editor > [C# or Basic] > Code Style > General**.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/code-style-preferences-1.png">

 - All the settings on this dialog are applicable to your Visual Studio personalization account and aren't associated with a particular project or codebase. 
 - These settings aren't enforced at build time, if you want to associate code style preferences with your project and have the styles enforced during build, specify the preferences in an `.editorconfig` file that is associated with the project.

Each item in the list shows a preview of the preference when selected.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/code-style-preferences-2.png">

You can specify the **Preference** and **Severity** values using the drop-downs on each line for each code style setting.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/code-style-preferences-3.png">
 
The following options are available to set Severity

 - Refactoring Only 
 - Suggestion
 - Warning 
 - Error 

If you want to enable **Quick Actions** for a code style, make sure that **Severity** setting is set to other than **Refactoring Only** option.

## Generate Coding Style Configuration File

To generate coding style file, click the **Generate .editorconfig file from settings** button. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/code-style-preferences-4.png">

It will generate a coding style `.editorconfig` file based on the settings on the **Options** page.

## Apply Code Styles

In Visual Studio 2019, for C# code files you will see a **Code Cleanup** button at the bottom of the editor.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/code-style-preferences-5.png">

If an `.editorconfig` file exists for the project, those are the settings that take precedence. 

## Configuration 

With the Code Cleanup broom icon, you can see a expander arrow, let's click that arrow and you will see the following menu.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/code-style-preferences-6.png">

To configure which code styles you want to apply in one of two profiles in the **Configure Code Cleanup** dialog box. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/code-style-preferences-7.png">

After you have configured code cleanup, you can either click on the broom icon or press **Ctrl+K, Ctrl+E** to run code cleanup to apply code styles from an EditorConfig file or from the Code Style options page.

