---
PermaID: 100017
Name: Cryptographic Key Import/Export
---

# Cryptographic Key Import/Export

.NET Core 3.0 supports the import and export of asymmetric public and private keys from standard formats. You don't need to use an X.509 certificate.

All key types, such as `RSA`, `DSA`, `ECDsa`, and `ECDiffieHellman`, support the following formats:

 - **Public Key**
   - X.509 SubjectPublicKeyInfo

 - **Private key**
   - PKCS#8 PrivateKeyInfo
   - PKCS#8 EncryptedPrivateKeyInfo

RSA keys also support:

 - **Public Key**
   - PKCS#1 RSAPublicKey

 - **Private key**
   - PKCS#1 RSAPrivateKey

The export methods produce DER-encoded binary data, and the import methods expect the same. If a key is stored in the text-friendly PEM format, the caller will need to base64-decode the content before calling an import method.

```csharp
using System;
using System.Security.Cryptography;

namespace whats_new
{
    public static class RSATest
    {
        public static void Run(string keyFile)
        {
            using var rsa = RSA.Create();

            byte[] keyBytes = System.IO.File.ReadAllBytes(keyFile);
            rsa.ImportRSAPrivateKey(keyBytes, out int bytesRead);

            Console.WriteLine($"Read {bytesRead} bytes, {keyBytes.Length - bytesRead} extra byte(s) in file.");
            RSAParameters rsaParameters = rsa.ExportParameters(true);
            Console.WriteLine(BitConverter.ToString(rsaParameters.D));
        }
    }
}
```

 - **PKCS#8** files can be inspected with [System.Security.Cryptography.Pkcs.Pkcs8PrivateKeyInfo](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.pkcs.pkcs8privatekeyinfo?view=dotnet-plat-ext-5.0). 
 - **PFX/PKCS#12** files can be inspected with [System.Security.Cryptography.Pkcs.Pkcs12Info](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.pkcs.pkcs12info?view=dotnet-plat-ext-5.0). 
 - **PFX/PKCS#12** files can be manipulated with [System.Security.Cryptography.Pkcs.Pkcs12Builder](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.pkcs.pkcs12builder?view=dotnet-plat-ext-5.0).