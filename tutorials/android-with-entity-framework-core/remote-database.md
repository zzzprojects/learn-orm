---
PermaID: 100006
Name: Remote Database
---

# Remote Database

Those who are new to Xamarin, and coming from a web background will have a question that how we can connect to a remote database from my mobile app? The client application is different than a server-based application, as you don’t have direct access to any server-based resources, such as a database. 

In this case, you need a way to accept requests from a client and pass them on to a database. 

 - The most common way to achieve this is via a REST-based API. 
 - An API is like a webpage, but instead of a user viewing it and seeing HTML, a mobile application or another client connects to it, sends it commands and receives data back from it, most commonly JSON formatted data.

## What is REST Web Service (API)?

Representational State Transfer (REST) is an architectural style for building web services. REST requests are made over HTTP using the same HTTP verbs that web browsers use to retrieve web pages and to send data to servers.

Web service APIs that adhere to REST is called RESTful APIs, and are defined using:

 - A base URI.
 - HTTP methods, such as GET, POST, PUT, PATCH, or DELETE.
 - A media type for the data, such as JavaScript Object Notation (JSON).

RESTful web services typically use JSON messages to return data to the client. JSON is a text-based data-interchange format that produces compact payloads, which results in reduced bandwidth requirements when sending data. The sample application uses the open-source [NewtonSoft JSON.NET library](https://www.newtonsoft.com/json) to serialize and deserialize messages.

## Create Web Service

To create a web service, let’s open a Visual Studio and create a new web application.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/android-with-entity-framework-core/images/remote-database-1.png">

On Add a new project page, select ASP.NET Core Web Application template click Next button. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/android-with-entity-framework-core/images/remote-database-2.png">

Enter the project name and choose a location for your project to Configure your new project page and click the Create button. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/android-with-entity-framework-core/images/remote-database-3.png">

In the Create a new ASP.NET Core Web Application dialog, confirm that .NET Core and ASP.NET Core 3.1 is selected. Select the API template and click Create.

### Install EF Core

To install EF Core, right-click on the project in Solution Explorer, and select Manage NuGet Packages…, and install the following packages.

 - Microsoft.EntityFrameworkCore
 - Microsoft.EntityFrameworkCore.SqlServer

We are ready to start writing some Entity Framework code.

### Add Model

A model is a set of classes that represent the data that the app manages. The model here is simple which contains Customer and PhoneContact classes.

In Solution Explorer, right-click the project. Select Add > New Folder and name it Models. Right-click the Models folder and select Add > Class, name the class PhoneContact and select Add. Replace the template code with the following code.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFWebServices.Models
{
    public class PhoneContact
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PhoneContactID { get; set; }
        public string PhoneNumber { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}
```

Similarly, add another class Customer and replace the template code with the following code.

```csharp
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace EFWebServices.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Boolean IsActive { get; set; }
        public List<PhoneContact> PhoneContacts { get; set; }
        public Customer()
        {
            PhoneContacts = new List<PhoneContact>();
        }
    }
}
```

### Define the DbContext

We have already created a simple model that has Customer and PhoneContact classes, now let’s ensure that these classes are part of the DbContext by defining a new context called EntityContext.

So first we will create a new folder called Data and add an EntityContext class in that folder.

```csharp
using EFWebServices.Models;
using Microsoft.EntityFrameworkCore;

namespace EFWebServices.Data
{
    public class EntityContext : DbContext
    {
        public EntityContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=EFWithXamarinRemotDb;");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<PhoneContact> PhoneContacts { get; set; }
    }
}
```

In ASP.NET Core, services such as the DB context must be registered with the dependency injection (DI) container. The container provides the service to controllers, so we need to update ConfigureServices in Startup.cs with the following code.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    services.AddDbContext<EntityContext>();
}
```

### Scaffold Controller

We will create the controller classes in which API methods will reside using the scaffolding process. Right-click the Controllers folder and select Add > New Scaffolded Item.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/android-with-entity-framework-core/images/remote-database-4.png">

Select API Controller with actions, using Entity Framework, and then select Add.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/android-with-entity-framework-core/images/remote-database-5.png">

In the Add API Controller with actions, using Entity Framework dialog. Select Customer (EFWebServices.Models) in the Model class, EntityContext (EFWebServices.Data) in the Data context class and enter CustomerController in the Controller name. Click the Add button.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFWebServices.Data;
using EFWebServices.Models;
using System.Collections.ObjectModel;

namespace EFWebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly EntityContext _context;

        public CustomerController(EntityContext context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customer/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerID)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customer
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.CustomerID }, customer);
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerID == id);
        }
    }
}
```

 - The generated code marks the class with the [ApiController] attribute. 
 - This attribute indicates that the controller responds to web API requests. 
 - The database context is used in each of the CRUD methods in the controller.

The HTTP POST method, as indicated by the [HttpPost] attribute gets the value of the Customer item from the body of the HTTP request.

## Export Data to a Remote Database

Now let’s say we want to export all the customers from our local SQLite database to the remote database. So, we need to add a method to Web Service which will get a list of customers from the body of the HTTP request.

Let’s update the PostCustomer method in a CustomerController so that it gets a list of customers instead of a single customer object and save that list to the database.

```csharp
[HttpPost]
public async Task<ActionResult<List<Customer>>> PostCustomer(List<Customer> customers)
{
    _context.Customers.AddRange(customers);
    await _context.SaveChangesAsync();

    return NoContent();
}
```

When you want to insert hundreds, thousands, or millions of entities, and your application suffers from performance issues. 

 - The DbContext.SaveChanges is a poor choice for BULK operations as far as performance is concerned. 
 - Once you get beyond a few thousand records, the SaveChanges method starts to break down.

### Insert Multiple Records

The most significant and recommended solution is BulkInsert provided by Entity Framework Extensions library. So let’s install the Z.EntityFramework.Extensions.EFCore NuGet Package and replace the following code in the PostCustomer method.

```csharp
[HttpPost]
public async Task<ActionResult<List<Customer>>> PostCustomer(List<Customer> customers)
{
    await _context.BulkInsertAsync(customers);

    return NoContent();
}
```

Now make sure that your web service is published and running on the server to which you want to export the data.

### Consume Web Services

The REST service is written using ASP.NET Core and provides the following operations:

|Operation                  |HTTP method  |Relative URI               |Parameters                  |
|:--------------------------|:------------|:--------------------------|:---------------------------|
|Get a list of customers    |GET          |/api/customer/             |                            |
|Create a list of customers |POST         |/api/customer/             |A JSON formatted customers  |
|Update a customer          |PUT          |/api/customer/             |A JSON formatted customer   |
|Delete a customers         |DELETE       |/api/customer/{id}         |                            |

To consume the web service and export all the customers to the remote database. Open the Xamarin app and add a **Move** button in the **CustomerList.xaml**.

```csharp
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:d="http://xamarin.com/schemas/2014/forms/design"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
             mc:Ignorable="d"
             Title="Customers"
             x:Class="EFWithXamarin.Views.CustomerList">
    <ContentPage.ToolbarItems>
        <ToolbarItem Text="Move"
                     Clicked="OnCustomersMoveClicked" />
        <ToolbarItem Text="+"
                     Clicked="OnCustomerAddedClicked" />
    </ContentPage.ToolbarItems>
    <ListView x:Name="listView"
              Margin="20"
              ItemSelected="OnListViewItemSelected">
        <ListView.ItemTemplate>
            <DataTemplate>
                <TextCell Text="{Binding Name}"
                      Detail="{Binding Description}" />
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
</ContentPage>
```

Now we need to implement the **OnCustomersMoveClicked** event so that when a user taps this item it will call the web service and send all the customers in JSON format.

```csharp
async void OnCustomersMoveClicked(object sender, EventArgs e)
{
    HttpClientHandler handler = new HttpClientHandler();
    HttpClient _client = new HttpClient(handler);

    var uri = new Uri(@"https://domain/api/customer"); // replace domain with your server domain name or IP address of the remote server.

    try
    {
        EntityFrameworkService entityFrameworkService = new EntityFrameworkService();

        var json = JsonConvert.SerializeObject(entityFrameworkService.GetAll());
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await _client.PostAsync(uri, content);

        if (response.IsSuccessStatusCode)
        {
            Debug.WriteLine(@"\tTodoItem successfully saved.");
        }

    }
    catch (Exception ex)
    {
        Debug.WriteLine(@"\tERROR {0}", ex.Message);
    }
}
```

Let’s run your application.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/android-with-entity-framework-core/images/remote-database-6.png">

Tap the Move button and it will export all the customers from the local database to the remote database using the web service. 
