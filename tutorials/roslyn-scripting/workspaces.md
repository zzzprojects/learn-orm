---
PermaID: 100014
Name: Workspaces
---

# Workspaces

The Workspaces layer allows you to perform code analysis and refactoring over entire solutions. 

 - The Workspace API assists you to get all the information about the projects in a solution into a single object model.
 - A Workspace is the root node of a hierarchy that consists of a solution, child projects, and child documents.

The `MSBuildWorkspace` is used to handle MSBuild solution (.sln) and project (.csproj, .vbproj) files. Currently, you cannot add projects or create new solutions, you can iterate over all the documents in a solution as shown below.

```csharp
static void MSBuildWorkspaceExample()
{
    string solutionPath = @"C:\Users\...\SolutionName.sln";
    var msWorkspace = MSBuildWorkspace.Create();

    var solution = msWorkspace.OpenSolutionAsync(solutionPath).Result;
    foreach (var project in solution.Projects)
    {
        Console.WriteLine(project.Name);

        foreach (var document in project.Documents)
        {
            Console.WriteLine("\t" + document.Name);
        }
    }
}
```

The `AdhocWorkspace` allows you to add solution and project files manually. You can use this workspace if you just need a quick and easy way to create a workspace and add projects and documents to it.

```csharp
static void AdhocWorkspaceExample()
{
    var workspace = new AdhocWorkspace();

    string projectName = "HelloWorldProject";
    ProjectId projectId = ProjectId.CreateNewId();
    VersionStamp versionStamp = VersionStamp.Create();
    ProjectInfo helloWorldProject = ProjectInfo.Create(projectId, versionStamp, projectName, projectName, LanguageNames.CSharp);
    SourceText sourceText = SourceText.From("class Program { static void Main() { System.Console.WriteLine(\"HelloWorld\"); } }");

    Project newProject = workspace.AddProject(helloWorldProject);
    Document newDocument = workspace.AddDocument(newProject.Id, "Program.cs", sourceText);

    foreach (var project in workspace.CurrentSolution.Projects)
    {
        Console.WriteLine(project.Name);

        foreach (var document in project.Documents)
        {
            Console.WriteLine("\t" + document.Name);
        }
    }
}
```
