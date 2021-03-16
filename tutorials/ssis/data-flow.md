---
PermaID: 100005
Name: Data Flow
---

# Data Flow

SQL Server Integration Services provides three different types of data flow components. 

 - Sources
 - Transformations
 - Destinations 

Sources extract data from data stores such as tables and views in relational databases, files, and Analysis Services databases. Transformations modify, summarize, and clean data. Destinations load data into data stores or create in-memory datasets.

## How It Works?

Integration Services provides paths that connect the output of one component to the input of another component. Paths define the sequence of components and let you add annotations to the data flow or view the source of the column.

 - You can connect data flow components by connecting the output of sources and destinations to the input of transformations and destinations. 
 - When constructing a data flow, you typically connect the second and subsequent components as you add them to the data flow. 
 - After you connect the component, the input columns are available for use in configuring the component. 
 - When no input columns are available, you will have to complete the configuration of the component after it is connected to the data flow. 

## Data Flow Implementation

Adding a Data Flow task to the control flow of a package is the first step in implementing a data flow in a package. 

 - A package can include multiple **Data Flow** tasks, each with its data flow. 
 - For example, if a package requires that data flows be run in a specified sequence or that other tasks be performed between the data flows, you must use a separate **Data Flow** task for each data flow.

After the control flow includes a Data Flow task, you can begin to build the data flow that a package uses. You can create a data flow using the following steps.

 - Adding one or more sources to extract data from files and databases and add connection managers to connect to the sources.
 - Adding the transformations that meet the business requirements of the package. A data flow is not required to include transformations.
 - Some transformations require a connection manager. For example, the Lookup transformation uses a connection manager to connect to the database that contains the lookup data.
 - Connecting data flow components by connecting the output of sources and transformations to the input of transformations and destinations.
 - Adding one or more destinations to load data into data stores such as files and databases and adding connection managers to connect to the data sources.
 - Configuring error outputs on components to handle problems.
