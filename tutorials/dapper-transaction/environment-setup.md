---
PermaID: 100001
Name: Environment Setup
---

# Environment Setup

To start using the **Dapper.Transaction** in your application, you will need to install the [Dapper.Transaction](https://www.nuget.org/packages/Dapper) NuGet package.

So let's open the Visual Studio and create a new project.

<img src="images/setup-1.png" alt="Create a new project">

Select the **Create a new project** option.

<img src="images/setup-2.png" alt3="Select Console Application template">

Choose **C#** as language, **Windows** as a platform, and **Console** as the project type. In the template pane, select **Console Application** and click the **Next** button.

<img src="images/setup-3.png" alt="Configure your new project">

Enter the project name, you can change the location and solution name, but we will leave it and click on the **Next** button.  

<img src="images/setup-4.png" alt="Additional Information">

On the **Additional Information** dialog, select the target framework and then click on the **Create** button.  

<img src="images/setup-5.png" alt="Console Application created">

You can see a new console application project is created. Now install a Dapper, right-click on the **Solution Explorer** project, and select **Manage NuGet Packages...**

<img src="images/setup-6.png" alt="Install Dapper">

Select the **Browse** tab and search for dapper and install the latest version by pressing the **Install** button. 

<img src="images/setup-7.png" alt="Dapper installed successfully">

Once Dapper has been successfully installed, we also need to install [System.Data.SqlClient](https://www.nuget.org/packages/System.Data.SqlClient) NuGet package.

You are now ready to start your application.
