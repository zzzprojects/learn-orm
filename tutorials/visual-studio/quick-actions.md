---
PermaID: 100010
Name: Quick Actions
---

# Quick Actions

The **Quick Actions** lets you easily refactor, generate, or otherwise modify code with a single action.

 - With **Quick Actions** you can fix errors in code that would cause a build to fail. 
 - When **Quick Actions** are available to fix an error on a line of code, the icon that's displayed in the margin or underneath the red squiggle is a light bulb with a red 'x' on it.

## Types

The icon that appears when a Quick Action is available gives an indication of the type of fix or refactoring that's available. 

 - **Screwdriver:** Indicates there are actions available to change the code, but you shouldn't necessarily use them. 
 - **Yellow Light Bulb:** Indicates there are actions available that you should do to improve your code. 
 - **Error Light Bulb:** Indicates there is an action available that fixes an error in your code.

Let's consider the following code where accidentally `int` is written as `itn`.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/quick-actions-1.png">

When you hover the mouse at the location of an error and if a fix is available, light bulbs appear.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/quick-actions-2.png">

To see potential fixes, select either the down arrow next to the light bulb or the Show potential fixes link. A list of available Quick Actions is displayed.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/quick-actions-3.png">

Now let's select the right action, like Change the `itn` to `int` and you will see that it automatically fixes the issue.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/quick-actions-4.png">

The Quick Action also enables you to remove variables that have been declared but never used in your code.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/quick-actions-5.png">


For more information about the quick actions in Visual Studio, visit the official documentation page [https://docs.microsoft.com/en-us/visualstudio/ide/common-quick-actions](https://docs.microsoft.com/en-us/visualstudio/ide/common-quick-actions)