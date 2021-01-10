---
PermaID: 100000
Name: Overview
---

# Overview

Model-View-Controller (abbreviated as MVC) is a programming architecture pattern, which divides the application into three parts. The division is done for the purpose of separating the information that comes from within the application, in order to be then properly presented to the user. 

 - MVC as a design pattern helps to achieve code reusability precisely by dividing these three major components. 
 - Usually, MVC has been used for programming user interfaces for desktop applications. However, in recent years, it has become very popular for web applications, with many programming languages, such as C#, Java, Ruby, Python, etc. offering MVC frameworks.
 - Using the MVC pattern for websites, requests are routed to a Controller, which is responsible for working with the Model to perform actions and/or retrieve data. 
 - The Controller chooses the View to display and provides it with the Model. The View renders the final page, based on the data in the Model.
 - In addition to dividing the application into these components, the model-view-controller design defines the interactions between them.

## What is the MVC pattern?

The MVC design pattern separates an application into three components: Model, View, and Controller. Using MVC helps us achieve separation of concerns, which is one of the common architectural principles (the other two being encapsulation and dependency inversion). Using this pattern, the requests from users are routed to the Controller. The Controller works with the Model, who in turn performs the actions from the user, retrieves query results, or in some cases, even both. The Controller is also responsible for choosing the View which is displayed to the users, and also provides the View with data from the Model data. The View then renders the final page.

Following is a more detailed explanation of the three main components of MVC:

 - The Model represents the dynamic data structure of the application and it is completely non-related and independent from the UI. It is responsible for managing the application logic, rules, and data. Both business and implementation logic should be enclosed in the Model itself. It receives user input from the Controller.
 - The View is responsible for content presentation through the UI. In other words, the View is a user interface. Representation of any type of information (e.g., chart, diagram, table) happens through the View. Views should contain very little implementation logic. Any possible logic in them needs to relate to content presentation.
 - The Controller handles user requests and then routes them either to the Model or the View. In other words, any input provided to it is converted to a command for either the Model or the View. The controller responds to the user input by validating it and then interacting with the Model, more precisely with the Model objects. In MVC, the Controller is considered to be the initial entry point. From there, it chooses the appropriate model objects to work with and decides on which View to present to the user. Like Views, Controllers should not contain any business logic in them.

The Controller and the View are dependent on the model, but the Model is completely independent of the two, which allows for the Model to be coded and tested separately.

## Goals of MVC

### Parallel development

Due to the fact that MVC separates the application into three parts, development can be done in parallel without any problems. For instance, the team responsible for the back-end part of the application can work on data structuring, while the front-end developers can work in parallel and design the application layout without ever needing data.

### Reuse of code

Code reuse is big with MVC. It can be that a view from one application, with small refactoring, can be of use for another application with a different dataset, simply because of the fact that the View handles the way that the data is being displayed to end-users. This is done simply by creating so-called higher-level components, which are completely independent. Developers can later on, when they need them, just take them and make use of them in another application.

## Advantages 

 a.	Parallel development
 b.	High level of cohesion
 c.	Low coupling between models, views, and controllers
 d.	Ease of modification
 e.	Multiple views for a model

## Disadvantages

 a.	Complex code navigation
 b.	Consistency
 c.	Clustering
 d.	Pronounced learning curve

