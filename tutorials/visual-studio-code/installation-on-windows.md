---
PermaID: 100001
Name: Installation on Windows
---

# Installation on Windows

Visual Studio Code is a popular lightweight and convenient code editor that you can download and install for free on Windows 10, but it is also available on Linux and macOS.

## Download Installer

You can download the Visual Studio Code installer for Windows from the [Visual Studio Code's official website](https://code.visualstudio.com/Download).

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/installation-on-windows-1.png">

Alternatively, you can also download a Zip archive from the [Visual Studio Code's download page](https://code.visualstudio.com/Download), extract it, and run Code from there.

## Versions

If you need to run a 32-bit or 64-bit version of VS Code, both installer and zip archive are available for 32-bit and 64-bit.

## Setup Options

VS Code provides both Windows user and system level setups. 

### User Setup

 - Installing the user setup does not require **Administrator** privileges as the location will be under your user **Local AppData (LOCALAPPDATA)** folder. 
 - User setup also provides a smoother background update experience.

### System Setup

The system setup requires elevation to **Administrator** privileges and will place the installation under **Program Files**.

## Installation

After the installer is downloaded, run the installer (`VSCodeUserSetup-{version}.exe`). 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/installation-on-windows-2.png">

Accept the agreement and click on the **Next** button.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/installation-on-windows-3.png">

By default, VS Code is installed under **C:\users\{username}\AppData\Local\Programs\Microsoft VS Code**, you can also change the location. Click on the **Next** button. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/installation-on-windows-4.png">

Select the start menu folder, and click on the **Next** button.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/installation-on-windows-5.png">

Check all the additional tasks, and click on the **Next** button.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/installation-on-windows-6.png">

You will see the summary of all the options you have selected. Click on the **Install** button. It will only take a moment to install. 
 
<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/installation-on-windows-7.png">

After the installation is completed, click on the **Finish** button and it will open the Visual Studio Code.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio-code/images/installation-on-windows-8.png">

It will only take a minute. 

## Windows Subsystem for Linux

With [Windows Subsystem for Linux (WSL)](https://docs.microsoft.com/en-us/windows/wsl/install-win10), you can install and run Linux distributions on Windows. 

 - It enables you to develop and test your source code on Linux while still working locally on your Windows machine.
 - When coupled with the [Remote - WSL](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-wsl) extension, you get full VS Code editing and debugging support while running in the context of WSL.

See the [Developing in WSL](https://code.visualstudio.com/docs/remote/wsl) documentation to learn more or try the [Working in WSL](https://code.visualstudio.com/docs/remote/wsl-tutorial) introductory tutorial.