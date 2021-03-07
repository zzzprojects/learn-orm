---
PermaID: 100001
Name: Environment Setup
---

# Environment Setup

SQL Server provides a single setup program to install any or all of its components, including Integration Services. Use Setup to install Integration Services with or without other SQL Server components on a single computer.

## Download SQL Server Data Tools (SSDT) for Visual Studio

SQL Server Data Tools (SSDT) is a modern development tool for building SQL Server relational databases, databases in Azure SQL, Analysis Services (AS) data models, Integration Services (IS) packages, and Reporting Services (RS) reports. 

With SSDT, you can design and deploy any SQL Server content type with the same ease as you would develop an application in Visual Studio.

## SSDT for Visual Studio 2019

The core SSDT functionality to create database projects has remained integral to Visual Studio. With Visual Studio 2019, the required functionality to enable Integration Services projects has moved into the respective Visual Studio (VSIX) extensions only.

If Visual Studio 2019 is already installed, you can edit the list of workloads to include SSDT. If you don’t have Visual Studio 2019 installed, then you can download and install [Visual Studio 2019 Community](https://visualstudio.microsoft.com/downloads/).

To modify the installed Visual Studio workloads to include SSDT, use the Visual Studio Installer. In the installer, select for the edition of Visual Studio that you want to add SSDT to, and then choose **Modify**.

<img src="images/setup-3.png" alt="Workload">

Select **SQL Server Data Tools** under **Data storage and processing** in the list of workloads and select the **Modify** button to start the installation.

Once the installation is completed, launch the Visual Studio.

For Analysis Services, Integration Services, or Reporting Services projects, you can install the appropriate extensions from within Visual Studio with **Extensions > Manage Extensions** or from the Marketplace.

<img src="images/setup-4.png" alt="Install IS Extension">

Click on the **Download** button and it will prompt the following popup.

<img src="images/setup-5.png" alt="IS Extension Popup">

Click on the **Save** button and once the file is downloaded, double click on the file.

<img src="images/setup-6.png" alt="Select Language">

Select your preferred language and click on **Ok**

<img src="images/setup-7.png" alt="SSIS Projects">

Click the **Next** button to start the process.

<img src="images/setup-8.png" alt="SSIS Projects Setup">

Once the setup is completed successfully, it will show you the message.

<img src="images/setup-8.png" alt="SSIS Projects Setup Completed.">