---
PermaID: 100015
Name: New Cryptography APIs and Cryptography Improvements
---

# New Cryptography APIs and Cryptography Improvements

In .NET Core 2.1, the following enhancements are added to the cryptography APIs.

## SignedCms

The `SignedCms` class enables the signing and verifying of CMS/PKCS #7 messages.

 - It is available in the `System.Security.Cryptography.Pkcs` package. 
 - The implementation is the same as the `SignedCms` class in the .NET Framework.

The Cryptographic Message Syntax RFC specifies the following MIME types and file name extensions for CMS/PKCS #7 messages with these content types.

| Content type            | MIME type                                | Extension  |
|:------------------------|:-----------------------------------------|:-----------|
| envelopedData           | application/pkcs7-mime                   | .p7m       |
| signedData              | application/pkcs7-signature              | .p7s.p7c   |

## Overloads

New overloads of the following methods accept a hash algorithm identifier to enable callers to get certificate thumbprint values using algorithms other than SHA-1.

 - **`X509Certificate.GetCertHash`**: Returns the hash value for the X.509v3 certificate computed by using the specified cryptographic hash algorithm.
 - **`X509Certificate.GetCertHashString`**: Returns a hexadecimal string containing the hash value for the X.509v3 certificate computed using the specified cryptographic hash algorithm.

## Span\<T\>

New `Span<T>` based cryptography APIs are available for hashing, HMAC, cryptographic random number generation, asymmetric signature generation, asymmetric signature processing, and RSA encryption.

## Rfc2898DeriveBytes

The performance of `System.Security.Cryptography.Rfc2898DeriveBytes` has improved by about 15% by using a `Span<T>` based implementation.

## CryptographicOperations

The new `System.Security.Cryptography.CryptographicOperations` class includes two new methods.

 - `FixedTimeEquals` takes a fixed amount of time to return for any two inputs of the same length, which making suitable for use in cryptographic verification to avoid contributing to timing side-channel information.
 - `ZeroMemory` is a memory-clearing routine that cannot be optimized.

## RandomNumberGenerator.Fill

The static `RandomNumberGenerator.Fill` method fills a `Span<T>` with random values.

## EnvelopedCms

The `System.Security.Cryptography.Pkcs.EnvelopedCms` is now supported on Linux and macOS.

## ECDiffieHellman

Elliptic-Curve Diffie-Hellman (ECDH) is now available in the `System.Security.Cryptography.ECDiffieHellman` class family. 

 - The surface area is the same as in the .NET Framework.
 - This class provides the basic set of operations that all ECDH implementations must support.

## RSA.Create

The instance returned by `RSA.Create` can encrypt or decrypt with OAEP using a SHA-2 digest, as well as generate or validate signatures using RSA-PSS.

