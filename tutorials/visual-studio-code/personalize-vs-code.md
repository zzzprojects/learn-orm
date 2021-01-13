---
PermaID: 100005
Name: Personalize VS Code
---

# Personalize VS Code

Visual Studio Code is a powerful editor used by millions of developers all over the world. Most developers only install a theme, and that's their whole customization, so in this article, we will explain how to customize Visual Studio Code.

## Color Theme

Themes are significant since developers stare at a screen most of their time, so make sure it looks good and change it when you want it. Visual Studio Code has many built-in themes. Let's open the **View > Command Palette...** and type **theme**.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/personalize-of-vs-code-1.png">

Select the **Color Theme**, and you will see different color themes in a drop-down list.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/personalize-of-vs-code-2.png">

You can choose any of the available themes according to your preferences.

## File Icon Theme

File icons are the little icons next to file and folders names in the **Explorer**.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/personalize-vs-code-3.png">

Let's open the **View > Command Palette...** and type ***file icon***.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/personalize-vs-code-4.png">

Select the **File Icon Theme**, and you will see different file icon themes in a drop-down list.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/personalize-vs-code-5.png">

## Settings

You can also change the settings, by opening the **Open Settings (JSON)** from **View > Command Palette...** menu.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/personalize-vs-code-6.png">

To change the color of comments, update the following code in the `settings.json` file.

```csharp
{
    "workbench.colorTheme": "Default Dark+",
    "workbench.iconTheme": "vs-seti",
    "editor.tokenColorCustomizations": {
        "comments": "#00ff00"
      }
}
```

Now you will see a different color for comments.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/personalize-vs-code-7.png">
