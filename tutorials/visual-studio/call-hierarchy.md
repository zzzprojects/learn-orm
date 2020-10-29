---
PermaID: 100014
Name: Call Hierarchy
---

# Call Hierarchy

## What is Call Hierarchy?

The Call Hierarchy feature allows the developer to see all the methods that are called the current method as well as the methods that are called from the current one.

 - By viewing the call hierarchy for your code, you can navigate all calls to, and sometimes from, a selected method, property, or constructor. 
 - It enables you to better understand how code flows, and to evaluate the effects of changes to code. 

## How Call Hierarchy is different from Call Stack?

In Visual Studio, you can view a call hierarchy at design time. So, it means you don't have to set a breakpoint and start the debugger to view the run-time call stack. 

 - You can examine several levels of code to view complex chains of method calls and additional entry points to the code. 
 - It also allows you to explore all possible execution paths.
 - You can view multiple levels of the call graph, which shows the caller-callee relationships among the methods in a specified scope.

## Open Call Hierarchy Window

You can open the **Call Hierarchy** window by right-clicking on the name of a method, property, or constructor in the code editor.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/call-hierarchy-1.png">

Select the **View Call Hierarchy** and you will see the member name appears in a tree view pane in the **Call Hierarchy** window. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/call-hierarchy-2.png">

If you expand the member node, **Calls To 'ReadDirectory'**, all members that call the selected member are displayed. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/call-hierarchy-3.png">

For C++, if you expand the **Calls From 'node'**, all members that are called by the selected member are displayed.

You can then expand each calling member to see its Calls To, and for C++, Calls From nodes. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/call-hierarchy-4.png">

This enables you to navigate into the stack of callers.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/call-hierarchy-5.png">

When you select a child member in the **Call Hierarchy** tree view pane, the **Call Hierarchy** details pane appears and displays all lines of code in which that child member is called from the parent member.

## Menu items

When you right-click on a node in the **Call Hierarchy** tree view pane, you will see different shortcut menu options that appear based on the node type.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/call-hierarchy-6.png">


The following table describes several shortcut menu options that are available when you right-click a node in the tree view pane.

| Menu Item           | Description                                                 |
|:--------------------|:------------------------------------------------------------|
| Add As New Root     | Adds the selected node to the tree view pane as a new root node. |
| Remove Root         | Removes the selected root node from the tree view pane. This option is available only from a root node. |
| Go To Definition    | Navigates to the original definition for a member call or variable definition. |
| Find All References | Finds all the lines of code in your project that reference a class or member. |
| Copy                | Copies the contents of the selected node but not its subnodes. |
| Refresh             | Collapses the selected node so that re-expanding it displays current information. |

