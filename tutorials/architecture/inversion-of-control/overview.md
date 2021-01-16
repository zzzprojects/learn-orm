---
PermaID: 100000
Name: Overview
---

# Overview

Inversion of control (IoC) is a design pattern in which the control flow of a program is inverted. 

 - It is a design principle although, some people refer to it as a pattern. 
 - It is used to invert different kinds of controls in object-oriented design to achieve loose coupling. 
 - The controls refer to any additional responsibilities a class has, other than its main responsibility. 
 - It includes control over the flow of an application and control over the flow of object creation or dependent object creation and binding.

## Why IoC?

The inversion of control design pattern states that objects should not create objects on which they depend to perform some activity. 

 - They should get those objects from an outside service or a container. 
 - The idea is analogous to the Hollywood principle that says, **"Don't call us, we'll call you."** It means, instead of the application calling the methods in a framework, the framework would call the implementation that has been provided by the application. 

You can take advantage of the inversion of control pattern to decouple the components of your application, swap dependency implementations, mock dependencies, and make your application modular and testable.

 - Dependency injection is a subset of the inversion of control principle. 
 - In other words, dependency injection is just one way of implementing inversion of control. 
 - You can also implement inversion of control using events, delegates, template pattern, factory method, or service locator, etc.

The terms Inversion of Control (IoC), Dependency Inversion Principle (DIP), Dependency Injection (DI), and IoC containers may be familiar. The following figure clarifies whether they are principles or patterns.

<img src="images/ioc-1.png">

 - **IoC** and **DIP** are high-level design principles that should be used while designing application classes. As they are principles, they recommend certain best practices but do not provide any specific implementation details. 
 - **Dependency Injection (DI)** is a pattern and **IoC Container** is a framework.

We cannot achieve loosely coupled classes by using IoC alone. Along with IoC, we also need to use DIP, DI, and IoC container.

