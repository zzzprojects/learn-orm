---
PermaID: 100003
Name: Create User-defined Type
---

# Create User-defined Type

User-defined table type will allow you to declare table structure as a type in SQL Server, which may be used as a parameter for a stored procedure. 

The following code defines a user-defined table type that allows you to pass the data table as a parameter.

```csharp
CREATE TYPE [dbo].[EmployeeUDT] AS TABLE (
    [Name] NVARCHAR (MAX) NULL,
    [Age]  INT            NULL,
    [Salary]  INT         NULL);
```

Let's execute the above SQL, and you will see that the UDT is created in your database.

<img src="images/udt-1.png" alt="Create a UDT">

## Create UDT Type Class

To interact with the database using the UDT type, we need to create a class in your project that represents the user-defined table type. We will also decorate the class with `[UserDefinedTableType("EmployeeUDT")]` attribute as shown below.

```csharp
[UserDefinedTableType("EmployeeUDT")]
public class EmployeeUDT
{
    [UserDefinedTableTypeColumn(1)]
    public string Name { get; set; }
    [UserDefinedTableTypeColumn(2)]
    public int Age { get; set; }
    [UserDefinedTableTypeColumn(3)]
    public int Salary { get; set; }
}
```

You can see that we have also decorated the class properties with `[UserDefinedTableTypeColumn()]` attribute.
