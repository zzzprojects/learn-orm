---
PermaID: 100005
Name: Basic CRUD Functionality
---

# Basic CRUD Functionality

In this article, we will customize the create, read, update, delete (CRUD) code that the MVC scaffolding automatically creates for you in controllers and views. Let's run your application.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/mvc-with-entity-framework-6/images/crud-1.png">

In `Details` method, the key value is passed to the method as the `id` parameter and comes from route data in the Details hyperlink on the `Index` page.

You can create new author, delete or edit an author, and you can also see the details of any particular author using the highlighted links. Let's click on Edit link and you only see the author's name.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/mvc-with-entity-framework-6/images/crud-2.png">

## Details View

If you open the `AuthorController` you will see `Details` action method.

```csharp
// GET: Author/Details/5
public ActionResult Details(int? id)
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

The scaffolded code for the author `Details` page left out the `Books` property because that property holds a collection and this is not displayed on `Details.cshtml` file. 

```csharp
@model MvcWithEF6Demo.Models.Author

@{
    ViewBag.Title = "Details";
}

<h2>Details</h2>

<div>
    <h4>Author</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(model => model.FirstName)
        </dt>

        <dd>
            @Html.DisplayFor(model => model.FirstName)
        </dd>

        <dt>
            @Html.DisplayNameFor(model => model.LastName)
        </dt>

        <dd>
            @Html.DisplayFor(model => model.LastName)
        </dd>

        <dt>
            @Html.DisplayNameFor(model => model.BirthDate)
        </dt>

        <dd>
            @Html.DisplayFor(model => model.BirthDate)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", new { id = Model.AuthorId }) |
    @Html.ActionLink("Back to List", "Index")
</p>

```
Each field is displayed using a `DisplayFor` helper, so here we will display the contents of the collection in an HTML table as shown below.

```csharp
@model MvcWithEF6Demo.Models.Author

@{
    ViewBag.Title = "Details";
}

<h2>Details</h2>

<div>
    <h4>Author</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(model => model.FirstName)
        </dt>

        <dd>
            @Html.DisplayFor(model => model.FirstName)
        </dd>

        <dt>
            @Html.DisplayNameFor(model => model.LastName)
        </dt>

        <dd>
            @Html.DisplayFor(model => model.LastName)
        </dd>

        <dt>
            @Html.DisplayNameFor(model => model.BirthDate)
        </dt>

        <dd>
            @Html.DisplayFor(model => model.BirthDate)
        </dd>
        <dt>
            @Html.DisplayNameFor(model => model.Books)
        </dt>
        <dd>
            <table class="table">
                <tr>
                    <th>Book Title</th>
                </tr>
                @foreach (var item in Model.Books)
                {
                    <tr>
                        <td>
                            @Html.DisplayFor(modelItem => item.Title)
                        </td>
                    </tr>
                }
            </table>
        </dd>
    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", new { id = Model.AuthorId }) |
    @Html.ActionLink("Back to List", "Index")
</p>
```
Now run your application and go to the details page.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/mvc-with-entity-framework-6/images/crud-3.png">

## Create View

In `AuthorController`, you will see `Create` action method.

```csharp
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Create([Bind(Include = "AuthorId,FirstName,LastName,BirthDate")] Author author)
{
    if (ModelState.IsValid)
    {
        db.Authors.Add(author);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    return View(author);
}
```

 - This code adds the `Author` entity created by the ASP.NET MVC model binder to the `Authors` entity set and then saves the changes to the database. 
 - Model binder refers to the ASP.NET MVC functionality that makes it easier for you to work with data submitted by a form. 
 - A model binder converts posted form values to CLR types and passes them to the action method in parameters. 
 - In this case, the model binder instantiates an `Author` entity for you using property values from the Form collection.

Let's update `Create` action method adding a try-catch block.

```csharp
[HttpPost]
[ValidateAntiForgeryToken]
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

The code in `Views\Author\Create.cshtml` is similar to what we saw in `Details.cshtml`, except that `EditorFor` and `ValidationMessageFor` helpers are used for each field instead of `DisplayFor`.

```csharp
@model MvcWithEF6Demo.Models.Author

@{
    ViewBag.Title = "Create";
}

<h2>Create</h2>


@using (Html.BeginForm()) 
{
    @Html.AntiForgeryToken()
    
    <div class="form-horizontal">
        <h4>Author</h4>
        <hr />
        @Html.ValidationSummary(true, "", new { @class = "text-danger" })
        <div class="form-group">
            @Html.LabelFor(model => model.FirstName, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.FirstName, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.FirstName, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(model => model.LastName, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.LastName, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.LastName, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(model => model.BirthDate, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.BirthDate, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.BirthDate, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Create" class="btn btn-default" />
            </div>
        </div>
    </div>
}

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@section Scripts {
    @Scripts.Render("~/bundles/jqueryval")
}
```

It also includes `@Html.AntiForgeryToken()`, which works with the `ValidateAntiForgeryToken` attribute in the controller to help prevent cross-site request forgery attacks.

## Edit View

```csharp
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Edit([Bind(Include = "AuthorId,FirstName,LastName,BirthDate")] Author author)
{
    if (ModelState.IsValid)
    {
        db.Entry(author).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
    }
    return View(author);
}
```

 - The scaffolder generated a `Bind` attribute and added the entity created by the model binder to the entity set with a `Modified` flag. 
 - It is no longer recommended because the `Bind` attribute clears out any pre-existing data in fields not listed in the `Include` parameter.

Let's implement a security best practice to prevent overposting by reading the existing entity and calls `TryUpdateModel` to update fields from user input in the posted form data.

```csharp
[HttpPost, ActionName("Edit")]
[ValidateAntiForgeryToken]
public ActionResult EditPost(int? id)
{
    var author = db.Authors.Find(id);
    if (TryUpdateModel(author, "", new string[] { "FirstName", "LastName", "BirthDate" }))
    {
        try
        {
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        catch (DataException /* dex */)
        {
            //Log the error (uncomment dex variable name and add a line here to write a log.
            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
        }
    }

    return View(author);
}
```

 - To prevent overposting, the fields that you want to be updateable by the Edit page are whitelisted in the `TryUpdateModel` parameters. 
 - The Entity Framework's automatic change tracking sets the `EntityState.Modified` flag on the entity. 
 - When the `SaveChanges` method is called, the `Modified` flag causes EF to create SQL statements to update the database row. 
 - As a result of these changes, the method signature of the `HttpPost` Edit method is the same as the `HttpGet` Edit method; therefore we have renamed the method to `EditPost`.
 - The HTML and Razor code in `Views\Author\Edit.cshtml` is similar to what you saw in `Create.cshtml`, and no changes are required.

## Delete View

In `Controllers\AuthorController.cs`, the template code for the `HttpGet Delete` method uses the `Find` method to retrieve the selected `Author` entity, as we saw in the `Details` and `Edit` methods. 

 - However, to implement a custom error message when the call to `SaveChanges` fails, we will add some functionality to this method and its corresponding view.
 - The delete operations require two action methods. 

```csharp
// GET: Author/Delete/5
public ActionResult Delete(int? id)
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

// POST: Author/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public ActionResult DeleteConfirmed(int id)
{
    Author author = db.Authors.Find(id);
    db.Authors.Remove(author);
    db.SaveChanges();
    return RedirectToAction("Index");
}
```

 - The method that is called in response to a `GET` request displays a view that gives the user a chance to approve or cancel the delete operation. 
 - If the user approves it, a `POST` request is created, the `HttpPost Delete` (named `DeleteConfirmed`) method is called and then that method actually performs the delete operation.

We will add a `try-catch` block to the `DeleteConfirmed` method to handle any errors that might occur when the database is updated and also change the method name to `Delete`. So let's replace the `DeleteConfirmed` method with the following code, which performs the actual delete operation and catches any database update errors.

```csharp
// POST: Author/Delete/5
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Delete(int id)
{
    try
    {
        Author author = db.Authors.Find(id);
        db.Authors.Remove(author);
        db.SaveChanges();
    }
    catch (DataException/* dex */)
    {
        //Log the error (uncomment dex variable name and add a line here to write a log.
        return RedirectToAction("Delete", new { id = id, saveChangesError = true });
    }

    return RedirectToAction("Index");
}
```

 - If an error occurs, the `HttpPost Delete` method calls the `HttpGet Delete` method, passing it a parameter that indicates that an error has occurred. 
 - The `HttpGet Delete` method then redisplays the confirmation page along with the error message, giving the user an opportunity to cancel or try again.

Let's replace the `HttpGet Delete` action method with the following code, which manages error reporting.

```csharp
// GET: Author/Delete/5
public ActionResult Delete(int? id, bool? saveChangesError = false)
{
    if (id == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
    if (saveChangesError.GetValueOrDefault())
    {
        ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
    }
    Author author = db.Authors.Find(id);
    if (author == null)
    {
        return HttpNotFound();
    }
    return View(author);
}
```

 - It retrieves the selected entity, then calls the `Remove` method to set the entity's status to Deleted. 
 - When `SaveChanges` is called, a SQL `DELETE` command is generated. 

In `Views\Author\Delete.cshtml`, add an error message `@ViewBag.ErrorMessage` between the `<h2>` heading and the `<h3>` heading as shown below.

```csharp
@model MvcWithEF6Demo.Models.Author

@{
    ViewBag.Title = "Delete";
}

<h2>Delete</h2>
<p class="error">@ViewBag.ErrorMessage</p>
<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Author</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(model => model.FirstName)
        </dt>

        <dd>
            @Html.DisplayFor(model => model.FirstName)
        </dd>

        <dt>
            @Html.DisplayNameFor(model => model.LastName)
        </dt>

        <dd>
            @Html.DisplayFor(model => model.LastName)
        </dd>

        <dt>
            @Html.DisplayNameFor(model => model.BirthDate)
        </dt>

        <dd>
            @Html.DisplayFor(model => model.BirthDate)
        </dd>

    </dl>

    @using (Html.BeginForm()) {
        @Html.AntiForgeryToken()

        <div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    }
</div>
```