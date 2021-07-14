---
PermaID: 100000
Name: Getting Started
---

# Getting Started

**EntityFrameworkCore.Triggers** is a NuGet library that adds triggers to your entities with insert, update and delete events. It provides three events for each database operation: before, after, and upon failure.

## Installation

You can easily install it from the **Package Manager Console** window by running the following command.

```csharp
PM> Install-Package EntityFrameworkCore.Triggers
```

## Environment Setup

To start using the **EntityFrameworkCore.Triggers** in your application, you will need to install the [EntityFrameworkCore.Triggers](https://www.nuget.org/packages/EntityFrameworkCore.Triggers) NuGet package.

Let's open the Visual Studio and create a new project.

<img src="images/setup-1.png" alt="Create a new project">

Select the **Create a new project** option.

<img src="images/setup-2.png" alt="Select Console Application template">

Choose **C#** as language, **Windows** as a platform, and **Web** as the project type. In the template pane, select **ASP.NET Core Web App (Model-View-Controller)** and click the **Next** button.

<img src="images/setup-3.png" alt="Configure your new project">

Enter the project name, you can change the location and solution name, but we will leave it and click on the **Next** button.  

<img src="images/setup-4.png" alt="Additional Information">

On the **Additional Information** dialog, select the target framework and then click on the **Create** button.  

<img src="images/setup-5.png" alt="Console Application created">

You can see a new web application project is created. Now, to install an **EntityFrameworkCore.Triggers**, right-click on the project in **Solution Explorer**, and select **Manage NuGet Packages...**

<img src="images/setup-6.png" alt="Install EntityFrameworkCore.Triggers">

Select the **Browse** tab and search for **EntityFrameworkCore.Triggers** and install the latest version by pressing the **Install** button. 

<img src="images/setup-7.png" alt="EntityFrameworkCore.Triggers installed successfully">

Once **EntityFrameworkCore.Triggers** has been successfully installed. Let's add the database provider that you want to target. We will use SQL Server, and the provider package is [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer). We can easily install that NuGet package by executing the following command in **Package Manager Console**. 

```csharp
PM> Install-Package Microsoft.EntityFrameworkCore.SqlServer
```

You are now ready to start your application.
