---
PermaID: 100003
Name: Platform Improvements
---

# Platform Improvements

.NET Core 2.0 includes several features that make it easier to install .NET Core and to use it on supported operating systems.

## .NET Core for Linux is a Single Implementation

 - .NET Core 2.0 offers a single Linux implementation that works on multiple Linux distributions. 
 - .NET Core 1.x required that you download a distribution-specific Linux implementation.
 - You can also develop apps that target Linux as a single operating system. 
 - .NET Core 1.x required that you target each Linux distribution separately.

## Support for the Apple Cryptographic Libraries

.NET Core 1.x on macOS required the OpenSSL toolkit's cryptographic library. .NET Core 2.0 uses the Apple cryptographic libraries and doesn't require OpenSSL, so you no longer need to install it.

