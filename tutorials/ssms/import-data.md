---
PermaID: 100004
Name: Import Data
---

# Import Data

SQL Server Management Studio (SSMS) provides the Import Wizard task which you can use to copy data from one data source to another. We will import data from the excel file which contains the following sample currency data.

<img src="images/import-data.png" alt="Excel data">

Let's open SQL Server Management Studio and connect to the database. 

<img src="images/import-data-1.png" alt="Open SSMS">

Go to the **Object Explorer**, right-click on the **Databases**, and choose **New Database...** 

<img src="images/import-data-2.png" alt="New Database">

It will open the **New Database** dialog.

<img src="images/import-data-3.png" alt="New Database dialog">

Enter **CurrencyDB** as the name of the database and click on the **OK** button.

<img src="images/import-data-4.png" alt="New Database added">

Now in the **Object Explorer** you can see that a new **CurrencyDB** database is added, right-click on that database and choose **Tasks > Import Data**.

<img src="images/import-data-5.png" alt="Task > Import Data">

It will open **SQL Server Import Export Wizard** dialog.

<img src="images/import-data-6.png" alt="SQL Server Import Export Wizard">

On the **Choose a Data Source** dialog, choose **Microsoft Excel** from the **Destination** drop-down. You will also need to choose the Excel file path and version as you need and then, click the **Next** button.

<img src="images/import-data-7.png" alt="Choose a Data Source">

On the **Choose a Destination** dialog, select **SQL Server Native Client 11.0** as a data source. 

 - In the **Server name** drop-down, select a SQL Server instance. 
 - In the **Authentication** section, choose **Use Windows Authentication** for the data source connection.
 - From the **Database** drop-down, select a database where data will be imported.

After everything is set, click the **Next** button. 

<img src="images/import-data-8.png" alt="Specify Table Copy or Query">

On the **Specify Table Copy or Query** dialog, select **Copy data from one or more tables or views** and then click the **Next** button.

<img src="images/import-data-9.png" alt="Select Source Table and Views">

In the **Select Source Table and Views** window, you can choose one or more tables and views from which you want to export SQL Server data to Excel. Let's select the `Currency` and click the **Preview** button to preview which data will be imported from an Excel file. 

<img src="images/import-data-10.png" alt="Preview data">

Click the **OK** and then click the **Next** button.

<img src="images/import-data-11.png" alt="Save and Run Package">

On the **Save and Run Package** dialog, select the **Run immediately** and then click the **Next** button.

<img src="images/import-data-12.png" alt="Complete the Wizard"> 

On the **Complete the Wizard** dialog, you can check all the settings set during of exporting process. If everything is right, click the **Finish** button to start exporting the SQL database to Excel.

<img src="images/import-data-13.png" alt="Imported data"> 

You can view the importing process, when it completes, click on the **Close** button.

<img src="images/import-data-14.png" alt="Imported data"> 

Now expand the **CurrencyDB** database and you will see the `Currency` table which contains three columns. You can also view the imported data by opening a **New Query** editor and specify any query and then execute it.

<img src="images/import-data-15.png" alt="Imported data"> 