---
PermaID: 100003
Name: Add and Configure an OLE DB
---

# Add and Configure an OLE DB

After you add a Flat File connection manager to connect to the data source, you add an OLE DB connection manager to connect to the data destination. An OLE DB connection manager enables a package to extract data from or load data into any OLE DB-compliant data source. Using an OLE DB connection manager, you can specify the server, the authentication method, and the default database for the connection.

In this task, you create an OLE DB connection manager that uses Windows Authentication to connect to the local instance of AdventureWorksDW2012. This OLE DB connection manager is also referenced by other components that you create later in this tutorial, such as the Lookup transformation and the OLE DB destination.

## Add and configure an OLE DB connection manager

In the **Solution Explorer** pane, right-click on **Connection Managers** and select **New Connection Manager**.

<img src="images/ole-db-1.png" alt="New Connection Manager">

In the **Add SSIS Connection Manager** dialog, select OLEDB, then select Add.

<img src="images/ole-db-2.png" alt="Add SSIS Connection Manager">

In the **Configure OLE DB Connection Manager** dialog box, select **New**.

<img src="images/ole-db-3.png" alt="Configure OLE DB Connection Manager">

For **Server name**, enter `localhost` or any other server name which is created during SQL Server installation.

<img src="images/ole-db-4.png" alt="Connection Manager">

When you specify the server name, the connection manager connects to the default instance of SQL Server on the local computer. To use a remote instance of SQL Server, replace localhost with the name of the server to which you want to connect.

In the **Log on to the server** group, make sure that **Windows Authentication** is selected.

In the **Connect to a database** group, in the **Select or enter a database name** box, type or select **AdventureWorksDW2017**.

Select **Test Connection** to verify that the connection settings you have specified are valid.

<img src="images/ole-db-4.png" alt="Test Connection">

Select **OK**.

<img src="images/ole-db-5.png" alt="Test Connection">

Select **OK**.

<img src="images/ole-db-6.png" alt="Data connections">

In the **Connection Managers** pane, verify that **\*.AdventureWorksDW2012** is Added.

