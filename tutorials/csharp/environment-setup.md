---
PermaID: 100001
Name: Environment Setup
---

# Environment Setup

To create Windows applications with the C# programming language, you will first need to install a Visual Studio Integrated Development Environment (IDE). 

 - Microsoft Visual Studio is an integrated development environment (IDE) from Microsoft where you can develop different types of applications on the .NET platform. 
 - It also allows the developer to debug and run their applications.

## Download & Installation

To download Visual Studio, go to the Visual Studio download page [https://visualstudio.microsoft.com/downloads/](https://visualstudio.microsoft.com/downloads/).

<img src="images/setup-1.png">

You can select one of the following editions.

 - Visual Studio 2019 Community (Free download)
 - Visual Studio 2019 Professional (Free trial)
 - Visual Studio 2019 Enterprise (Free trial)

In this tutorial, we will use the Visual Studio 2019 Community Edition. It is a streamlined version of Visual Studio, specially created for people learning programming. It has a simplified user interface and omits advanced features of the professional edition to avoid confusion. 

So click on the **Free download** button, and once the *.exe file is downloaded, right-click and select the Run as administrator on the downloaded file to begin the installation.

<img src="/images/setup-2.png">

Click on continue to go ahead with the installation. 

<img src="/images/setup-3.png">

Select the required Workload, let's say we want to install the **.NET Desktop development** & **ASP.NET and web development**. Now, click on the Install button to begin the installation of Visual Studio 2019.

The installer will now download and install each component from the internet. It will take some time depending on your internet speed. Once the installation is completed, you will see the Installation succeeded message.

If you are installing Visual Studio for the first time you will be asked to sign in.

## Create a Console Application

Let's create a new Console Application project by launching the Visual Studio.

<img src="/images/setup-4.png">

Select the **Create a new project** option.

<img src="/images/setup-5.png">

Choose **C#** as language, **Windows** as platform and **Console** as project type. In the template pane, select **Console App (.NET Core)** and click **Next** button.

<img src="/images/setup-6.png">

Enter the project name, you can change the location and solution name, but we will leave it as is and click on the **Create** button.  

<img src="/images/setup-6.png">

You can see a new console application project is created. 

<img src="/images/setup-7.png">

Now let's add the following simple code which will print a message on the console window.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorialDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to C# Tutorial.");
        }
    }
}
```

Let's run the application by clicking on the **Debug > Start Without Debugging** menu option. 

<img src="/images/setup-8.png">

You will see the following output.

```csharp
Welcome to C# Tutorial.
```
