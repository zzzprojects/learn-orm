---
PermaID: 100005
Name: Create Stored Procedure with Output Parameter
---

# Create Stored Procedure with Output Parameter

A stored procedure can have many output parameters. In addition, the output parameters can be in any valid data type e.g., `integer`, `date`, and varying character. So let's create a stored procedure with an output parameter.

```csharp
CREATE PROCEDURE GetMaxSalary
	@MaxSalary INT OUTPUT
AS
BEGIN

Select @MaxSalary = MAX(Salary) FROM Employees;

END
```

Now we also need to create a class that represents a stored procedure with an output parameter.

```csharp
[StoredProcedure("GetMaxSalary")]
public class GetMaxSalary
{
    [StoredProcedureParameter(SqlDbType.Int, Direction = ParameterDirection.Output)]
    public int MaxSalary { get; set; }
}
```

The following code retrieves the maximum salary from the employees' table by executing the stored procedure with the output parameter.

```csharp
public static void Example1()
{
    using (var context = new EmployeeContext())
    {
        var sp = new GetMaxSalary();

        context.Database.ExecuteStoredProcedure(sp);

        Console.WriteLine("Maximum Salary: {0}", sp.MaxSalary);
    }
}
```

Now when you run your application and you will see the following output.

```csharp
Maximum Salary: 35000
```
