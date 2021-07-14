---
PermaID: 100000
Name: Getting Started
---

# Getting Started

**Detached.Mappers.EntityFramework** is a NuGet library that simplifies the task of saving disconnected entities using entity framework core.

 - In EntityFramework, or any other ORM that tracks entity states, the problem developer faces is that when persisting non-tracked entities EF has the `TrackGraph` method, but the state of each entity needs to be specified manually.
 - To reduce data traffic and, improve the security and the readability of swagger models, many times DTOs are used, and often they are very similar to the original entity.

## Installation

You can easily install it from the **Package Manager Console** window by running the following command.

```csharp
PM> Install-Package Detached.Mappers.EntityFramework
```

## Environment Setup

To start using the **Detached.Mappers.EntityFramework** in your application, you will need to install the [Detached.Mappers.EntityFramework](https://www.nuget.org/packages/Detached.Mappers.EntityFramework) NuGet package.

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

You can see a new web application project is created. Now to install a **Detached.Mappers.EntityFramework**, right-click on the project in **Solution Explorer**, and select **Manage NuGet Packages...**

<img src="images/setup-6.png" alt="Install Detached.Mappers.EntityFramework">

Select the **Browse** tab and search for **Detached.Mappers.EntityFramework** and install the latest version by pressing the **Install** button. 

<img src="images/setup-7.png" alt="Detached.Mappers.EntityFramework installed successfully">

Once **Detached.Mappers.EntityFramework** has been successfully installed. Let's add the database provider that you want to target. We will use SQL Server, and the provider package is [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer). We can easily install that NuGet package by executing the following command in **Package Manager Console**. 

```csharp
PM> Install-Package Microsoft.EntityFrameworkCore.SqlServer
```

You are now ready to start your application.
