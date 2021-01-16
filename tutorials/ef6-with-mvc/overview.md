---
PermaID: 100000
Name: Overview
IsHome: 1
---

# Overview

## What is MVC?

MVC stands for Model, View, and Controller. MVC separates the application into three components 

 - **Model:** Responsible for maintaining application data and business logic.
 - **View:** User interface of the application, which displays the data.
 - **Controller:** Handles user's requests and renders appropriate View with Model data.

<img src="images/overview-1.png">

The MVC design pattern has been around for a few decades, and it's been used across many different technologies. 

### What is ASP.NET MVC?

ASP.NET MVC is a web development framework developed by Microsoft which combines the features of MVC (Model-View-Controller) architecture. 
 
 - It is an alternative to traditional ASP.NET Web Forms. 
 - It is built on the top of ASP.NET, so developers enjoy almost all the ASP.NET features while building the MVC application.
 - It is a framework for building scalable, standards-based web applications using well-established design patterns and the power of ASP.NET and the .NET Framework.

### Features

 - Separates data access logic from display logic and applies itself extremely well to web applications.
 - Explicit separation of concerns adds a small amount of extra complexity but the extraordinary benefits outweigh the extra effort. 
 - Integrated Scaffolding system extensible via NuGet
 - HTML 5 enabled project templates
 - Expressive Views including the new Razor View Engine
 - Powerful hooks with Dependency Injection and Global Action Filters
 - Rich JavaScript support with unobtrusive JavaScript, jQuery Validation, and JSON binding

## What is Entity Framework 6?

Entity Framework 6 (EF6) is an open source object-relational mapper (ORM) for ADO.NET which is a part of .NET Framework with many years of feature development and stabilization.

 - It enables developers to write applications that interact with data stored in relational databases using strongly-typed .NET objects.
 - It takes care of creating database connections and executing commands. 
 - It also automatically materialize query results to your application objects.
 - It is also the responsibility of EF to keep track of changes to those objects, and when instructed, it will also persist those changes back to the database for you.