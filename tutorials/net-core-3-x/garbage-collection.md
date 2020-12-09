---
PermaID: 100011
Name: Garbage Collection
---

# Garbage Collection

The garbage collection (GC) allocates heap segments where each segment is a contiguous range of memory. 

 - Objects placed in the heap are categorized into one of 3 generations such as 0, 1, or 2. 
 - The generation determines the frequency the GC attempts to release memory on managed objects that are no longer referenced by the application. 
 - Lower numbered generations are GC'd more frequently.

## Transition Between Generations

Objects are moved from one generation to another based on their lifetime. 

 - As objects live longer, they are moved into a higher generation. 
 - As mentioned previously, higher generations are GC'd less often. 
 - Short term lived objects always remain in generation 0. 
 - For example, objects that are referenced during the life of a web request are short-lived. 
 - Application-level singletons generally migrate to generation 2.

When an ASP.NET Core app starts, the GC:

 - Reserves some memory for the initial heap segments.
 - Commits a small portion of memory when the runtime is loaded.

The preceding memory allocations are done for performance reasons. The performance benefit comes from heap segments in contiguous memory.

## Smaller Heap Sizes

 - The Garbage Collector's default heap size has been reduced resulting in .NET Core using less memory. 
 - This change better aligns with the generation 0 allocation budget with modern processor cache sizes.

## Large Page Support

 - Large Pages which is also known as Huge Pages on Linux is a feature where the operating system can establish memory regions larger than the native page size (often 4K) to improve the performance of the application requesting these large pages.
 - The Garbage Collector can now be configured with the **GCLargePages** setting as an opt-in feature to choose to allocate large pages on Windows.
