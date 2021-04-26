---
PermaID: 100000
Name: Getting Started
---

# Getting Started

**Dapper.SqlBuilder** is a small NuGet library that is designed to make dynamic SQL tasks easier. It is about building SQL, not getting or mapping data, so it should not be bound to any particular data-access implementation. 

## Setup

To start using the **Dapper.SqlBuilder** in your application. You will need to install the [Dapper.SqlBuilder](https://www.nuget.org/packages/Dapper.SqlBuilder) NuGet package.

So let's open the Visual Studio and create a new project.

<img src="images/setup-1.png" alt="Create a new project">

Select the **Create a new project** option.

<img src="images/setup-2.png" alt="Select Console Application template">

Choose **C#** as language, **Windows** as a platform, and **Console** as the project type. In the template pane, select **Console Application** and click the **Next** button.

<img src="images/setup-3.png" alt="Configure your new project">

Enter the project name, you can change the location and solution name, but we will leave it and click on the **Next** button.  

<img src="images/setup-4.png" alt="Additional Information">

On the **Additional Information** dialog, select the target framework and then click on the **Create** button.

<img src="images/setup-5.png" alt="Console Application created">

You can see a new console application project is created. Now, to install a **Dapper.SqlBuilder**, right-click on the **Solution Explorer** project, and select **Manage NuGet Packages...**

<img src="images/setup-6.png" alt="Install Dapper.SqlBuilder">

Select the **Browse** tab and search for **Dapper.SqlBuilder** and install the latest version by pressing the **Install** button. 

<img src="images/setup-7.png" alt="Dapper.SqlBuilder installed successfully">

Once **Dapper.SqlBuilder** has been successfully installed. You are now ready to start your application.
