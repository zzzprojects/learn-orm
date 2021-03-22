---
PermaID: 100003
Name: Export Data
---

# Export Data

SQL Server Management Studio (SSMS) provides the Export Wizard task, which you can use to copy data from one data source to another. Let's open SQL Server Management Studio and connect to the database. 

<img src="images/export-data-1.png" alt="Connect database in SSMS">

Go to the **Object Explorer**, right-click on the database you want to export to Excel, and choose **Tasks > Export Data** to export table data in SQL.

<img src="images/export-data-2.png" alt="Choose Task > Export Data">

It will open **SQL Server Import Export Wizard** dialog.

<img src="images/export-data-3.png" alt="SQL Server Import Export Wizard">

Click the **Next** button, and you need to click on the **Data source** drop-down to choose the data source.

<img src="images/export-data-4.png" alt="Set data source">

 - Select **SQL Server Native Client 11.0** as a data source. 
 - In the **Server name** drop-down, select a SQL Server instance. 
 - In the **Authentication** section, choose **Use Windows Authentication** for the data source connection.
 - From the **Database** drop-down, select a database from which data will be exported.

After everything is set, click the **Next** button. 

<img src="images/export-data-5.png" alt="Set destination">

On the **Choose a Destination** dialog, choose **Microsoft Excel** from the **Destination** drop-down. You will also need to choose the Excel file path and version as you need and then click the **Next** button.

<img src="images/export-data-6.png" alt="Specify Table Copy or Query">

On the **Specify Table Copy or Query** dialog, select **Copy data from one or more tables or views** and then click the **Next** button.

<img src="images/export-data-7.png" alt="Select Source Table and Views">

In the **Select Source Table and Views** window, you can choose one or more tables and views from which you want to export SQL Server data to Excel. Let's select the `DimCustomer` and click the **Preview** button to preview which data will be generated to an Excel file. 

<img src="images/export-data-8.png" alt="Preview data">

Click the **OK** and then click the **Next** button.

<img src="images/export-data-9.png" alt="Save and Run Package"> 

On the **Save and Run Package** dialog, select the **Run immediately** and then click the **Next** button.

<img src="images/export-data-10.png" alt="Complete the Wizard"> 

On the **Complete the Wizard** dialog, you can check all the settings set during of exporting process. If everything is right, click the **Finish** button to start exporting the SQL database to Excel.

<img src="images/export-data-11.png" alt="Exported data"> 

You can view the exporting process. When it completes, click on the **Close** button and open the `CustomerData.xls` file.

<img src="images/export-data-12.png" alt="Open Excel file"> 
