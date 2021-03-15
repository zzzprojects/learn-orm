---
PermaID: 100021
Name: Variables
---

# Variables

Variables store values that a SQL Server Integration Services package and its containers, tasks, and event handlers can use at run time. The scripts in the Script task and the Script component can also use variables. The precedence constraints that sequence tasks and containers into a workflow can use variables when their constraint definitions include expressions.

## Why Variables?

You can use variables in Integration Services packages for the following purposes.

 - Updating properties of package elements at run time. For example, you can dynamically set the number of concurrent executables that a Foreach Loop container allows.
 - Including an in-memory lookup table. For example, a package can run an Execute SQL task that loads a variable with data values.
 - Loading variables with data values and then using them to specify a search condition in a WHERE clause. For example, the script in a Script task can update the value of a variable that is used by a Transact-SQL statement in an Execute SQL task.
 - Loading a variable with an integer and then using the value to control looping within a package control flow. For example, you can use a variable in the evaluation expression of a For Loop container to control iteration.
 - Populating parameter values for Transact-SQL statements at run time. For example, a package can run an Execute SQL Task and then use variables to dynamically set the parameters in a Transact-SQL statement.
 - Building expressions that include variable values. For example, the Derived Column transformation can populate a column with the result obtained by multiplying a variable value by a column value.

## Types

Integration Services supports two types of variables. 

 - User-defined variables
 - System variables 

User-defined variables are defined by package developers, and system variables are defined by Integration Services. 

 - You can create as many user-defined variables as a package requires, but you cannot create additional system variables.
 - All the variables can be used in the parameter bindings that the Execute SQL task uses to map variables to parameters in SQL statements.

## Configure User-defined Variables

You can configure user-defined variables in the following ways.

 - Provide a name and description for the variable.
 - Specify a namespace for the variable.
 - Indicate whether the variable raises an event when its value changes.
 - Indicate whether the variable is read-only or read/write.
 - Use the evaluation result of an expression to set the variable value.
 - Create the variable in the scope of the package or a package object such as a task.
 - Specify the value and data type of the variable.
 - The only configurable option on system variables is specifying whether they raise an event when they change value.

### Properties of Variables

You can configure user-defined variables by setting the following properties in either the **Variables** window or the **Properties** window. Certain properties are available only in the **Properties** window.

| Option            | Description                                                                 |
| :-----------------| :---------------------------------------------------------------------------|
| Description       | Specifies the description of the variable.                                  |
| EvaluateAsExpression  | When the property is set to True, the expression provided is used to set the variable value. |
| Expression        | Specifies the expression that is assigned to the variable.                  |
| Name              | Specifies the variable name.                                                |
| Namespace         | Integration Services provides two namespaces, `User` and `System`. By default, custom variables are in the `User` namespace, and system variables are in the `System` namespace. You can create additional namespaces for user-defined variables and change the name of the `User` namespace, but you cannot change the name of the `System` namespace, add variables to the `System` namespace, or assign system variables to a different namespace. |
| RaiseChangedEvent | When the property is set to True, the OnVariableValueChanged event is raised when the value of the variable changes. |
| ReadOnly          | When the property is set to False, the variable is read\write.              |

You can use the Variables window to create and modify user-defined variables and view system variables.

| Option            | Description                                                                 |
| :-----------------| :---------------------------------------------------------------------------|
| Add Variable      | Add a user-defined variable.
| Move Variable     | Click a variable in the list, and then click Move Variable to change the variable scope. In the Select New Scope dialog box, select the package or a container, task, or event handler in the package, to change the variable scope.
| Delete Variable   | Select a variable from the list, and then click Delete Variable.
| Grid Options      | Click to open the Variable Grid Options dialog box where you can change the column selection and apply filters to the Variables window. For more information, see Variable Grid Options.
| Name              | View the variable name. You can update the name for user-defined variables.
| Scope             | View the scope of the variable. A variable has either the scope of the entire package or the scope of a container or task. The scope of the variable must be sufficient so that the variable is visible to any other tasks or components that need to read or set its value. You can change the scope by clicking the variable and then clicking Move Variable in the Variables window.
| Data Type         | View the data type of the variable. You can select a data type from the list for user-defined variables.
| Value             | View the variable value. You can update the value for user-defined variables. This value can be a literal or an expression, and the value can be a multi-line string. To assign an expression to the variable, click the ellipse button that is next to the Expression column in the Variables window.
| Namespace         | View the namespace name. User-defined variables are initially created in the User namespace, but you can change the namespace name in the Namespace field. To display this column, click Grid Options.
| Raise Change Event| Indicate whether to raise the OnVariableValueChanged event when a value changes. You can update the value for user-defined and system variables. By default, the Variables window does not list this column. To display this column, click Grid Options.
| Description       | View the variable description. You can change the description for user-defined variables. By default, the Variables window does not list this column. To display this column, click Grid Options.
| Expression        | View the expression assigned to the variable. To assign an expression, click the ellipse button.

If you assign an expression to a variable, a special icon marker displays next to the variable. This special icon marker also displays next to connection managers and tasks that have expressions set on them.
