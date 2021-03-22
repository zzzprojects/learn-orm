---
PermaID: 100005
Name: Create Database
---

# Create Database

The database is a collection of objects such as table, view, stored procedure, function, trigger, etc. In **Object Explorer**, connect to an instance of the SQL Server Database Engine and then expand that instance.

<img src="images/create-database-1.png" alt="Connect to SQL Server Instance">

Right-click **Databases**, and then click **New Database...**

<img src="images/create-database-2.png" alt="New Database">

On the **New Database** dialog, enter a database name. To create the database by accepting all default values, click the **OK** button. Otherwise, continue with the following optional steps.

To change the owner name, click **(...)** to select another owner.

To change the default values of the primary data and transaction log files, in the **Database files** grid, click the appropriate cell and enter the new value.

<img src="images/create-database-3.png" alt="New Database">

To change the collation of the database, select the **Options** page and then select a collation from the list.

<img src="images/create-database-4.png" alt="Select collation">

To change the recovery model, select a recovery model from the list on the **Options** page.

<img src="images/create-database-5.png" alt="Select recovery model">

To add a new filegroup, click the **Filegroups** page. Click **Add Filegroups** and then enter the values for the filegroup.

<img src="images/create-database-6.png" alt="Add Filegroups">

Once you are done with all the settings, click the **OK** button, and it will create the database.

<img src="images/create-database-6.png" alt="Database created">

## Using Transact-SQL

You can also create a database using Transact-SQL (T-SQL) by connecting to the **Database Engine**, and then from the Standard bar, click **New Query**. Copy and paste the following example into the query window and click **Execute**. 

```csharp
USE [master]
GO

CREATE DATABASE [BookStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookStore', 
	FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.ZZZPROJECT\MSSQL\DATA\BookStore.mdf' , 
	SIZE = 8192KB , 
	MAXSIZE = UNLIMITED, 
	FILEGROWTH = 65536KB )

 LOG ON 
( NAME = N'BookStore_log', 
	FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.ZZZPROJECT\MSSQL\DATA\BookStore_log.ldf' , 
	SIZE = 8192KB , 
	MAXSIZE = 2048GB , 
	FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
```

## Recommendations

 - The master database should be backed up whenever a user database is created, modified, or dropped.
 - When you create a database, make the data files as large as possible based on the maximum amount of data you expect in the database.
