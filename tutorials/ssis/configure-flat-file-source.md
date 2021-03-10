---
PermaID: 100006
Name: Configure Flat File Source
---

# Configure Flat File Source

A Flat File source is a data flow component that uses metadata defined by a Flat File connection manager. 

 - It specifies the format and structure of the data to be extracted from the flat file by a transform process. 
 - The Flat File source extracts data from a single flat file, using the format definitions in the Flat File connection manager.

Let's configure the Flat File source to use the **Sample Flat File Source Data** connection manager that is previously created.

To open the **Data Flow** designer, either double-click on the **Extract Sample Currency Data** data flow task, or select the **Data Flow** tab.

<img src="images/flat-file-source-1.png" alt="Data Flow tab">

In the **SSIS Toolbox**, expand **Other Sources**.

<img src="images/flat-file-source-1.png" alt="Data Flow tab">

Drag a Flat File Source onto the design surface of the Data Flow tab.

<img src="images/flat-file-source-2.png" alt="Flat File Source">

On the **Data Flow** design surface, right-click the newly added **Flat File Source** and choose **Rename**.

<img src="images/flat-file-source-3.png" alt="Change the name">

Change the name to **Extract Sample Currency Data**. Now double-click on the Flat File source to open the **Flat File Source Editor** dialog.

<img src="images/flat-file-source-4.png" alt="Sample Flat File Source Data">

In the **Flat file connection manager** field, select **Sample Flat File Source Data**.

Select the **Columns** tab and verify that the names of the columns are correct.

<img src="images/flat-file-source-5.png" alt="Verify column names">

Select **OK**.

Right-click the Flat File source and select **Properties**.

<img src="images/flat-file-source-6.png" alt="Properties window">

In the **Properties** window, verify that the **LocaleID** property is set to **English (United States)**.
