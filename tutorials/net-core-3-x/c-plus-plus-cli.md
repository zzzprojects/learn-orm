---
PermaID: 100025
Name: C++/CLI
---

# C++/CLI

The .NET Core framework version 3.1 was released alongside Visual Studio 2019 16.4. Among the changes, it includes support for C++/CLI components that can be used with .NET Core 3.x, in Visual Studio 2019 16.4. However, not everything works out of the box.

 - Support has been added for creating C++/CLI also known as **managed C++** projects. 
 - Binaries produced from these projects are compatible with .NET Core 3.0 and later versions.

To add support for C++/CLI in Visual Studio 2019 version 16.4, install the **Desktop development with C++** workload. This workload adds two templates to Visual Studio:

 - CLR Class Library (.NET Core)
 - CLR Empty Project (.NET Core)

For core C and C++ support, choose the **Desktop development with C++** workload. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/net-core-3-x/images/workloads.png">

 - It comes with the default code editor, which includes basic code editing support for over 20 languages, the ability to open and edit code from any folder without requiring a project, and integrated source code control.
 - Additional workloads support other kinds of development. 
 - For example, choose the **Universal Windows Platform development** workload to create apps that use the Windows Runtime for the Microsoft Store. 
 - Choose **Game development with C++** to create games that use DirectX, Unreal, and Cocos2d. 
 - Choose **Linux development with C++** to target Linux platforms, including IoT development.

The Installation details pane lists the included and optional components installed by each workload. You can select or deselect optional components in this list. For example, to support development by using the Visual Studio 2017 or 2015 compiler toolsets, choose the MSVC v141 or MSVC v140 optional components. You can add support for MFC, the experimental Modules language extension, IncrediBuild, and more.

