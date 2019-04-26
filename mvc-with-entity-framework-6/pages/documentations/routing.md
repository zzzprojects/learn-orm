---
PermaID: 100003
Name: Routing
---

# Routing

The ASP.NET Routing module is responsible for mapping incoming browser requests to particular MVC controller actions. 

 - Route defines the URL pattern and handler information. 
 - All the configured routes of an application stored in RouteTable and will be used by Routing engine to determine appropriate handler class or file for an incoming request.
 - Routing is used to create user-friendly URLs. 
 - It can also be used to set up the startup page of the application, just like the ASP.NET Web Forms. 
 - The routing system enables us to create any pattern of URLs you desire and express them in a clear and concise manner.

## Default Routing

When you create a new ASP.NET MVC application, the application is already configured to use ASP.NET Routing in `Web.config` file.

```csharp
<system.webServer>
  <modules>
    <remove name="TelemetryCorrelationHttpModule" />
    <add name="TelemetryCorrelationHttpModule" 
         type="Microsoft.AspNet.TelemetryCorrelation.TelemetryCorrelationHttpModule, Microsoft.AspNet.TelemetryCorrelation" 
         preCondition="integratedMode,managedHandler" />
  </modules>
</system.webServer>
``` 

> Be careful not to delete these sections because without these sections routing will no longer work.

The routes are registered in the `Global.asax` file by invoking a `RegisterRoutes` method in the `Application_Start()` method. A route table is created in the `App_Start\RouteConfig.cs` file. 

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcWithEF6Demo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
```

 - `The MapRout()` method is an extension method and we have to define the route `name` which is **default**; 
 - If you want to create a new route then you can specify another name because the name can't be the same. 
 - In the URL there are some variables like `controller`, `action` and `id`. 
 - In the defaults it will call a `Home` controller, `Index` action and `id` which is optional.

## Custom Routing

In many simple ASP.NET MVC applications, the default route table will work, but you can also create a custom route. You can register multiple custom routes with different names.

```csharp
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcWithEF6Demo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Author_Details",
                url: "authors/{id}",
                defaults: new { controller = "Author", action = "Details" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
```

In the above code, the URL pattern for the ***Author_Details*** route is ***authors/{id}***, which specifies that any URL that starts with ***domain/authors**, must be handled by `AuthorController`. 

 - You will see that we haven't specified ***{action}*** in the URL pattern because we want every URL that starts with ***domain/authors** should always use `Details` action of `AuthorController`. 
 - We have specified default controller and action to handle any URL request which starts from ***domain/authors**.
 - MVC framework evaluates each route in sequence. 
 - It starts with the first configured route and if incoming URL doesn't satisfy the URL pattern of the route then it will evaluate the second route and so on.

### Examples

The following table shows which `Controller`, `Action` method and `Id` parameter would handle different URLs considering above default route.

|URL                                    |Controller            |Action        |Id |
|---------------------------------------|-------------------|-----------|---|
|http://localhost:58379/                |HomeController        |Index        |   |
|http://localhost:58379/Author/            |AuthorController   |Index        |   |
|http://localhost:58379/Author/Create    |AuthorController   |Create        |   |
|http://localhost:58379/Author/Edit/2    |AuthorController   |Edit         |2  |
|http://localhost:58379/Author/Delete/3 |AuthorController   |Delete     |3  |
|http://localhost:58379/Authors/1       |AuthorController   |Details    |1  |

The controller and action values in the route are not case-sensitive and the URL route patterns are relative to the application root.
