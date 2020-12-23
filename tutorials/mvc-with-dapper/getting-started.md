---
PermaID: 100001
Name: Getting Started
---

# Getting Started

In this article, we will discuss how to create ASP.NET Core 5.0 MVC web applications using Dapper. Before creating your application, you must install the latest [.Net Core SDK](https://dotnet.microsoft.com/download).

## Create ASP.NET MVC Application

The easiest way to create an ASP.NET Core Web Application is to open Visual Studio and create a C# web project using the **ASP.NET Core Web Application** template. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/mvc-with-dapper/images/getting-started-1.png">

Click the **Next** button and it will open the **Configure your new project** page.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/mvc-with-dapper/images/getting-started-2.png">

Enter the name of the project **MvcWithDapper**, you can also change the **Location** and **Solution name**. Click the **Create** button and it will open the **Create a new ASP.NET Core web application** page.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/mvc-with-dapper/images/getting-started-3.png">

Select **ASP.NET Core 5.0** and the **ASP.NET Core Web App (Model-View-Controller)** template, and make sure **Authentication** is set to **No Authentication**. Click the **Create** button and it will create a project containing the following files.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/mvc-with-dapper/images/getting-started-4.png">

## Install Dapper

To install a **Dapper** into your project, open the **Package Manager Console** window, enter the following command.

```csharp
PM> Install-Package Dapper
```

You can also install **Dapper** by selecting the project in **Solution Explorer**. Right-click on your project and select **Manage Nuget Packages...**.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/mvc-with-dapper/images/getting-started-5.png">

Search for dapper and install the latest version by pressing the install button. You are now ready to start your application. Let's run your application and make sure everything is working fine.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/mvc-with-dapper/images/getting-started-6.png">
