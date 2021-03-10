---
PermaID: 100008
Name: Add and Configure the OLE DB Destination
---

# Add and Configure the OLE DB Destination

The package created in the previous articles can now extract data from the flat file source and transform that data into a format compatible with the destination. Now we need to load the transformed data into the destination. 

 - To load the data, we need to add an OLE DB destination to the data flow. 
 - The OLE DB destination can use a database table, view, or a SQL command to load data into a variety of OLE DB-compliant databases.

To add and configure an OLE DB destination to use the OLE DB connection manager that we have previously created, expand **Other Destinations** in the **SSIS Toolbox**. 

<img src="images/ole-db-destination-1.png" alt="Drag OLE DB Destination">

Drag **OLE DB Destination** onto the design surface of the **Data Flow** tab and place the **OLE DB Destination** directly below the **Lookup Date Key** transformation.

Select the **Lookup Date Key** transformation and drag its blue arrow over to the new **OLE DB Destination** to connect the two components.

<img src="images/ole-db-destination-2.png" alt="Input Output Selection dialog">

In the **Input Output Selection** dialog, select **Lookup Match Output** in the **Output** dropdown list, and then select **OK**.

<img src="images/ole-db-destination-3.png" alt="Connected OLE DB Destination">

Change the name of the newly added **OLE DB Destination** component by right-clicking on it and choose **Rename**.

Type **Sample OLE DB Destination** in the text area.

<img src="images/ole-db-destination-4.png" alt="Change the name of the OLE DB Destination">

Double-click **Sample OLE DB Destination** and it will open the **OLE DB Destination Editor** dialog. 

<img src="images/ole-db-destination-5.png" alt="OLE DB Destination Editor">

On the **OLE DB Destination Editor** dialog, Make sure that **\*.AdventureWorksDW2017** is selected in the **OLE DB Connection manager** dropdown and in the **Name of the table or the view** dropdown, select `[dbo].[FactCurrencyRate]`.

If a table named `NewFactCurrencyRate` currently exists, delete it now and then select the **New** button to create a new table. 

<img src="images/ole-db-destination-6.png" alt="Create Table">

Change the name of the table in the script from **Sample OLE DB Destination** to **NewFactCurrencyRate**. 

<img src="images/ole-db-destination-7.png" alt="Create Table">

Click on the **OK** button and you will see that the **Name of the table or the view** automatically changes to **NewFactCurrencyRate**.

<img src="images/ole-db-destination-8.png" alt="Table Created">

Now go to the **Mappings** tab.

<img src="images/ole-db-destination-9.png" alt="Mappings tab">

Verify that the `AverageRate`, `CurrencyKey`, `EndOfDayRate`, and `DateKey` input columns are mapped correctly to the destination columns. If same-named columns are mapped, the mapping is correct. Click on the **OK** button.

Right-click the **Sample OLE DB Destination** destination and select **Properties**. In the **Properties** window, verify that the **LocaleID** property is **English (United States)** and the **DefaultCodePage** property is **1252**.

<img src="images/ole-db-destination-10.png" alt="Properties window"> 
