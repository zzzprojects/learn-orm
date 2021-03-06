---
PermaID: 100004
Name: Organize Columns
---

# Organize Columns

You can group data columns in a trace from the **Trace File Properties dialog**, or when you define a trace. 

 - It enables you to analyze SQL Server Profiler trace output better.
 - It also enables you to either group the trace events or group and aggregate them by the data columns.

## To Group Data Columns

Open an existing trace file or table, go to the **File** menu, and select **Properties**.

<img src="images/organize-columns-1.png" alt="Trace Table Properties">

On the **Events Selection** tab, click **Organize Columns** button.

<img src="images/organize-columns-2.png" alt="Organize Columns">

In the **Organize Columns** dialog, select the columns you want to display in a group and click **Up** to move them under Groups.

<img src="images/organize-columns-3.png" alt="Organize Columns">

After you have moved all the columns you want to move under **Groups**, you can use the **Up** and **Down** buttons to rearrange their order.

When you move the data column names into the **Groups** list, the displayed trace is first organized by the values in the top-most data column appearing in the **Groups** list, then by the second data column in the **Groups** list, and so on.

Click **OK** in the **Organize Columns** dialog, and then click **OK** in the **Trace Table Properties** dialog.

<img src="images/organize-columns-4.png" alt="SQL Server Profiler">

You can see that the data columns are reorganized in the displayed trace. 

 - In the **Groups** list, the first column is data column you moved to the top-most position in the trace display from left to right.
 - The rows in the trace are organized in ascending order by the values in the data columns that you included in the Groups list. 
 - The columns chosen for grouping remain fixed in the display, but you can scroll right or left to view the other columns.

## To Group and Aggregate Data Columns

Open an existing trace file or table, and go to the **File** menu and select **Properties**.

<img src="images/organize-columns-1.png" alt="Trace Table Properties">

On the **Events Selection** tab, click **Organize Columns** button.

<img src="images/organize-columns-2.png" alt="Organize Columns">

In the **Organize Columns** dialog, select one column you want to group and aggregate the displayed trace events. 

 - Click **Up** to move the column name under **Groups**. 
 - You can use the **Up** and **Down** buttons to rearrange the remaining columns under **Columns** if needed.

LetThe data column you moved to the top-most positionL
The data column you moved to the top-most position}"L_'s move the **ClientProcessID** under the groups and rearrange all others under columns as shown below.
Pl-img src="images/organize-columns-5.png" alt="Organize Columns">

Click **OK** in the **Organize Columns** dialog, and then click **OK** in the **Trace Table Properties** dialog.

<img src="images/organize-columns-6.png" alt="SQL Server Profiler">

You can see that the data columns are reorganized in the displayed trace. All other data column events are aggregated under the data column that you moved into the **Groups** list. 

Click the plus sign (`+`) to the left of the event in the data column you chose for aggregation to expand it and view all events of that type. 

<img src="images/organize-columns-7.png" alt="SQL Server Profiler">
 
The column chosen for aggregation remains fixed in the display, but you can scroll right or left to view the other columns.

To revert to a normal view of the trace data, click **Aggregated View** or **Grouped View** on the **View** menu, which cancels the selection. 

<img src="images/organize-columns-8.png" alt="SQL Server Profiler">

If you want to revert to the aggregated view, click **Aggregated View** on the **View** menu again to reselect it.
