---
PermaID: 100001
Name: Getting Started
---

# Getting Started

In this article, we will discuss how to create ASP.NET Core 2.2 MVC web applications using Entity Framework Core 2.2. Before creating your application, you must install [.Net Core SDK 2.2](https://dotnet.microsoft.com/download).

## Create ASP.NET MVC Application

The easiest way to create ASP.NET Core Web Application is to open Visual Studio and create a C# web project using the **ASP.NET Core Web Application** template. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/mvc-with-entity-framework-core/images/getting-started-1.png">

Name the project **MvcWithEFCoreDemo** and select **OK**. It will open the **New ASP.NET Core Web Application - MvcWithEFCoreDemo** dialog.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/mvc-with-entity-framework-core/images/getting-started-2.png">

Select **ASP.NET Core 2.2** and the **Web Application (Model-View-Controller)** template, and make sure **Authentication** is set to **No Authentication**.

## Install Entity Framework Core

To add EF Core support to a project, install the database provider that you want to target. We will use SQL Server, and the provider package is `Microsoft.EntityFrameworkCore.SqlServer`.

In the **Package Manager Console** window, enter the following command.

```csharp
PM> Install-Package Microsoft.EntityFrameworkCore.SqlServer
```

You can also install EF6 by select the project in Solution Explorer. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/mvc-with-entity-framework-core/images/getting-started-3.png">

Right, click on your project and select **Manage Nuget Packages...**.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/mvc-with-entity-framework-core/images/getting-started-4.png">

Search for Entity Framework and install the latest version by pressing the install button. You are now ready to start your application. Let's run your application and make sure everything is working fine.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/mvc-with-entity-framework-core/images/getting-started-5.png">
