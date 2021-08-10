---
PermaID: 100000
Name: Getting Started
---

# Getting Started

**DocX** is a NuGet library that allows you to manipulate Word files, in a simple and easy manner. It is fast, lightweight and the most important advantage of using this library is that it does not require Microsoft Word or Office to be installed.

## Features

 - Create new Word documents
 - Modify Word documents
 - Supports *.docx format from Word 2007 and later
 - Modify multiple documents in parallel for better performance
 - Apply a template to a Word document
 - Join documents, recreate portions from one to another
 - Supports document protection with or without password
 - Set document margins and page 
 - Set line spacing, indentation, text direction, text alignment
 - Manage fonts and font sizes
 - Set text color, bold, underline, italic, strikethrough, highlighting
 - Set page numbering
 - Create sections

## Installation

You can easily install it from the **Package Manager Console** window by running the following command.

```csharp
PM> Install-Package DocX
```

## Environment Setup

To start using the **DocX** in your application, you will need to install the [DocX](https://www.nuget.org/packages/DocX) NuGet package.

Let's open the Visual Studio and create a new project.

<img src="images/setup-1.png" alt="Create a new project">

Select the **Create a new project** option.

<img src="images/setup-2.png" alt="Select Console Application template">

Choose **C#** as language, **Windows** as a platform, and **Console** as the project type. In the template pane, select **Console App (.NET Framework)** and click the **Next** button.

<img src="images/setup-3.png" alt="Configure your new project">

Enter the project name, you can change the location and solution name, but we will leave it and click on the **Next** button.  

<img src="images/setup-4.png" alt="Console Application created">

You can see a new web application project is created. Now to install an **DocX**, right-click on the project in **Solution Explorer**, and select **Manage NuGet Packages...**

<img src="images/setup-5.png" alt="Install DocX">

Select the **Browse** tab and search for **DocX** and install the latest version by pressing the **Install** button. 

<img src="images/setup-6.png" alt="DocX installed successfully">

Once **DocX** has been successfully installed. You are now ready to start your application.
