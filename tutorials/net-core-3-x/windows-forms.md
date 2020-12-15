---
PermaID: 100024
Name: Windows Forms
---

# Windows Forms

Windows Forms support was added to .NET Core in version 3.0. This article lists breaking changes for Windows Forms by the .NET version in which they were introduced. If you're upgrading a Windows Forms app from .NET Framework or a previous version of .NET Core (3.0 or later), this article applies to you.

The following breaking changes are documented on this page:

## Removed controls

Starting in .NET Core 3.1, some Windows Forms controls are no longer available.

### Change Description

Starting with .NET Core 3.1, various Windows Forms controls are no longer available. Replacement controls that have better design and support were introduced in .NET Framework 2.0. The deprecated controls were previously removed from designer toolboxes but were still available to be used.

Legacy controls were included in Windows Forms that have been unavailable in the Visual Studio Designer Toolbox for some time. These were replaced with new controls back in .NET Framework 2.0. These have been removed from the Desktop SDK for .NET Core 3.1.

|Removed control        | Recommended replacement               | Associated APIs removed      |
|:----------------------|:--------------------------------------|:-----------------------------|
| DataGrid              | DataGridView                          | DataGridCell <br> DataGridRow <br> DataGridTableCollection <br> DataGridColumnCollection <br> DataGridTableStyle <br> DataGridColumnStyle <br> DataGridLineStyle <br> DataGridParentRowsLabel <br> DataGridParentRowsLabelStyle <br> DataGridBoolColumn <br> DataGridTextBox <br> GridColumnStylesCollection <br> GridTableStylesCollection <br> HitTestType                 |
|ToolBar                | ToolStrip                             | ToolBarAppearance           |
|ToolBarButton          | ToolStripButton                       | ToolBarButtonClickEventArgs <br> ToolBarButtonClickEventHandler <br> ToolBarButtonStyle <br> ToolBarTextAlign            |
|ContextMenu            | ContextMenuStrip                      |                               |	
|Menu                   | ToolStripDropDown <br> ToolStripDropDownMenu   | MenuItemCollection   |
|MainMenu               | MenuStrip	                            | |
|MenuItem               | ToolStripMenuItem | |

We recommend you update your applications to .NET Core 3.1 and move to the replacement controls. Replacing the controls is a straightforward process, essentially "find and replace" on the type.
