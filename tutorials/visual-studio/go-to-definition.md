---
PermaID: 100015
Name: Go To Definition
---

# Go To Definition

The **Go To Definition** feature navigates to the source of a type or member and opens the result in a new tab. 

 - Using Keyboard, place your cursor on the member name and press **F12**. 
 - Using the mouse, right-click on the member name and select **Go To Definition** from the menu. 

Let's right-click on the member name `RemoveHeaderDirective` in our case and you will see the menu options, click on the **Go To Definition** option.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/go-to-definition-1.png">

You will see that the member definition is opened up.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/go-to-definition-2.png">

The **Go To Definition** can navigate to different files as well. If the calling method is defined on some other file **Go To Definition** will automatically navigate to that file in a new tab. 

Let's right-click on a member which is defined in another file and select **Go To Definition**.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/go-to-definition-3.png">

You will see that the member definition is open in the new tab.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/go-to-definition-4.png">

When select the **Go To Definition** on a member where the source code is not available, metadata is displayed instead. Let's select the **Go To Definition** on the `List<>` in your source code and you will see the metadata of the `List<>` class.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/go-to-definition-5.png">

The **Ctrl+click** is a shortcut for mouse users to quickly access **Go To Definition**. When you press **Ctrl** and hover over the type or member, it becomes clickable. 
 
You can change the modifier key for mouse-click Go To Definition by going to **Tools > Options > Text Editor > General**.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/go-to-definition-6.png">

You select either **Alt** or **Ctrl+Alt** from the **Use modifier key** drop-down. You can also disable mouse-click **Go To Definition** by unchecking the **Enable mouse click to perform Go To Definition** checkbox.
