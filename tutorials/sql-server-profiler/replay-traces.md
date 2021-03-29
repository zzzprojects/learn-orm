---
PermaID: 100006
Name: Replay Traces
---

# Replay Traces

The replay is the ability to reproduce activity that has been captured in a trace. When you create or edit a trace, you can save the trace to a file and replay it later. 

 - You can use SQL Server Profiler to replay trace activity from a single computer. 
 - For large workloads, use the Distributed Replay Utility to replay trace data from multiple computers.

## Why Replay Traces?

SQL Server Profiler features a multithreaded playback engine that can simulate user connections and SQL Server Authentication. 

 - Replay is useful to troubleshoot an application or process problem. 
 - When you identified the problem and implemented corrections, run the trace that found the potential problem against the corrected application or process. 
 - Then, replay the original trace and compare results.

## Replay Requirements

To replay trace data with SQL Server Profiler or the Distributed Replay Utility, a specific set of event classes and columns must be captured in the trace. 

 - These settings are enabled by default if the `TSQL_Replay` trace template is used to configure a trace that is later used for replay.
 - It checks for the presence of required events and columns. 
 - This change helps improve the accuracy of replay and takes the guesswork out of troubleshooting replay when required data is missing. 
 - Replay returns an error and stops replaying a file when required data is missing from a trace.

## Considerations for Replaying Traces

SQL Server Profiler cannot replay the following kinds of traces:

 - Traces that contain transactional replication and other transaction log activity. These events are skipped. Other types of replication do not mark the transaction log, so they are not affected.
 - Traces that contain operations that involve globally unique identifiers (GUID). These events will be skipped.
 - Traces that contain operations on **text**, **ntext**, and **image** columns involving the **bcp** utility, the `BULK INSERT`, `READTEXT`, `WRITETEXT`, and `UPDATETEXT` statements, and full-text operations. These events are skipped.
 - Traces that contain session binding: `sp_getbindtoken` and `sp_bindsession` system stored procedures. These events are skipped.

## Event Classes Required for Replay

To be replayed by SQL Server Profiler, the following set of event classes, in addition to any other event classes you want to monitor, must be captured in the trace:

 - **CursorClose** (only required when replaying server-side cursors)
 - **CursorExecute** (only required when replaying server-side cursors)
 - **CursorOpen** (only required when replaying server-side cursors)
 - **CursorPrepare** (only required when replaying server-side cursors)
 - **CursorUnprepare** (only required when replaying server-side cursors)
 - **Audit Login**
 - **Audit Logout**
 - **ExistingConnection**
 - **RPC Output Parameter**
 - **RPC:Completed**
 - **RPC:Starting**
 - **Exec Prepared SQL** (only required when replaying server-side prepared SQL statements)
 - **Prepare SQL** (only required when replaying server-side prepared SQL statements)
 - **SQL:BatchCompleted**
 - **SQL:BatchStarting**

## Data Columns Required for Replay

In addition to any other data columns you want to capture, the following data columns must be captured in a trace to allow the trace to be replayed:

 - **Event Class**
 - **EventSequence**
 - **TextData**
 - **Application Name**
 - **LoginName**
 - **DatabaseName**
 - **Database ID**
 - **ClientProcessID**
 - **HostName**
 - **ServerName**
 - **Binary Data**
 - **SPID**
 - **Start Time**
 - **EndTime**
 - **IsSystem**
 - **NTDomainName**
 - **NTUserName**
 - **Error**
