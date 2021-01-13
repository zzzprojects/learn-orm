---
PermaID: 100012
Name: IntelliSense
---

# IntelliSense

**IntelliSense** is a general term for various code editing features including code completion, parameter info, quick info, and member lists. 

 - IntelliSense features are sometimes called by other names such as **code completion**, **content assist**, and **code hinting**.
 - Visual Studio Code IntelliSense is provided for C#, JavaScript, TypeScript, JSON, HTML, CSS, SCSS, and Less out of the box. 
 - VS Code supports word-based completions for any programming language but can also be configured to have richer IntelliSense by installing a language extension.

## Features

Visual Studio Code **IntelliSense** features are powered by a language service. 

 - A language service provides intelligent code completions based on language semantics and an analysis of your source code. 
 - If a language service knows possible completions, the **IntelliSense** suggestions will pop up as you type. 
 - If you continue typing characters, the list of members (variables, methods, etc.) is filtered to only include members containing your typed characters. 
 - Pressing **Tab** or **Enter** will insert the selected member.

You can trigger IntelliSense in any editor window by typing `Ctrl+Space` or by typing a trigger character such as the `.` (dot character).

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/intellisense-1.png">

The suggestions widget supports **CamelCase** filtering, which means you can type the letters which are uppercased in a method name to limit the suggestions. For example, "sc" will quickly bring up `SaveChanges`.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/intellisense-2.png">

As provided by the language service, you can see quick info for each method by either pressing `Ctrl+Space` or click on the `>` symbol. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/intellisense-3.png">

The accompanying documentation for the method will now expand to the side. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/intellisense-4.png">

The expanded documentation will stay so and will update as you navigate the list. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/intellisense-5.png">

You can close this by pressing `Ctrl+Space` again or by clicking on the close (`x`) icon.

## Customizing IntelliSense

You can customize your IntelliSense experience in settings and key bindings.

### Settings

The settings shown below are the default settings. You can change these settings in your `settings.json` file.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/intellisense-6.png">

### Tab Completion

The editor supports tab-completion, which inserts the best matching completion when pressing **Tab**. 

 - It works regardless of the suggested widget showing or not. 
 - When you press a **Tab** after inserting a suggestion will insert the next best suggestion.

By default, tab completion is disabled. You can enable it on User Settings. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/intellisense-7.png">

The **Tab Completion** drop-down contains the following values.

 - **off:** Tab completion is disabled. It is the default value.
 - **on:** Tab completion is enabled for all suggestions and repeated invocations insert the next best suggestion.
 - **onlySnippets:** Tab completion only inserts static snippets that prefix match the current line prefix.

