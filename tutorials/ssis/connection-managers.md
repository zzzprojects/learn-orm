---
PermaID: 100003
Name: Connection Managers
---

# Connection Managers

## SSIS Connections?

Microsoft SQL Server Integration Services packages use connections to perform different tasks and to implement Integration Services features:

 - Connecting to source and destination data stores such as text, XML, Excel workbooks, and relational databases to extract and load data.
 - Connecting to SQL Server to perform maintenance and transfer tasks such as backing up databases and transferring logins.
 - Writing log entries in text and XML files and SQL Server tables and package configurations to SQL Server tables.
 - Connecting to SQL Server to create temporary work tables that some transformations require to do their work.
 - Connecting to Analysis Services projects and databases to access data mining models, process cubes and dimensions, and run DDL code.
 - Specifying existing or creating new files and folders to use with Foreach Loop enumerators and tasks.
 - Connecting to message queues and Windows Management Instrumentation (WMI), SQL Server Management Objects (SMO), Web, and mail servers.

## Connection Managers

Integration Services uses the connection manager as a logical representation of a connection. At design time, you set the properties of a connection manager to describe the physical connection that Integration Services creates when the package runs. 

 - A connection manager includes the `ConnectionString` property that you set at design time; at run time, a physical connection is created using the value in the connection string property.
 - A package can use multiple instances of a connection manager type, and you can set the properties on each instance. 
 - At run time, each instance of a connection manager type creates a connection that has different attributes.

### Types

SQL Server Integration Services provides different types of connection managers that enable packages to connect to a variety of data sources and servers:

 - There are built-in connection managers that Setup installs when you install Integration Services.
 - There are connection managers that are available for download from the Microsoft website.
 - You can create your custom connection manager if the existing connection managers do not meet your needs.

### Built-in Connection Managers

The following table lists the connection manager types that SQL Server Integration Services provides.

| Type               | Description                                                  |
| :------------------| :------------------------------------------------------------|
| ADO                | Connects to ActiveX Data Objects (ADO) objects.              |
| ADO.NET            | Connects to a data source by using a .NET provider.          |
| CACHE              | Reads data from the data flow or a cache file (.caw), and can save data to the cache file. |
| DQS                | Connects to a Data Quality Services server and a Data Quality Services database on the server. |
| EXCEL              | Connects to an Excel workbook file. |
| FILE               | Connects to a file or a folder. |
| FLATFILE           | Connect to data in a single flat file. |
| FTP                | Connect to an FTP server. |
| HTTP               | Connects to a webserver. |
| MSMQ               | Connects to a message queue. |
| MSOLAP100          | Connects to an instance of SQL Server Analysis Services or an Analysis Services project. |
| MULTIFILE          | Connects to multiple files and folders. |
| MULTIFLATFILE      | Connects to multiple data files and folders. |
| OLEDB              | Connects to a data source by using an OLE DB provider. |
| ODBC               | Connects to a data source by using ODBC. |
| SMOServer          | Connects to a SQL Server Management Objects (SMO) server. |
| SMTP               | Connects to an SMTP mail server. |
| SQLMOBILE          | Connects to a SQL Server Compact database. |
| WMI                | Connects to a server and specifies the scope of Windows Management Instrumentation (WMI) management on the server. |

## Package Level and Project Level Connection Managers

A connection manager can be created at the package level or the project level. 

 - The connection manager created at the project level is available to all the packages in the project. 
 - Whereas, connection manager created at the package level is available to that specific package.

You can use connection managers created at the project level in place of data sources to share connections to sources. 

 - To add a connection manager at the project level, the Integration Services project must use the project deployment model. 
 - When a project is configured to use this model, the **Connection Managers** folder appears in **Solution Explorer**, and the **Data Sources** folder is removed from **Solution Explorer**.
