---
PermaID: 100047
Name: Database Operations
---

# Database Operations

Nowadays, you can't imagine any application without a database. If your application needs to access data from the database, you will need to perform some database operations.

 - In any programming language, accessing Data from a database is one of the important aspects. 
 - It is an absolute necessity for any programming language to have the ability to work with databases. 
 - VB.NET can work with a majority of databases, the most common database is Microsoft SQL Server. 

## SqlConnection

VB.NET provides a `SqlConnection` class which represents a connection to a SQL Server database, it cannot be inherited.

 - A `SqlConnection` object represents a unique session to a SQL Server data source. 
 - With a client/server database system, it is equivalent to a network connection to the server. 
 - It is used together with `SqlDataAdapter` and `SqlCommand` to increase performance when connecting to a Microsoft SQL Server database.

## Create Database

To create a database, let's open the **SQL Server Object Explorer**, expand the **SQL Server** and right-click on the **Databases** and select the **Add New Database**.

<img src="images/database-operations-1.png">

It will open the **Create Database** dialog.

<img src="images/database-operations-2.png">

Enter the database name such as **MyTestDb** and click the **Ok** button. Now right-click on the newly created database and select **New Query...** It will open the query editor, let's run the following script in the query editor.

```csharp
CREATE TABLE [dbo].[Authors] (
    [AuthorId] INT            NOT NULL PRIMARY KEY,
    [Name]     NVARCHAR (MAX) NULL
);

INSERT INTO [dbo].[Authors] VALUES (1, 'Mark');
INSERT INTO [dbo].[Authors] VALUES (2, 'John');
INSERT INTO [dbo].[Authors] VALUES (3, 'Stella');
```

It will create a table with the name `Authors` and add three records to that table. To check the data in the database table, right-click on the `Authors` table in **SQL Server Object Explorer**.

<img src="images/database-operations-3.png">

Select the **View Data** option and it will display all the records. 

<img src="images/database-operations-4.png">

## Connect Database

To connect to the SQL database, you can use the following code. 

```csharp
Dim connectionString As String = "Data Source=(localdb)\ProjectsV13;Initial Catalog=MyTestDb;Integrated Security=True;"

Using connection As SqlConnection = New SqlConnection(connectionString)
    connection.Open()
    
    'Code here
End Using
```

The above code will create a new connection to the SQL Server database that will be connected using the connection string. To ensure that connections are always closed, open the connection inside of a `using` block.

### Read Data From Database

Let's add some code to read data from the database we created.

```csharp
Public Sub ReadData()
    Dim connectionString As String = "Data Source=(localdb)\ProjectsV13;Initial Catalog=MyTestDb;Integrated Security=True;"

    Using connection As SqlConnection = New SqlConnection(connectionString)
        connection.Open()
        Dim sql As String = "SELECT * FROM Authors"
        Dim cmd As SqlCommand = New SqlCommand(sql, connection)
        Dim dreader As SqlDataReader = cmd.ExecuteReader()

        While dreader.Read()
            Console.WriteLine(dreader.GetValue(0) & ", " + dreader.GetValue(1))
        End While
    End Using
End Sub
```

Let's run the above code and you will see the following output.

```csharp
1, Mark
2, John
3, Stella
```

## Write Data to Database

Now let's insert one more record into the database and then read all the records using the following code.

```csharp
Public Sub InsertDataAndThenReadData()
    Dim connectionString As String = "Data Source=(localdb)\ProjectsV13;Initial Catalog=MyTestDb;Integrated Security=True;"

    Using connection As SqlConnection = New SqlConnection(connectionString)
        connection.Open()
        Dim sql As String = "INSERT INTO [dbo].[Authors] VALUES (4, 'Smith')"
        Dim cmd As SqlCommand = New SqlCommand(sql, connection)
        Dim adap As SqlDataAdapter = New SqlDataAdapter()
        adap.InsertCommand = New SqlCommand(sql, connection)
        adap.InsertCommand.ExecuteNonQuery()
        sql = "SELECT * FROM Authors"
        cmd = New SqlCommand(sql, connection)
        Dim dreader As SqlDataReader = cmd.ExecuteReader()

        While dreader.Read()
            Console.WriteLine(dreader.GetValue(0) & ", " + dreader.GetValue(1))
        End While
    End Using
End Sub
```

Let's run the above code and you will see the following output.

```csharp
1, Mark
2, John
3, Stella
4, Smith
```

For more information about file handling, visit [https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlconnection](https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlconnection)

All the examples related to the database operations are available in the `DatabaseOperations.cs` file of the source code. Download the source code and try out all the examples for better understanding.
