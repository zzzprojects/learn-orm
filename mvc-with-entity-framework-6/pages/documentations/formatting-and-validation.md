---
PermaID: 100012
Name: Formatting & Validation
---

# Formatting & Validation

In this article, we will discuss how to customize the data model by using attributes that specify formatting, validation, and database mapping rules.

## DataType

In `Author` entity, we have `BirthDate` property, and all of the web pages currently display the time along with the date. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/mvc-with-entity-framework-6/images/formatting-and-validation-1.png">

But in this field, we only need the date, so by using data annotation attributes, we can make one code change that will fix the display format in every view that shows the birth date.

In ***Models\Author.cs***, add a `using` statement for the `System.ComponentModel.DataAnnotations` namespace and add `DataType` and `DisplayFormat` attributes to the `BirthDate` property, as shown below.

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWithEF6Demo.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
```

The `DataType` attribute is used to specify a data type that is more specific than the database intrinsic type. 

 - In this case, we only want to keep track of the date, not the date and time.
 - `DataType.Date` does not specify the format of the date that is displayed. 
 - By default, the data field is displayed according to the default formats based on the server's `CultureInfo`. 
 - The DisplayFormat attribute is used to explicitly specify the date format.

Let's run your application and go to the author `Index` page again and you will see that times are no longer displayed for the birth dates. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/mvc-with-entity-framework-6/images/formatting-and-validation-2.png">

The same will be true for any view that uses the `Author` model.

## StringLength

You can also specify data validation rules and validation error messages using attributes. 

 - The `StringLength` attribute sets the maximum length in the database and provides client side and server side validation for ASP.NET MVC. 
 - For example, you want to ensure that users don't enter more than 20 characters for a name. 
 
To add this limitation, add `StringLength` attributes to the `LastName` and `FirstName` properties as shown below.

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWithEF6Demo.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        
        public virtual ICollection<Book> Books { get; set; }
    }
}
```

We can also specify the `ErrorMessage` which will be shown on the webpage when the user enters more than 20 characters in the name field.

```csharp
[StringLength(20, ErrorMessage = "Name cannot be longer than 20 characters.")]
```

The database model has changed in a way that requires a change in the database schema. In the `Package Manager Console`, enter the following commands.

```csharp
add-migration MaxLengthOnNames
update-database
```

The `add-migration` command creates a file named `<timeStamp>_MaxLengthOnNames.cs`. 

```csharp
namespace MvcWithEF6Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxLengthOnNames : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Authors", "LastName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "LastName", c => c.String());
            AlterColumn("dbo.Authors", "FirstName", c => c.String());
        }
    }
}
```

It contains the code in the `Up` method that will update the database to match the current data model. The `update-database` command ran that code.