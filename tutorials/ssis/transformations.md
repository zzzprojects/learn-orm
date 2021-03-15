---
PermaID: 100019
Name: Transformations
---

# Transformations

SQL Server Integration Services transformations are the components in the data flow of a package that aggregate, merge, distribute, and modify data. Transformations can also perform lookup operations and generate sample datasets. 

## Business Intelligence Transformations

The following transformations perform business intelligence operations such as cleaning data, mining text and running data mining prediction queries.

| Transformation                     | Description                                                                              |
| :----------------------------------| :----------------------------------------------------------------------------------------|
| Slowly Changing Dimension Transformation | The transformation that configures the updating of a slowly changing dimension.    |
| Fuzzy Grouping Transformation      | The transformation that standardizes values in column data.                              |
| Fuzzy Lookup Transformation        | The transformation that looks up values in a reference table using a fuzzy match.        |
| Term Extraction Transformation     | The transformation that extracts terms from text.                                        |
| Term Lookup Transformation         | The transformation that looks up terms in a reference table and counts terms extracted from the text.  |
| Data Mining Query Transformation   | The transformation that runs data mining prediction queries.                             |
| DQS Cleansing Transformation       | The transformation that corrects data from a connected data source by applying rules that were created for the data source. |

## Row Transformations

The following transformations update column values and create new columns. The transformation is applied to each row in the transformation input.

| Transformation                     | Description                                                                              |
| :----------------------------------| :----------------------------------------------------------------------------------------|
| Character Map Transformation | The transformation that applies string functions to character data.
| Copy Column Transformation | The transformation that adds copies of input columns to the transformation output.
| Data Conversion Transformation | The transformation that converts the data type of a column to a different data type.
| Derived Column Transformation | The transformation that populates columns with the results of expressions.
| Export Column Transformation | The transformation that inserts data from a data flow into a file.
| Import Column Transformation | The transformation that reads data from a file and adds it to a data flow.
| Script Component | The transformation that uses a script to extract, transform, or load data.
| OLE DB Command Transformation | The transformation that runs SQL commands for each row in a data flow.

## Rowset Transformations

The following transformations create new rowsets. The rowset can include aggregate and sorted values, sample rowsets, or pivoted and unpivoted rowsets.

| Transformation                     | Description                                                                              |
| :----------------------------------| :----------------------------------------------------------------------------------------|
| Aggregate Transformation           | The transformation that performs aggregations such as AVERAGE, SUM, and COUNT.           |
| Sort Transformation                | The transformation that sorts data.                                                      |
| Percentage Sampling Transformation | The transformation that creates a sample data set using a percentage to specify the sample size. |
| Row Sampling Transformation        | The transformation that creates a sample data set by specifying the number of rows in the sample. |
| Pivot Transformation               | The transformation that creates a less normalized version of a normalized table.         |
| Unpivot Transformation             | The transformation that creates a more normalized version of a nonnormalized table.      |

## Split and Join Transformations

The following transformations distribute rows to different outputs, create copies of the transformation inputs, join multiple inputs into one output, and perform lookup operations.

| Transformation                     | Description                                                                              |
| :----------------------------------| :----------------------------------------------------------------------------------------|
| Conditional Split Transformation   | The transformation that routes data rows to different outputs.                           |
| Multicast Transformation           | The transformation that distributes data sets to multiple outputs.                       |
| Union All Transformation           | The transformation that merges multiple data sets.                                       |
| Merge Transformation               | The transformation that merges two sorted data sets.                                     |
| Merge Join Transformation          | The transformation that joins two data sets using a `FULL`, `LEFT`, or `INNER` join.   |
| Lookup Transformation              | The transformation that looks up values in a reference table using an exact match.       |
| Cache Transform                    | The transformation that writes data from a connected data source in the data flow to a Cache connection manager that saves the data to a cache file. The Lookup transformation performs lookups on the data in the cache file. |
| Balanced Data Distributor Transformation | The transformation distributes buffers of incoming rows uniformly across outputs on separate threads to improve the performance of SSIS packages running on multi-core and multi-processor servers. |

## Auditing Transformations

Integration Services includes the following transformations to add audit information and count rows.

| Transformation                     | Description                                                                              |
| :----------------------------------| :----------------------------------------------------------------------------------------|
| Audit Transformation               | The transformation that makes information about the environment available to the data flow in a package. |
| Row Count Transformation           | The transformation that counts rows as they move through it and stores the final count in a variable. | 

