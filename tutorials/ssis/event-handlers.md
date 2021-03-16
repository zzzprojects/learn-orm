---
PermaID: 100010
Name: Event Handlers
---

# Event Handlers

SSIS event handlers are the simplest means of turning an SSIS script into a reliable system that is auditable, reacts appropriately to error conditions, reports progress, and allows instrumentation and monitoring of your SSIS packages. 

 - They are easy to implement and provide a great deal of flexibility. Rob Sheldon once again provides an easy, clear introduction.
 - At run time, executables (packages and Foreach Loop, For Loop, Sequence, and task host containers) raise events. 
 - For example, an `OnError` event is raised when an error occurs. 
 - You can create custom event handlers for these events to extend package functionality and make packages easier to manage at run time.

Event handlers can perform tasks such as the following:

 - Clean up temporary data storage when a package or task finishes running.
 - Retrieve system information to assess resource availability before a package runs.
 - Refresh data in a table when a lookup in a reference table fails.
 - Send an e-mail message when an error or a warning occurs or when a task fails.

## Event Handler Content

Creating an event handler is similar to building a package; an event handler has tasks and containers, which are sequenced into a control flow, and an event handler can also include data flows. The SSIS Designer includes the Event Handlers tab for creating custom event handlers.

You can also create event handlers programmatically.

## Run-Time Events

The following table lists the event handlers that Integration Services provides, and describes the run-time events that cause the event handler to run.

| Event handler            | Event                                                                 |
| :------------------------| :---------------------------------------------------------------------------|
| OnError                  | The event handler for the `OnError` event. This event is raised by an executable when an error occurs. |
| OnExecStatusChanged      | The event handler for the `OnExecStatusChanged` event. This event is raised by an executable when its execution status changes. |
| OnInformation            | The event handler for the `OnInformation` event. This event is raised during the validation and execution of an executable to report information. This event conveys information only, with no errors or warnings. |
| OnPostExecute            | The event handler for the `OnPostExecute` event. This event is raised by an executable immediately after it has finished running. |
| OnPostValidate           | The event handler for the `OnPostValidate` event. This event is raised by an executable when its validation is finished. |
| OnPreExecute             | The event handler for the `OnPreExecute` event. This event is raised by an executable immediately before it runs. |
| OnPreValidate	           | The event handler for the `OnPreValidate` event. This event is raised by an executable when its validation starts. |
| OnProgress               | The event handler for the `OnProgress` event. This event is raised by an executable when measurable progress is made by the executable. |
| OnQueryCancel            | The event handler for the `OnQueryCancel` event. This event is raised by an executable to determine whether it should stop running. |
| OnTaskFailed             | The event handler for the `OnTaskFailed` event. This event is raised by a task when it fails. |
| OnVariableValueChanged   | The event handler for the `OnVariableValueChanged` event. This event is raised by an executable when the value of the variable changes. The event is raised by the executable on which the variable is defined. This event is not raised if you set the `RaiseChangeEvent` property for the variable to `False`.
| OnWarning                | The event handler for the `OnWarning` event. This event is raised by an executable when a warning occurs.

## Add an Event Handler to a Package

At run time, containers and tasks raise events. You can create custom event handlers that respond to these events by running a workflow when the event is raised. 

 - For example, you can create an event handler that sends an e-mail message when a task fails.
 - An event handler is similar to a package, like a package, an event handler can provide scope for variables, and includes a control flow and optional data flows. 
 - You can build event handlers for packages, the **Foreach Loop** container, the **For Loop** container, the **Sequence** container, and all tasks.

You create event handlers by using the design surface of the **Event Handlers** tab in SSIS Designer.

 - When the **Event Handlers** tab is active, the **Control Flow Items** and **Maintenance Plan Tasks** nodes of the **Toolbox** in SSIS Designer contain the task and containers for building the control flow in the event handler. 
 - The **Data Flow Sources**, **Transformations**, and **Data Flow Destinations** nodes contain the data sources, transformations, and destinations for building the data flows in the event handler.
 - The **Event Handlers** tab also includes the **Connections Managers** area where you can create and modify the connection managers that event handlers use to connect to servers and data sources.

