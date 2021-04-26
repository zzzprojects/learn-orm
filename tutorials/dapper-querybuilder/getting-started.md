---
PermaID: 100000
Name: Getting Started
---

# Getting Started

**Dapper Query Builder** is a small NuGet library that allows you to build your queries with interpolated strings, and this library will automatically parametrize your values. 

 - You can use interpolated strings by passing the parameters to Dapper without having to worry about creating and managing `DynamicParameters` manually.
 - It is a wrapper around Dapper mostly for helping building dynamic SQL queries and commands.

## Setup

To start using the **Dapper Query Builder** in your application. You will need to install the [Dapper Query Builder](https://www.nuget.org/packages/Dapper-QueryBuilder) NuGet package.

So let's open the Visual Studio and create a new project.

<img src="images/setup-1.png" alt="Create a new project">

Select the **Create a new project** option.

<img src="images/setup-2.png" alt="Select Console Application template">

Choose **C#** as language, **Windows** as a platform, and **Console** as the project type. In the template pane, select **Console Application** and click the **Next** button.

<img src="images/setup-3.png" alt="Configure your new project">

Enter the project name, you can change the location and solution name, but we will leave it as is and click on the **Next** button.  

<img src="images/setup-4.png" alt="Additional Information">

On the **Additional Information** dialog, select the target framework and then click on the **Create** button.

<img src="images/setup-5.png" alt="Console Application created">

You can see a new console application project is created. Now to install a **Dapper Query Builder**, right-click on the **Solution Explorer** project, and select **Manage NuGet Packages...**

<img src="images/setup-6.png" alt="Install Dapper Query Builder">

Select the **Browse** tab and search for **Dapper Query Builder** and install the latest version by pressing the **Install** button. 

<img src="images/setup-7.png" alt="Dapper Query Builder installed successfully">

Once **Dapper Query Builder** has been successfully installed. You are now ready to start your application.