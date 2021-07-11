---
PermaID: 100004
Name: Stored Procedure
---

# Stored Procedure

A stored procedure is a prepared SQL code that you can save, so the code can be reused over and over again. So let's create a stored procedure that uses the user-defined table type as a parameter. The below code snippet will define `@UserDefinedTable` as parameters, and it is a user-defined table type parameter.

```csharp
CREATE PROCEDURE EmployeeInsertWithUDT 
	@UserDefinedTable EmployeeUDT READONLY
AS
BEGIN

INSERT INTO Employees
  (Name, Age, Salary)
SELECT Name, Age, Salary FROM @UserDefinedTable

END
```

It will create an `EmployeeInsertWithUDT` stored procedure and insert the list of employees' information like `Name`, `Age`, and `Salary` to the **Employees** table from the user-defined type which we will pass as a parameter.

## Create Class for Stored Procedure

To interact with the database using the stored procedure, we need to create another class that will represent a stored procedure, as shown below.

```csharp
[StoredProcedure("EmployeeInsertWithUDT")]
public class EmployeeInsertWithUDT
{
    [StoredProcedureParameter(SqlDbType.Udt)]
    public List<EmployeeUDT> UserDefinedTable { get; set; }
}
```

We need to decorate the class with `[StoredProcedure("EmployeeInsertWithUDT")]` attribute. We will also decorate the class properties with `[StoredProcedureParameter(SqlDbType.Udt)]` attribute.

The following example inserts some employees' data using the user-defined table type.

```csharp
public static void Example1()
{
    using (var context = new EmployeeContext())
    {
        var sp = new EmployeeInsertWithUDT();
        sp.UserDefinedTable = new List<EmployeeUDT>()
        {
            new EmployeeUDT() { Name = "Mark", Age = 32, Salary = 14000 },
            new EmployeeUDT() { Name = "Andy", Age = 59, Salary = 35000 },
            new EmployeeUDT() { Name = "Allan", Age = 23, Salary = 5000 },
            new EmployeeUDT() { Name = "John", Age = 41, Salary = 15000 }
        };
        context.Database.ExecuteStoredProcedure<EmployeeUDT>(sp);

        int employees = context.Employees.Count();

        Console.WriteLine("Total Employees: {0}", employees);
    }
}
```

Now when you run your application and you will see the following output.

```csharp
Total Employees: 9
```
