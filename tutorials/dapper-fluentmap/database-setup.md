---
PermaID: 100002
Name: Database Setup
---

# Database Setup

To use **Dapper.FluentMap**, we need to create a database first, and then we will perform various database operations using the **Dapper.FluentMap** library.

The SQL `CREATE DATABASE` statement is used to create a new SQL database.

```csharp
USE [master]
GO

CREATE DATABASE [BookStoreDb]

GO

USE [BookStoreDb]

GO

CREATE TABLE [dbo].[Authors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[strFirstName] [nvarchar](450) NULL,
	[strLastName] [nvarchar](450) NULL,
	[Age] [int] NULL,
	[strCountry] [nvarchar](450) NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Books](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[strTitle] [nvarchar](450) NULL,
	[strCategory] [nvarchar](max) NULL,
	[AuthorId] [int] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
```

It will create a `BookStoreDb` database that contains two tables. Now we need to insert some data into these tables, which can be used later. 

The following SQL statements insert new records in the **Authors** and **Books** tables.

```csharp
USE [BookStoreDb]

GO

INSERT INTO Authors(strFirstName, strLastName, Age, strCountry) VALUES ('Cardinal','Tom B. Erichsen', 34, 'US');
INSERT INTO Authors(strFirstName, strLastName, Age, strCountry) VALUES ('William','Shakespeare', 61, 'UK');
INSERT INTO Authors(strFirstName, strLastName, Age, strCountry) VALUES ('Robert','T. Kiyosaki', 53, 'Japan');

INSERT INTO Books(strTitle, strCategory, AuthorId) VALUES ('Introduction to Machine Learning', 'Software', 1);
INSERT INTO Books(strTitle, strCategory, AuthorId) VALUES ('Introduction to Computing', 'Software', 1);
INSERT INTO Books(strTitle, strCategory, AuthorId) VALUES ('Romeo and Juliet', 'Humor & Entertainment', 2);
INSERT INTO Books(strTitle, strCategory, AuthorId) VALUES ('The Tempest', 'Fiction', 2);
INSERT INTO Books(strTitle, strCategory, AuthorId) VALUES ('The Winter''s Tale : Third Series', 'Fiction', 2);
INSERT INTO Books(strTitle, strCategory, AuthorId) VALUES ('Rich Dad, Poor Dad', 'Economics', 3);
```

Let's try the following queries to test the data in the database.

```csharp
Select * From Authors;

Select * From Books;
```

Let's click on the **Execute** button, and you will see the results of the above queries.

<img src="images/database-setup.png" alt="Database Setup">

In the `Program` class, define the static variable, which contains the connection string of the database.

```csharp
static string ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=BookStoreDb;Integrated Security=True;";
```