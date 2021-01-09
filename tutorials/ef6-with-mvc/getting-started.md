---
PermaID: 100001
Name: Getting Started
---

# Getting Started

## Create ASP.NET MVC Application

The easiest way to create ASP.NET application is to open Visual Studio and create a C# web project using the ASP.NET Web Application (.NET Framework) template. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/mvc-with-entity-framework-6/images/getting-started-1.png">

Name the project **MvcWithEF6Demo** and select **OK**.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/mvc-with-entity-framework-6/images/getting-started-2.png">

In **New ASP.NET Web Application - MvcWithEF6Demo**, select **MVC**.

## Install Entity Framework 6

Entity Framework (EF6) is available as a nuget package and you can install it using **Nuget Package Manager**.

In the **Package Manager Console** window, enter the following command.

```csharp
PM> Install-Package EntityFramework
```

You can also install EF6 by select the project in Solution Explorer. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/mvc-with-entity-framework-6/images/getting-started-3.png">

Right click on your project and select **Manage Nuget Packages...**.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/mvc-with-entity-framework-6/images/getting-started-4.png">

Search for Entity Framework and install the latest version by pressing the install button. You are now ready to start your application.