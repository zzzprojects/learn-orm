---
PermaID: 100000
Name: Overview
---

# Overview

Microsoft SQL Server Profiler is a graphical user interface to SQL Trace for monitoring an instance of the Database Engine or Analysis Services. 

 - You can capture and save data about each event to a file or table to analyze later. 
 - It allows you to select the events you want to monitor and where you want the output to be saved without having to know all the system stored procedures that are a part of SQL Trace.
 - You can monitor a production environment to see which stored procedures are affecting performance by executing too slowly. 
 - Without this tool, you would have to go through the tedious process of manually setting up each event and filter with individual stored procedure calls for every event you want configuring in your trace.

SQL Server Profiler also supports auditing the actions performed on instances of SQL Server. Audits record security-related actions for later review by a security administrator.

## Why SQL Profiler?

SQL Profiler has many uses, but the main purpose is to monitor the activity in your SQL Server instance. 

 - It gives you the ability to monitor anything from regular user activity/transactions to locks/deadlocks and system errors. 
 - You can also perform proactive maintenance on your SQL Server instance by using SQL Profiler to identify any poor performing queries so they can be analyzed and tuned or you could use it to capture a large time frame of activity so it could be used for replay on a test system. 
 - It can be also used to perform auditing on your SQL Server instance. 
 - You can define login/logout events so you can see who is accessing your instance and what systems they are accessing it from. 
 - You can also capture all DDL events which would give you a log of all the changes that are made to your environment.

## Deprecation

SQL Trace and SQL Server Profiler are deprecated. 

 - The `Microsoft.SqlServer.Management.Trace` namespace that contains the Microsoft SQL Server **Trace** and **Replay** objects are also deprecated.
 - It will be removed in a future version of Microsoft SQL Server. 
 - Avoid using this feature in new development work, and plan to modify applications that currently use this feature.
  You can use **Extended Events** as alternatives to create traces over a Database Engine.

