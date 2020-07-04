---
PermaID: 100006
Name: Controller Actions
---

# Controller Actions

A controller action is a method on a controller that gets called when you enter a particular URL in your browser address bar. For example, you make a request for the following URL.

```csharp
http://localhost:58379/Author/Edit/3
```

In this case, the `Edit()` action method is called on the `AuthorController`.

```csharp
public ActionResult Edit(int? id)
{
    if (id == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
    Author author = db.Authors.Find(id);
    if (author == null)
    {
        return HttpNotFound();
    }
    return View(author);
}
```

 - A controller action must be a public method of a controller class. 
 - When you add a public method to a controller class is exposed as a controller action automatically.
 - A method used as a controller action cannot be overloaded. 
 - Controller action cannot be a static method. 
 - You can use just about any method as a controller action.

## Action Results

A controller action returns an action result in response to a browser request. The ASP.NET MVC framework supports several types of action results including:

 - **ViewResult:** Represents HTML and markup.
 - **EmptyResult:** Represents no result.
 - **RedirectResult:** Represents a redirection to a new URL.
 - **JsonResult:** Represents a JavaScript Object Notation result that can be used in an AJAX application.
 - **JavaScriptResult:** Represents a JavaScript script.
 - **ContentResult:** Represents a text result.
 - **FileContentResult:** Represents a downloadable file (with the binary content).
 - **FilePathResult:** Represents a downloadable file (with a path).
 - **FileStreamResult:** Represents a downloadable file (with a file stream).

All of these action results inherit from the base ActionResult class, and mostly a controller action returns a ViewResult.

## Controller Base Class

Normally, you do not return an action result directly, instead, you can call one of the following methods of the Controller base class:

 - **View:** Returns a ViewResult action result.
 - **Redirect:** Returns a RedirectResult action result.
 - **RedirectToAction:** Returns a RedirectToRouteResult action result.
 - **RedirectToRoute:** Returns a RedirectToRouteResult action result.
 - **Json:** Returns a JsonResult action result.
 - **JavaScriptResult:** Returns a JavaScriptResult.
 - **Content:** Returns a ContentResult action result.
 - **File:** Returns a FileContentResult, FilePathResult, or FileStreamResult depending on the parameters passed to the method.

For example, the `Index()` action in `AuthorController` does not return a `ViewResult()`. Instead, the `View()` method of the Controller base class is called.

```csharp
public ActionResult Index()
{
    return View(db.Authors.ToList());
}
```

So, if you want to return a View to the browser, you call the `View()` method. If you want to redirect the user from one controller action to another, you call the `RedirectToAction()` method. 

```csharp
public ActionResult Create([Bind(Include = "AuthorId,FirstName,LastName,BirthDate")] Author author)
{
    try
    {
        if (ModelState.IsValid)
        {
            db.Authors.Add(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
    catch (DataException)
    {
        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
    }
    return View(author);
}
```
The `Create` action in `AuthorController` either redirects the user to the `Index()` action or displays a view depending on whether the model state is valid.
