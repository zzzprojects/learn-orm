---
PermaID: 100000
Name: Getting Started
---

# Getting Started

## What is Excel?

Microsoft Excel is a very useful tool in the business world, and powering every industry and is used to provides some important and high-level information to the decision-makers. As a developer, sometimes you will need to deal with Excel spreadsheets, either to retrieve information or write information. 

## What is ExcelDataReader?

**ExcelDataReader** is a NuGet library that lightweight, fast helps you to read Excel files. It works cross-platform and is extremely efficient, flexible, and very easy to use and has supported on;

 - Windows with .Net Framework 2 
 - Windows Mobile with Compact Framework
 - Linux, OS X, BSD with Mono 2+

## Installation

You can easily install it from the **Package Manager Console** window by running the following command.

```csharp
PM> Install-Package ExcelDataReader
```
 
## Environment Setup

To start using the **ExcelDataReader** in your application, you will need to install the [ExcelDataReader](https://www.nuget.org/packages/ExcelDataReader) NuGet package.

Let's open the Visual Studio and create a new project.

<img src="images/setup-1.png" alt="Create a new project">

Select the **Create a new project** option.

<img src="images/setup-2.png" alt="Select Console Application template">

Choose **C#** as language, **Windows** as a platform, and **Console** as the project type. In the template pane, select **Console Application** and click the **Next** button.

<img src="images/setup-3.png" alt="Configure your new project">

Enter the project name, you can change the location and solution name, but we will leave it and click on the **Next** button.  

<img src="images/setup-4.png" alt="Additional Information">

On the **Additional Information** dialog, select the target framework and then click on the **Create** button.  

<img src="images/setup-5.png" alt="Console Application created">

You can see a new console application project is created. Now, to install an **ExcelDataReader**, right-click on the project in **Solution Explorer**, and select **Manage NuGet Packages...**

<img src="images/setup-6.png" alt="Install ExcelDataReader">

Select the **Browse** tab and search for **ExcelDataReader** and install the latest version by pressing the **Install** button. 

<img src="images/setup-7.png" alt="ExcelDataReader installed successfully">

Once **ExcelDataReader** has been successfully installed. You are now ready to start your application.
