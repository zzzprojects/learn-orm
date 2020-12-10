---
PermaID: 100014
Name: Linux Improvements
---

# Linux Improvements

## SerialPort for Linux

.NET Core 3.0 provides basic support for `System.IO.Ports.SerialPort` on Linux. Previously, .NET Core only supported using `SerialPort` on Windows.

 - The `SerialPort` class control a serial port file resource. 
 - It provides synchronous and event-driven I/O, access to pin and break states, and access to serial driver properties. 
 - The functionality of this class can be wrapped in an internal `Stream` object, accessible through the `BaseStream` property, and passed to classes that wrap or use streams.

## Docker and cgroup memory Limits

Running .NET Core 3.0 on Linux with Docker works better with cgroup memory limits. Running a Docker container with memory limits, such as with `docker run -m`, changes how .NET Core behaves.

 - Default Garbage Collector (GC) heap size: maximum of **20MB** or **75%** of the memory limit on the container.
 - Explicit size can be set as an absolute number or percentage of cgroup limit.
 - Minimum reserved segment size per GC heap is **16MB**. This size reduces the number of heaps that are created on machines.

## GPIO Support for Raspberry Pi

Two packages have been released to NuGet that you can use for GPIO programming:

 - [System.Device.Gpio](https://www.nuget.org/packages/System.Device.Gpio)
 - [Iot.Device.Bindings](https://www.nuget.org/packages/Iot.Device.Bindings)

The GPIO packages include APIs for GPIO, SPI, I2C, and PWM devices. The IoT bindings package includes device bindings. For more information, see the [devices GitHub repo](https://github.com/dotnet/iot/blob/master/src/devices/).

## ARM64 Linux support

.NET Core 3.0 adds support for ARM64 for Linux. The primary use case for ARM64 is currently with IoT scenarios. For more information, see .NET Core ARM64 Status.

Docker images for .NET Core on ARM64 are available for Alpine, Debian, and Ubuntu.
