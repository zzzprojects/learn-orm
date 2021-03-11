---
PermaID: 100011
Name: Update Flat File Connection Manager
---

# Update Flat File Connection Manager

That Flat File connection manager is configured to statically load a single file. To enable the Flat File connection manager to iteratively load files, you change the `ConnectionString` property of the connection manager to use the user-defined variable `User::varFileName`, which contains the path of the file to be loaded at run time.

 - By modifying the connection manager to use the value of the user-defined variable to change the `ConnectionString` property, the connection manager connects to different flat files. 
 - At run time, each iteration of the **Foreach Loop** container updates the `User::varFileName` variable. 
 - Updating the variable, in turn, causes the connection manager to connect to a different flat file, and the data flow task to process a different set of data.

## Configure the Flat File to use a Variable

To configure the Flat File connection manager to use a variable, open the **Package Explorer**

<img src="images/update-flat-file-connection-manager-1.png" alt="Drag Foreach Loop Container">

In the **Connection Managers** pane, right-click **Sample Flat File Source Data**, and select **Properties**.

<img src="images/update-flat-file-connection-manager-2.png" alt="PackagePath in Properties window">

In the **Properties** window make sure the **PackagePath** starts with `\Package.Connections`. If not, in the **Connection Managers** pane, right-click **Sample Flat File Source Data**, and select **Convert to Package Connection**.

<img src="images/update-flat-file-connection-manager-6.png" alt="Convert to Package Connection">

In the **Properties** window, for **Expressions**, select the empty cell, and then select the `...` button which will open the following dialog.

<img src="images/update-flat-file-connection-manager-3.png" alt="Property Expressions Editor dialog">

In the **Property Expressions Editor** dialog, in the **Property** column, select **ConnectionString** from the dropdown list.

<img src="images/update-flat-file-connection-manager-4.png" alt="Property Expressions Editor dialog">

In the **Expression** column, select the ellipsis button `(...)` to open the **Expression Builder** dialog box.

<img src="images/update-flat-file-connection-manager-5.png" alt="Expression Builder dialog">

In the Expression Builder dialog, expand the **Variables and Parameters** node.

<img src="images/update-flat-file-connection-manager-7.png" alt="Variables and Parameters">

Drag the variable `User::varFileName` into the Expression box and click **OK** button to close the **Expression Builder** dialog.

<img src="images/update-flat-file-connection-manager-8.png" alt="ConnectionString variable configured">

Select **OK** again to close the **Property Expressions Editor** dialog.

## Test Package

To test the package, go to the **Debug** menu, select **Start Debugging**.

<img src="images/update-flat-file-connection-manager-9.png" alt="Executed successfully">

You can see the Package executed successfully. You can verify the status of each loop in the **Output** window, or by selecting the **Progress** tab. For example, you can see that 1,097 rows were added to the destination table from the file `Currency_VEB.txt`.

 