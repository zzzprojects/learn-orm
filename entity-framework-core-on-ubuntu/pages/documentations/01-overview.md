---
PermaID: 100000
Name: Overview
IsHome: 1
---

# Overview

The .NET Core is a high performance, free and open-source software framework. It is developed by Microsoft and is a very powerful framework. 

 - The .NET core is not available in the official package repository of Ubuntu. 
 - But you can easily add the official Microsoft package repository on Ubuntu and install .NET Core from there using the APT package manager.

In this tutorial, we will set up a .NET Core framework on Ubuntu and create an ASP.NET Core application that will contain basic CRUD functionality using Entity Framework Core.

## What is Entity Framework?

Entity Framework is an ORM that enables .NET developers to work with a database using .NET objects and eliminates the need for more of the data-access code that developers usually need to write. Entity Framework is great but was difficult to use in mobile development projects until Entity Framework Core was released. 

## What is Entity Framework Core?	

Entity Framework Core is a lightweight, extensible, cross-platform version of Entity Framework data access technology. 

 - EF Core introduces many new features and improvements when compared to full-scale Entity Framework but is a completely brand-new codebase that’s optimized for cross-platform applications. 
 - If you have experience with Entity Framework, you’ll find EF Core very familiar. 
 - It doesn’t have all the features, and many will show up in future releases, such as lazy loading and connection resiliency.

## What is Ubuntu?

Ubuntu is a free and open-source Linux distribution based on Debian. It is officially released in three editions. 

 - Desktop
 - Server
 - Core

All the editions can run on the computer alone, or in a virtual machine. Ubuntu is a popular operating system for cloud computing, with support for OpenStack.

## What is APT Package Manager?

If you are using Debian, Ubuntu, Linux Mint or any other Debian or Ubuntu-based distributions, you must have come across some apt commands by now.

 - APT (Advanced Package Tool) is the command-line tool to interact with the packaging system. 
 - There are already dpkg commands to manage it, but APT is a more friendly way to handle packaging. 
 - You can use it to find and install new packages, upgrade packages, remove the packages, etc.
 - The apt commands provide a command-line way to interact with APT and manage packages.

### Update Ubuntu Software List with apt

The apt works on a repository of available packages. If the repository is not updated, the system won’t know if there are any newer packages available. Therefore, updating the repository should be the first thing to do in any Linux system after a fresh install.

```csharp
sudo apt update
```

When you run this command, you will see the package information is retrieved from various servers.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/entity-framework-core-on-ubuntu/images/overview-1.png">

### Upgrade installed packages with apt

Once you have updated the package repository, you can now upgrade the installed packages. The most convenient way is to upgrade all the packages that have available updates. You can simply use the following command. 

```csharp
sudo apt upgrade
```

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/entity-framework-core-on-ubuntu/images/overview-2.png">

This will show you how many and which all packages are going to be upgraded.

## Install the .NET Core

At this moment .NET Core 3.1 is the latest, but you can check here for the latest version https://dotnet.microsoft.com/download/dotnet-core.

### .NET Core SDK

In your terminal, run the following commands to install the .NET SDK.

```csharp
sudo apt-get install apt-transport-https
sudo apt-get install dotnet-sdk-3.1
```
The **“apt-transport-https”** APT transport allows the use of repositories accessed via the **HTTP Secure protocol (HTTPS)**, also referred to as HTTP over TLS.

### ASP.NET Core runtime

In your terminal, run the following command to install the ASP.NET Core runtime.

```csharp
sudo apt-get install aspnetcore-runtime-3.1
```

### .NET Core runtime

To install the .NET Core runtime, run the following command in the terminal.

```csharp
sudo apt-get install dotnet-runtime-3.1
```

## Install Visual Studio Code

Visual Studio Code is a free code editor from Microsoft. It combines the simplicity of a source code editor with powerful developer tooling, like IntelliSense code completion and debugging. You can download it from Visual Studio Download page.

[https://code.visualstudio.com/Download](https://code.visualstudio.com/Download)

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/entity-framework-core-on-ubuntu/images/overview-3.png">

Click on the .deb link for Linux 64 Bit. After the file downloads, open your terminal and go to the Downloads folder.

Run the following command to install the Visual Studio Code.

```csharp
sudo dpkg -i code_1.42.1-1581432938_amd64.deb
```
The **“code_1.42.1-1581432938_amd64.deb”** is the downloaded file name.
