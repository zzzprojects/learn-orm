---
PermaID: 100000
Name: Getting Started
---

# Getting Started

**Moq.EntityFrameworkCore** is a NuGet library that helps you mocking EntityFramework contexts. 

## Installation

You can easily install it from the **Package Manager Console** window by running the following command.

```csharp
PM> Install-Package Moq.EntityFrameworkCore
```

## Environment Setup

To start using the **Moq.EntityFrameworkCore** in your application, you will need to install the [Moq.EntityFrameworkCore](https://www.nuget.org/packages/Moq.EntityFrameworkCore) NuGet package.

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

You can see a new web application project is created. Now to install an **Moq.EntityFrameworkCore**, right-click on the project in **Solution Explorer**, and select **Manage NuGet Packages...**

<img src="images/setup-6.png" alt="Install Moq.EntityFrameworkCore">

Select the **Browse** tab and search for **Moq.EntityFrameworkCore** and install the latest version by pressing the **Install** button. 

<img src="images/setup-7.png" alt="Moq.EntityFrameworkCore installed successfully">

Once **Moq.EntityFrameworkCore** has been successfully installed. Let's add the database provider that you want to target. We will use SQL Server, and the provider package is [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer). We can easily install that NuGet package by executing the following command in **Package Manager Console**. 

```csharp
PM> Install-Package Microsoft.EntityFrameworkCore.SqlServer
```

You are now ready to start your application.
