---
PermaID: 100007
Name: Add and Configure the Lookup Transformations
---

# Add and Configure the Lookup Transformations

We have configured the Flat File source to extract data from the source file, now we need to define the Lookup transformations to obtain the values for `CurrencyKey` and `DateKey`. 

 - A Lookup transformation performs a lookup by joining data in the specified input column to a column in a reference dataset. 
 - The reference dataset can be an existing table or view, a new table, or the result of an SQL statement. 
 - Here, the Lookup transformation uses an OLE DB connection manager to connect to the database that contains the source data of the reference dataset.

In this article, we will add and configure the following two Lookup transformation components to the package.

 - [Lookup Currency Key Transformation](#lookup-currency-key-transformation)
 - [Lookup Date Key Transformation](#lookup-date-key-transformation)

## Lookup Currency Key Transformation

A transformation that does a lookup of values from the `CurrencyKey` column of the `DimCurrency` dimension table, based on matching `CurrencyID` column values from the flat file.

In the **SSIS Toolbox**, expand **Common**, and then drag **Lookup** onto the design surface of the **Data Flow** tab. 

<img src="images/lookup-transformations-1.png" alt="Drag Lookup">

Place **Lookup** directly below the **Extract Sample Currency Data** source.

Select the *Extract Sample Currency Data** flat file source and drag its blue arrow onto the newly added **Lookup** transformation to connect the two components.

<img src="images/lookup-transformations-2.png" alt="Connect data source to lookup">

On the **Data Flow** design surface, select **Lookup** in the Lookup transformation, and change the name to Lookup Currency Key.

<img src="images/lookup-transformations-3.png" alt="Change lookup name">

Double-click the **Lookup Currency Key** transformation to display the **Lookup Transformation Editor**.

<img src="images/lookup-transformations-4.png" alt="General page options">

On the **General** page, Select **Full cache** and in the **Connection type** area, select **OLE DB connection manager**.

On the **Connection** page, make sure that in the **OLE DB connection manager** dialog box, the **\*.AdventureWorksDW2017** is displayed

<img src="images/lookup-transformations-5.png" alt="Select OLE DB connection manager">

Select **Use results of an SQL query**, and then enter the following SQL statement.

```csharp
SELECT * FROM [dbo].[DimCurrency]
WHERE [CurrencyAlternateKey]
IN ('ARS', 'AUD', 'BRL', 'CAD', 'CNY',
    'DEM', 'EUR', 'FRF', 'GBP', 'JPY',
    'MXN', 'SAR', 'USD', 'VEB')
```

Click on the **Preview** to verify the query results.

<img src="images/lookup-transformations-6.png" alt="Preview query results">

Now go to the **Columns** page and you will see two panels.

<img src="images/lookup-transformations-7.png" alt="Panels">

Drag the `CurrencyID` from the **Available Input Columns** panel and drop it on `CurrencyAlternateKey` in the **Available Lookup Columns** panel .

<img src="images/lookup-transformations-8.png" alt="Connect CurrencyID with CurrencyAlternateKey">

In the **Available Lookup Columns** list, select the check box to the left of **CurrencyKey** and click on the **OK** button.

Right-click the **Lookup Currency Key** transformation and select **Properties**. In the **Properties** window, verify that the **LocaleID** property is **English (United States)** and the **DefaultCodePage** property is **1252**.

<img src="images/lookup-transformations-9.png" alt="Properties window">

## Lookup Date Key Transformation

A transformation that does a lookup of values from the `DateKey` column of the `DimDate` dimension table, based on matching `CurrencyDate` column values from the flat file.

In the **SSIS Toolbox**, drag another **Lookup** and place it directly below the **Lookup Currency Key** transformation.

<img src="images/lookup-transformations-10.png" alt="Drag another lookup">

Select the **Lookup Currency Key** transformation and drag its blue arrow onto the new Lookup transformation to connect the two components.

<img src="images/lookup-transformations-11.png" alt="Input Output Selection dialog">

In the **Input Output Selection** dialog, select **Lookup Match Output** in the **Output** dropdown list, and then select **OK**.

Change the name of the newly added Lookup transformation by right-clicking on it and choose **Rename**.

Type **Lookup Date Key** in the text area.

<img src="images/lookup-transformations-12.png" alt="Change the name of the lookup">

Double-click the **Lookup Date Key** transformation.

<img src="images/lookup-transformations-13.png" alt="General page option">

On the **General** page, select **Partial cache**. Now go the **Connection** page.

<img src="images/lookup-transformations-14.png" alt="Select OLE DB connection manager">

In the **OLEDB connection manager** dropdown, ensure that **\*.AdventureWorksDW2017** is displayed, and in the **Use a table or view** dropdown, select `[dbo].[DimDate]`.

On the **Columns** page you will see two panels.

<img src="images/lookup-transformations-15.png" alt="Panels">

Drag the `CurrencyDate` from the **Available Input Columns** panel and drop it on `FullDateAlternateKey` in the **Available Lookup Columns** panel.

<img src="images/lookup-transformations-16.png" alt="Connect CurrencyDate with FullDateAlternateKey">

In the **Available Lookup Columns** list, select the check box to the left of `DateKey`.

Now go to the **Advanced** page.

<img src="images/lookup-transformations-17.png" alt="Review the caching options"> 

Review the caching options and click **OK** button.

Right-click the **Lookup Date Key** transformation and select **Properties**. In the **Properties** window, verify that the **LocaleID** property is **English (United States)** and the **DefaultCodePage** property is **1252**.

<img src="images/lookup-transformations-18.png" alt="Properties window"> 
