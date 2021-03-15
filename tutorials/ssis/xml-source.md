---
PermaID: 100020
Name: XML Source
---

# XML Source

The XML source reads an XML data file and populates the columns in the source output with the data.

 - The data in XML files frequently include hierarchical relationships. 
 - For example, an XML data file can represent catalogs and items in catalogs. 
 - Before the data can enter the data flow, the relationship of the elements in the XML data file must be determined, and output must be generated for each element in the file.

## Schemas

The XML source uses a schema to interpret the XML data. The XML source supports the use of an XML Schema Definition (XSD) file or inline schemas to translate the XML data into a tabular format. 

 - If you configure the XML source by using the XML Source Editor dialog box, the user interface can generate an XSD from the specified XML data file.
 - The schemas can support a single namespace only; they do not support schema collections.

## XML Source Editor

The XML Source Editor dialog uses the specified schema to generate the XML source outputs. 

 - You can specify an XSD file, use an inline schema, or generate an XSD from the specified XML data file. The schema must be available at design time.
 - The XML source generates tabular structures from the XML data by creating output for every element that contains other elements in the XML files. 
 - For example, if the XML data represents catalogs and items in catalogs, the XML source creates output for catalogs and output for each type of item that the catalogs contain. 
 - The output of each item will contain output columns for the attributes of that item.

## Configuration of the XML Source

The XML source supports three different data access modes. You can specify the file location of the XML data file, the variable that contains the file location, or the variable that contains the XML data.

 - The XML source includes the **XMLData** and **XMLSchemaDefinition** custom properties that can be updated by property expressions when the package is loaded.
 - The XML source supports multiple regular outputs and multiple error outputs.
 - SQL Server Integration Services includes the **XML Source Editor** dialog for configuring the XML source. This dialog box is available in SSIS Designer.
 - You can set properties through SSIS Designer or programmatically.
 - The **Advanced Editor** dialog reflects the properties that can be set programmatically.

## XML Source Editor (Connection Manager Page)

Use the Connection Manager page of the XML Source Editor to specify an XML file and the XSD that transforms the XML data.

### Static Options

You can specify any of the following methods for selecting data from the source as **Data access mode**.

| Value              | Description                                  |
| :------------------| :--------------------------------------------|
| XML file location  | Retrieve data from an XML file.              |
| XML file from variable | Specify the XML file name in a variable. |
| XML data from variable | Retrieve XML data from a variable.       |

## XML Source Custom Properties

The XML source has both custom properties and properties common to all data flow components.

The following table describes the custom properties of the XML source. All properties are read/write.

| Property name     | Data Type      | Description                                                                |
| :-----------------| :--------------| :--------------------------------------------------------------------------|
| AccessMode        | Integer        | The mode used to access the XML data.                                      |
| UseInlineSchema   | Boolean        | A value that indicates whether to use an inline schema definition within the XML source. The default value of this property is False. | 
| XMLData           | String         | The file or variables from which to retrieve the XML data. The value of this property can be specified by using a property expression.                |
| XMLSchemaDefinition | String       | The path and file name of the schema definition file (.xsd).               |

The value of this property can be specified by using a property expression.

The following table describes the custom properties of the output of the XML source. All properties are read/write.

| Property name     | Data Type      | Description                                                                |
| :-----------------| :--------------| :--------------------------------------------------------------------------|
| RowsetID          | String         | A value that identifies the rowset associated with the output.             |

The output columns of the XML source have no custom properties.
