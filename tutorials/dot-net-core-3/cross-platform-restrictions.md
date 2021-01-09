---
PermaID: 100007
Name: Cross Platform/Architecture Restrictions
---

# Cross Platform/Architecture Restrictions

Currently, the `ReadyToRun` compiler doesn't support cross-targeting. You must compile on a given target. For example, if you want R2R images for Windows x64, you need to run the publish command on that environment.

Exceptions to cross-targeting:

 - Windows x64 can be used to compile Windows ARM32, ARM64, and x86 images.
 - Windows x86 can be used to compile Windows ARM32 images.
 - Linux x64 can be used to compile Linux ARM32 and ARM64 images.

For some SDK platforms, the ReadyToRun compiler is capable of cross-compiling for other target platforms. Supported compilation targets are described in the below table.

| SDK platform                   | Supported target platforms                                 |
|:-------------------------------|:-----------------------------------------------------------|
| Windows X64                    | Windows X86, Windows X64, Windows ARM32, Windows ARM64     |
| Windows X86                    | Windows X86, Windows ARM32                                 |
| Linux X64                      | Linux X86, Linux X64, Linux ARM32, Linux ARM64             |
| Linux ARM32                    | Linux ARM32                                                |
| Linux ARM64                    | Linux ARM64                                                | 
| macOS X64                      | macOS X64                                                  |