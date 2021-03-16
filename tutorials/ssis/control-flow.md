---
PermaID: 100004
Name: Control Flow
---

# Control Flow

Control flow is the SQL Server workflow engine that contains control flow elements. An SSIS package consists of at least one control flow task and optionally one or more data flows.

A package consists of a control flow, and one or more data flows. 

 - The Integration Services architecture supports the containers' nesting, and a control flow can include multiple levels of nested containers. 
 - A package can contain a container such as a **Foreach Loop** container, which in turn could contain another Foreach Loop container and so on.
 - Event handlers also have control flows, which are built using the same kinds of control flow elements.

## Control Flow Implementation

You create the control flow in a package by using the **Control Flow** tab in SSIS Designer. When the **Control Flow** tab is active, the **Toolbox** lists the tasks and containers that you can add to the control flow. Creating a control flow includes the following tasks.

 - Adding containers that implement repeating workflows in a package or divide a control flow into subsets.
 - Adding tasks that support data flow, prepare data, perform workflow and business intelligence functions, and implement the script.
 - Integration Services includes a variety of tasks that you can use to create a control flow that meets the business requirements of the package. 
 - If the package has to work with data, the control flow must include at least one **Data Flow** task. 
 - A package might have to extract data, aggregate data values, and then write the results to a data source.

## Types 

There are three types of control flow elements.

### Containers 

The containers provide structure to package and service tasks. 

 - They support repeating control flow tasks, and grouping them into meaningful units. 
 - A single container can be created inside another container, along with additional tasks. 
 - Depending on the type, it can be used to repeat tasks for each element in a collection, repeat tasks until the specified condition is met, or the container can group tasks and other containers in units that must succeed or fail when finished.

### Control Flow Tasks 

The control flow tasks workflow objects that perform a high level of operations, such as sending an email message, executing a SQL statement, or copying a file from an FTP server. 

 - If the package contains more than one control flow task, they are connected and sequenced with a precedence constraint. 
 - When the control flow task is finished, it either succeeds or fails.

### Precedence Constraints

The precedence constraints connect tasks, executables, containers inside the control flow, and specify a condition that determines whether the task will run or not. 

 - Precedence constraints can be configured by logical `AND` or logical `OR` expressions and succeed or fail. 
 - One task can be connected to another with multiple precedence constraints, and for each constraint, a separate condition can be specified.
