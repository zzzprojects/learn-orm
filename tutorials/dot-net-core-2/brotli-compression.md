---
PermaID: 100014
Name: Brotli Compression
---

# Brotli Compression

## What is Brotli?

Brotli is a generic-purpose lossless compression algorithm that compresses data using a combination of a modern variant of the LZ77 algorithm, Huffman coding, and 2nd order context modeling, with a compression ratio comparable to the best currently available general-purpose compression methods. 

 - It is similar in speed with deflate but offers more dense compression.
 - The specification of the Brotli Compressed Data Format is defined in [RFC 7932](https://tools.ietf.org/html/rfc7932).
 - It is supported by most web browsers and major web servers.
 - Brotli is open-sourced under the MIT License.

.NET Core 2.1 adds support for Brotli compression and decompression. You can use the stream-based `System.IO.Compression.BrotliStream` class or the high-performance span-based `System.IO.Compression.BrotliEncoder` and `System.IO.Compression.BrotliDecoder` classes.

The following example shows the compression with the `BrotliStream` class.

```csharp
public Byte[] Compress(Byte[] input)
{
    Byte[] output = null;
    using (System.IO.MemoryStream msInput = new System.IO.MemoryStream(input))
    using (System.IO.MemoryStream msOutput = new System.IO.MemoryStream())
    using (BrotliStream bs = new BrotliStream(msOutput, System.IO.Compression.CompressionMode.Compress))
    {
        msInput.CopyTo(bs);
        bs.Close();
        output = msOutput.ToArray();
        return output;
    }
}
```

The following example shows the decompression with the `BrotliStream` class.

```csharp
public Byte[] Decompress(Byte[] input)
{
    Byte[] output = null;
    using (System.IO.MemoryStream msInput = new System.IO.MemoryStream(input))
    using (BrotliStream bs = new BrotliStream(msInput, System.IO.Compression.CompressionMode.Decompress))
    using (System.IO.MemoryStream msOutput = new System.IO.MemoryStream())
    {
        bs.CopyTo(msOutput);
        msOutput.Seek(0, System.IO.SeekOrigin.Begin);
        output = msOutput.ToArray();
        return output;
    }
}
```