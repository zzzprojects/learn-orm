---
PermaID: 100000
Name: Getting Started
---

# Getting Started

**Audit.EntityFramework.Core** is a NuGet library that provides an extensible framework to audit executing operations in .NET Core.

 - It allows you to generate tracking information about operations being executed. 
 - You can also gather information such as the caller user id, machine name, method name, exceptions, including execution time, and exposing an extensible mechanism to enrich the logs and handle the audit output.

## Features

 - You can use the `Log` method that logs an event immediately.
 - It provides asynchronous versions of the operations that save audit logs.
 - You can also control the creation and saving logic by creating a manual `AuditScope`.
 - It generates an output (`AuditEvent`) for each operation.

## Audit Scope

The `AuditScope` is the main object of this framework, and it encapsulates an audit event, controlling its life cycle. 

The `AuditScope` provides the options.

| Option         | Type         | Description                                                             |
| :--------------| :------------| :-----------------------------------------------------------------------|
| EventType      | string       | A string representing the type of the event
| TargetGetter   | Func<object> | Target object getter (a func that returns the object to track)
| ExtraFields    | object       | Anonymous object that contains additional fields to be merged into the audit event
| DataProvider   | AuditDataProvider | The data provider to use. Defaults to the DataProvider configured on Audit.Core.Configuration.DataProvider
| CreationPolicy | EventCreationPolicy | The creation policy to use. Default is InsertOnEnd
| IsCreateAndSave| bool         | Value indicating whether this scope should be immediately ended and saved after creation. Default is false
| AuditEvent     | AuditEvent   | Custom initial audit event to use. By default, it will create a new instance of basic AuditEvent
| SkipExtraFrames| int          | Value used to indicate how many frames in the stack should be skipped to determine the calling method. Default is 0
| CallingMethod  | MethodBase   | Specific calling method to store on the event. Default is to use the calling stack to determine the calling method.

The `AuditEvent` is an extensible information container of an audited operation. 

## Installation

You can easily install it from the **Package Manager Console** window by running the following command.

```csharp
PM> Install-Package Audit.EntityFramework.Core
```
