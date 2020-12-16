---
PermaID: 100000
Name: Dotnet Restore Runs Implicitly
---

# Dotnet Restore Runs Implicitly

The `dotnet restore` command uses NuGet to restore dependencies as well as project-specific tools that are specified in the project file. In most cases, you don't need to explicitly use the `dotnet restore` command, since a NuGet restore is run implicitly if necessary when you run the following commands:

 - dotnet new
 - dotnet build
 - dotnet build-server
 - dotnet run
 - dotnet test
 - dotnet publish
 - dotnet pack

In previous versions of .NET Core, you had to run the `dotnet restore` command to download dependencies immediately after you created a new project with the `dotnet new` command, as well as whenever you added a new dependency to your project.

In .NET Core 2.0, you don't have to run `dotnet restore` because it's run implicitly by all commands that require a restore to occur, such as `dotnet new`, `dotnet build`, `dotnet run`, `dotnet test`, `dotnet publish`, and `dotnet pack`. 

To disable implicit restore, use the `--no-restore` option as shown below.

```csharp
dotnet build --no-restore
```

Building requires the `project.assets.json` file, which lists the dependencies of your application. The file is created when dotnet restore is executed. Without the assets file in place, the tooling can't resolve reference assemblies, which results in errors.

## Explicit Restore

 - Sometimes, it might be inconvenient to run the implicit NuGet restore with these commands. 
 - The `dotnet restore` command is still useful in certain scenarios where explicitly restoring makes sense, such as continuous integration builds in Azure DevOps Services or in build systems that need to explicitly control when the restore occurs.