---
PermaID: 100018
Name: EFCore.BulkExtensions vs EF Extensions
---

# EFCore.BulkExtensions vs EF Extensions in EF Core 7

I recently found myself having to use bulk operations in EF Core 7. A quick search on Google always leads to 2 popular solutions :

- [EFCore.BulkExtensions](https://www.codis.tech/efcorebulk/) from CODIS (Starting at $500)
- [Z.EntityFramework.Extensions](https://entityframework-extensions.net/) from ZZZ Projects (Starting at $999)

For an enterprise, **in both cases, the solution is not free**, and a license needs to be purchased.

So the first step I had to do was to compare both libraries.

## Features Comparisons

In this section, I will just compare some basic features to get a good overview of both libraries.

| Features | [EFCore.BulkExtensions](https://www.codis.tech/efcorebulk/) | [Z.EntityFramework.Extensions](https://entityframework-extensions.net/) | 
|:---|:---:|:---:|
|  BulkSaveChanges | Yes (many bugs) | Yes | 
|  BulkInsert + Identity | Yes | Yes |  
|  BulkInsert + Identity Retured | Yes (slow) | Yes |  
|  BulkInsert + Guid Application Generated | Yes | Yes |  
|  BulkInsert + Guid Database Generated | No | Yes |  
|  BulkInsert + TPC | No | Yes |  
|  BulkInsert + TPH | Yes (slow) | Yes |  
|  BulkInsert + TPT | No | Yes |  
|  BulkInsert + Owned One | Partially | Yes | 
|  BulkInsert + Owned Many | No | Yes |

### EFCore.BulkExtensions Features

The library works really great for basic scenarios, but as soon as I start to play with inheritance such as `TPC`, `TPH`, `TPT`, the library no longer supports it. I was quite surprised that even some basic scenarios, such as saving an entity with `guid` generated in the database was not working.

Another big surprise I found out was when inserting in bulk and returning the identity. For hundreds of entities, the performance was very close to the `Z.EntityFramework.Extensions`. However, as I was inserting more entities, the gap was getting bigger and bigger.

| BulkInsert + Identity Retured | [EFCore.BulkExtensions](https://www.codis.tech/efcorebulk/) | [Z.EntityFramework.Extensions](https://entityframework-extensions.net/) | 
|:---|:---:|:---:|
|  1,000 Entities + Identity | 350 ms | 125 ms | 
|  100,000 Entities + Identity | 9200 ms | 833 ms | 

Obviously, that's a big problem within the library as the primary purpose is to insert fast.

### Z.EntityFramework.Extensions Features

 The library was compatible with all tests I performed, so I don't have any negative points.

### Winner

For features, [Z.EntityFramework.Extensions](https://entityframework-extensions.net/) is the clear winner. So far, it has supported all scenarios we tried, and we have never run into a problem.

## Developer Experience Comparisons

In this section, I will compare the developer experience that you can expect to get with both companies

| Category | [EFCore.BulkExtensions](https://www.codis.tech/efcorebulk/) | [Z.EntityFramework.Extensions](https://entityframework-extensions.net/) | 
|:---|:---|:---|
|  Pricing | Starting at $500 | Starting at $999 | 
|  Customer Support | 2/5 | 4.5/5 |
|  Product Support | 2/5 | 5/5 | 
|  Documentation | 2/5 | 3.5/5 | 

## Pricing

You can see their price here:

- [EFCore.BulkExtensions (Starting at $500)](https://www.codis.tech/efcorebulk/)
- [Z.EntityFramework.Extensions (Starting at $999)](https://entityframework-extensions.net/pricing)

### Customer Support

For **EFCore.BulkExtensions**, Looking at their [GitHub](https://github.com/borisdj/EFCore.BulkExtensions/issues), most issues are not assigned and not answered. That sure looks like a **red flag** if I need to pay for a license.

For **EF Extensions**, looking at their [GitHub](https://github.com/zzzprojects/EntityFramework-Extensions/issues), most issues are assigned and answered.

In addition, we contacted both companies by email:

- **EFCore.BulkExtensions:** They told us to look at their GitHub and that we should find the answer
- **EF Extensions:** They provided an answer with an online example on [.NET Fiddle](https://dotnetfiddle.net/). We also got asked if we needed more help 2 days later.

### Product Support

Both products support EF Core 7, which is excellent!

For **EFCore.BulkExtensions**, after a major version is released, they look to stop to support the previous version. For example, they stop to support EF Core 5 a few months after EF Core 6 was released. They already look to have dropped the support to EF Core 6 now that EF Core 7 is available. That's a **big red flag** as the project we created in 2022 still uses EF Core 6, which means that bug fixes reported will not get fixed unless we move to EF Core 7.

For **EF Extensions**, they support all EF Core versions.

### Documentation

For **EFCore.BulkExtensions**, the only documentation found is their GitHub readme.

For **EF Extensions**, they have a [documentation](https://entityframework-extensions.net/bulk-insert) section on their website. They also have thousands of [online examples](https://entityframework-extensions.net/online-examples). Their documentation is not the best, but online examples certainly help.

### Winner

For developer experience, [Z.EntityFramework.Extensions](https://entityframework-extensions.net/) is also the winner. Indeed you pay to double the price, but it also comes with better documentation, customer support, and your legacy project is still supported.

## Conclusion

For personal usage and if you only need to use basic features **EFCore.BulkExtensions** can be a good choice. However, it is hard to justify paying $500 for a license that everything seems to be lacking. Honestly, on my personal project, I preferred using **Z.EntityFramework.Extensions** for free by upgrading once a month; That is annoying, but at least I don't have to understand why something doesn't work.

For commercial usage, **Z.EntityFramework.Extensions** is the obvious winner. It costs twice as much, but it supports all features I need, and I surely feel more secure If I need help with a problem or to get support if some of my company projects still use EF Core 6 in a few years.
