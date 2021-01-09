---
PermaID: 100016
Name: Cryptography Ciphers
---

# Cryptography Ciphers

.NET Core 3.0 adds support for AES-GCM and AES-CCM ciphers, implemented with [System.Security.Cryptography.AesGcm](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.aesgcm) and [System.Security.Cryptography.AesCcm](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.aesccm) respectively. 

 - **AesGcm:** Represents an Advanced Encryption Standard (AES) key to be used with the Galois/Counter Mode (GCM) mode of operation.
 - **AesCcm:** Represents an Advanced Encryption Standard (AES) key to be used with the Counter with CBC-MAC (CCM) mode of operation.

These algorithms are both Authenticated Encryption with Association Data (AEAD) algorithms.

The following code demonstrates using AesGcm cipher to encrypt and decrypt random data.

```csharp
using System;
using System.Linq;
using System.Security.Cryptography;

namespace whats_new
{
    public static class Cipher
    {
        public static void Run()
        {
            // key should be: pre-known, derived, or transported via another channel, such as RSA encryption
            byte[] key = new byte[16];
            RandomNumberGenerator.Fill(key);

            byte[] nonce = new byte[12];
            RandomNumberGenerator.Fill(nonce);

            // normally this would be your data
            byte[] dataToEncrypt = new byte[1234];
            byte[] associatedData = new byte[333];
            RandomNumberGenerator.Fill(dataToEncrypt);
            RandomNumberGenerator.Fill(associatedData);

            // these will be filled during the encryption
            byte[] tag = new byte[16];
            byte[] ciphertext = new byte[dataToEncrypt.Length];

            using (AesGcm aesGcm = new AesGcm(key))
            {
                aesGcm.Encrypt(nonce, dataToEncrypt, ciphertext, tag, associatedData);
            }

            // tag, nonce, ciphertext, associatedData should be sent to the other part

            byte[] decryptedData = new byte[ciphertext.Length];

            using (AesGcm aesGcm = new AesGcm(key))
            {
                aesGcm.Decrypt(nonce, ciphertext, tag, decryptedData, associatedData);
            }

            // do something with the data
            // this should always print that data is the same
            Console.WriteLine($"AES-GCM: Decrypted data is {(dataToEncrypt.SequenceEqual(decryptedData) ? "the same as" : "different than")} original data.");
        }
    }
}
```
