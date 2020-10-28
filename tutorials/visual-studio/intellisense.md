---
PermaID: 100012
Name: IntelliSense
---

# IntelliSense

IntelliSense is a code-completion tool added to Visual Studio. It is one of a number of similar tools that allow for intelligent code completion or intelligent text completion on different platforms. 

 - IntelliSense attempts to guess what the developer wants to type in order to complete a line of code. 
 - It reduces typographical and syntactical errors when writing a code.
 - It also helps developers evaluate code as they are typing and use fewer keystrokes to implement certain aspects of a code.

IntelliSense includes the following features.

 - [List Members](#list-members)
 - [Parameter Info](#parameter-info)
 - [Quick Info](#quick-info) 
 - [Complete Word](#complete-word) 

These features help you to learn more about the code you're using, keep track of the parameters you're typing, and add calls to properties and methods with only a few keystrokes.

## List Members

A list of valid members from a type appears after typing a trigger character such as a period (`.`) in managed code or `::` in C++. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/intellisense-1.png">

If you continue typing characters, the list is filtered to include only the members that begin with those characters or where the beginning of any word within the name starts with those characters. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/intellisense-2.png">

IntelliSense also performs **CamelCase** matching, so you can just type the first letter of each camel-cased word in the member name to see the matches.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/intellisense-3.png">

After selecting an item, you can insert it into your code by pressing either **Tab** or **Space** or **Enter** button.

## Parameter Info

Parameter Info gives you information about the number, names, and types of parameters required by a method, attribute generic type parameter, or template, etc.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/intellisense-4.png">

The parameter in bold indicates the next parameter that is required as you type the function.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/intellisense-5.png">

For overloaded functions, you can use the Up and Down arrow keys to view alternative parameter information for the function overloads.

## Quick Info

Quick Info displays the complete declaration for any identifier in your code. When you select a member from the List Members box, Quick Info also appears.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/intellisense-6.png">

If a function is overloaded, IntelliSense may not display information for all forms of the overload.

## Complete Word

The Complete Word feature completes the rest of a variable, command, or function name after you have entered enough characters to disambiguate the term and press either **Tab** or **Space** or **Enter** button.