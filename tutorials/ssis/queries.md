---
PermaID: 100011
Name: Queries
---

# Queries

The Execute SQL task, the OLE DB source, the OLE DB destination, and the Lookup transformation can use SQL queries. 

 - In the Execute SQL task, the SQL statements can create, update, and delete database objects and data; run stored procedures, and perform `SELECT` statements. 
 - In the OLE DB source and the Lookup transformation, the SQL statements are typically `SELECT` statements or `EXEC` statements. 
 - The latter most frequently run stored procedures that return result sets.

A query can be parsed to establish whether it is valid. When parsing a query that uses a connection to SQL Server, the query is parsed, executed, and the execution outcome is assigned to the parsing outcome. If the query uses a connection to data other than SQL Server, the statement is parsed only.

You can provide the SQL statement in the following ways:

 - Enter it directly in the designer.
 - Specify a connection to a file contains the statement.
 - Specify a variable that contains the statement.

## Direct Input SQL

Query Builder is available in the user interface for the Execute SQL task, the OLE DB source, the OLE DB destination, and the Lookup transformation. Query Builder offers the following advantages:

 - **Work visually or with SQL commands**

   - Query Builder includes graphical panes that compose your query visually and a text pane that displays the SQL text of your query. 
   - You can work in either the graphical or text panes. 
   - Query Builder synchronizes the views so that the query text and graphical representation always match.

 - **Join related tables**

   - If you add more than one table to your query, Query Builder automatically determines how the tables are related and construct the appropriate join command.

 - **Query or update databases**

   - You can use Query Builder to return data using Transact-SQL `SELECT` statements or to create queries that update, add, or delete records in a database.

 - **View and edit results immediately**

   - You can execute your query and work with a recordset in a grid that lets you scroll through and edit records in the database.

## SQL in Files

The SQL statement for the Execute SQL task can also reside in a separate file. 

 - You can write queries using tools such as the **Query Editor** in **SQL Server Management Studio**, save the query to a file, and then read the query from the file when running a package. 
 - The file can contain only the SQL statements to run and comments. 
 - To use a SQL statement stored in a file, you must provide a file connection that specifies the file name and location. 

## SQL in Variables

If the source of the SQL statement in the Execute SQL task is a variable, you provide the name of the variable that contains the query. 

 - The **Value** property of the variable contains the query text. 
 - You set the **ValueType** property of the variable to a string data type and then type or copy the SQL statement into the Value property.

## Query Builder 

You can use the **Query Builder** dialog to create a query for use in the Execute SQL task, the OLE DB source and the OLE DB destination, and the Lookup transformation. You can use Query Builder to perform the following tasks:

 - The Query Builder includes a pane that displays your query graphically and a pane that displays the SQL text of your query. You can work in either the graphical pane or the text pane. Query Builder synchronizes the views so that they are always current.
 - If you add more than one table to your query, it automatically determines how the tables are related and construct the appropriate join command.
 - You can use Query Builder to return data by using Transact-SQL SELECT statements and to create queries that update, add, or delete records in a database.
 - You can run your query and work with a recordset in a grid that allows you to scroll through and edit records in the database.