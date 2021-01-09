---
PermaID: 100010
Name: New global.json Options
---

# New global.json Options

## global.json

The `global.json` file allows you to define which .NET SDK version is used when you run .NET CLI commands. 

 - Selecting the .NET SDK is independent of specifying the runtime of your project targets. 
 - The .NET SDK version indicates which versions of the .NET CLI is used.

In general, you want to use the latest version of the SDK tools, so no `global.json` file is needed. In some advanced scenarios, you might want to control the version of the SDK tools.

In .NET Core 3.0, the new options are added to the global.json file that provides more flexibility when defining which version of the .NET Core SDK is used. 

The following are the new options.

 - **allowPrerelease:** Indicates whether the SDK resolver should consider prerelease versions when selecting the SDK version to use.
 - **rollForward:** Indicates the roll-forward policy to use when selecting an SDK version, either as a fallback when a specific SDK version is missing or as a directive to use a higher version.

The following example shows how to not use prerelease versions.

```csharp
{
  "sdk": {
    "allowPrerelease": false
  }
}
```

The following example shows how to use the highest version installed that is greater or equal to the specified version. The JSON shown disallows any SDK version earlier than 2.2.200 and allows 2.2.200 or any later version, including 3.0.xxx and 3.1.xxx.

```csharp
{
  "sdk": {
    "version": "2.2.200",
    "rollForward": "latestMajor"
  }
}
```

The following example shows how to use the exact specified version:

```
{
  "sdk": {
    "version": "3.1.100",
    "rollForward": "disable"
  }
}
```
