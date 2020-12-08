---
PermaID: 100008
Name: Major-version Runtime Roll Forward
---

# Major-version Runtime Roll Forward

In .NET Core 3.0, an opt-in feature is added that allows your application to roll forward to the latest major version of .NET Core. Additionally, a new setting has been added to control how to roll forward is applied to your application. 

You can configure it in the following ways.

 - **Project file property:** `RollForward`
 - **Run-time configuration file property:** `rollForward`
 - **Environment variable:** `DOTNET_ROLL_FORWARD`
 - **Command-line argument:** `--roll-forward`

You must specify one of the following values. If the setting is omitted, `Minor` is the default.

#### LatestPatch

 - Roll forward to the highest patch version. This disables minor version roll forward.

#### Minor

 - Roll forward to the lowest higher minor version, if the requested minor version is missing. 
 - If the requested minor version is present, then the `LatestPatch` policy is used.

#### Major

 - Roll forward to the lowest higher major version, and lowest minor version, if the requested major version is missing. 
 - If the requested major version is present, then the `Minor` policy is used.

#### LatestMinor

 - Roll forward to the highest minor version, even if the requested minor version is present. 
 - It is intended for component hosting scenarios.

#### LatestMajor

 - Roll forward to highest major and highest minor version, even if requested major is present. 
 - It is intended for component hosting scenarios.

#### Disable

 - It does not roll forward and only binds to a specified version. 
 - This policy is not recommended for general use because it disables the ability to roll forward to the latest patches. 
 - This value is only recommended for testing.

Besides the `Disable` setting, all settings will use the highest available patch version.

By default, if the requested version is a release version specified in `.runtimeconfig.json` for the application, only release versions are considered for roll forward. Any pre-release versions are ignored. If there is no matching release version, then pre-release versions are taken into account. This behavior can be changed by setting `DOTNET_ROLL_FORWARD_TO_PRERELEASE=1`, in which case all versions are always considered.
