---
PermaID: 100009
Name: Replay to a Breakpoint
---

# Replay to a Breakpoint

Setting breakpoints in a trace file or table before you start to replay the trace, enables you to pause the replay of the trace at specific events. Using breakpoints while replaying a trace supports debugging because you can break the replay of long trace scripts into short segments that can be analyzed incrementally.

Let's open the **SQL Server Profiler** and go to the **File > Open > Trace Table...** menu.

<img src="images/replay-a-single-event-at-a-time-1.png" alt="File > Open > Trace Table...">

It will open the **Connect to Server** dialog.

<img src="images/replay-a-trace-table-2.png" alt="Connect to Server dialog">

Click on the **Connect** button to connect to an instance of SQL Server.

<img src="images/replay-a-single-event-at-a-time-2.png" alt="Destination Table">

You will see a **Destination Table** dialog. Select the destination table and click the **OK** button.

Make sure that the trace table you open contains the event classes necessary for replay.

<img src="images/replay-a-single-event-at-a-time-3.png" alt="SQL Server Profiler">

In the trace window, click an event that you want to use as a breakpoint by using one of the following three methods to set a breakpoint.

 - Press F9
 - On the **Replay** menu, click **Toggle Breakpoint**
 - Right-click the event, and then click **Toggle Break-Point**

<img src="images/replay-to-a-breakpoint-1.png" alt="Toggle Breakpoint">

A red bullet appears next to the selected trace event, indicating that it is the trace breakpoint.

<img src="images/replay-to-a-breakpoint-2.png" alt="Added Breakpoint">

You can repeat this step to set several breakpoints. On the **Replay** menu, click **Start**, and connect to the server where you want to replay the trace.

<img src="images/replay-to-a-breakpoint-3.png" alt="Replay > Start">

Connect to an instance of SQL Server and then in the **Replay Configuration** dialog, specify **Replay server**.

<img src="images/replay-a-trace-table-12.png" alt="Basic Replay Options">

You can select one of the following destinations in which to save the replay:

 - **Save to file**, which specifies a file in which to save the replay.
 - **Save to table**, which specifies a database table in which to save the replay.

Select **Save to file** and option and specify the file, verify the settings, and then click **OK** button. 

<img src="images/replay-to-a-breakpoint-4.png" alt="Trace Window">

The replay starts, pausing when the breakpoint is reached. Press **F5** to resume the replay and proceed to the next breakpoint or end of the trace if there is no other breakpoint available.
