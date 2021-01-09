---
PermaID: 100009
Name: Paging
---

# Paging

In this article, we will add paging to `Authors` index page. To add paging we will install the `PagedList.Mvc` NuGet package. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/mvc-with-entity-framework-6/images/paging-1.png">

`PagedList.Mvc` is one of many good paging and sorting packages for ASP.NET MVC, and its use here is intended only as an example, not as a recommendation for it over other options.

## Update Index Action

In ***Controllers\AuthorController.cs***, replace the `Index` method with the following code.

```csharp
public ActionResult Index(string sortOrder, int? page)
{
    ViewBag.CurrentSort = sortOrder;

    ViewBag.FirstNameSortParm = sortOrder == "first_name" ? "first_name_desc" : "first_name";
    ViewBag.LastNameSortParm = sortOrder == "last_name" ? "last_name_desc" : "last_name";
    ViewBag.BirthDateSortParm = sortOrder == "birth_date" ? "birth_date_desc" : "birth_date";

    var authors = db.Authors.AsQueryable();

    switch (sortOrder)
    {                
        case "first_name_desc":
            authors = authors.OrderByDescending(s => s.FirstName);
            break;
        case "first_name":
            authors = authors.OrderBy(s => s.FirstName);
            break;
        case "last_name_desc":
            authors = authors.OrderByDescending(s => s.LastName);
            break;
        case "last_name":
            authors = authors.OrderBy(s => s.LastName);
            break;
        case "birth_date":
            authors = authors.OrderBy(s => s.BirthDate);
            break;
        case "birth_date_desc":
            authors = authors.OrderByDescending(s => s.BirthDate);
            break;
        default:
            authors = authors.OrderBy(s => s.LastName);
            break;
    }

    int pageSize = 3;
    int pageNumber = (page ?? 1);
    return View(authors.ToPagedList(pageNumber, pageSize));
}
```

The above code adds a `page` parameter to the method signature.

 - The first time the page is displayed, or if the user hasn't clicked a paging or sorting link, all the parameters are null. 
 - If a paging link is clicked, the `page` variable contains the page number to display.

A `ViewBag.CurrentSort` property provides the view with the current sort order because this must be included in the paging links in order to keep the sort order the same while paging.

```csharp
ViewBag.CurrentSort = sortOrder;
```

The `ToPagedList` extension method on the authors `IQueryable` object converts the author query to a single page of students in a collection type that supports paging. That single page of authors is then passed to the view.

```csharp
int pageSize = 3;
int pageNumber = (page ?? 1);
return View(authors.ToPagedList(pageNumber, pageSize));
```

Make sure to add a `using` statement for the `PagedList` namespace.

```csharp
using PagedList;
```

## Update Index View

In ***Views\Author\Index.cshtml***, replace the existing code with the following code.

```csharp
@model PagedList.IPagedList<MvcWithEF6Demo.Models.Author>
@using PagedList.Mvc;
<link href="~/Content/PagedList.css" rel="stylesheet" type="text/css" />

@{
    ViewBag.Title = "Authors";
}

<h2>Auhtors</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.ActionLink("First Name", "Index", new { sortOrder = ViewBag.FirstNameSortParm })
        </th>
        <th>
            @Html.ActionLink("Last Name", "Index", new { sortOrder = ViewBag.LastNameSortParm })
        </th>
        <th>
            @Html.ActionLink("Birth Date", "Index", new { sortOrder = ViewBag.BirthDateSortParm })
        </th>
        <th></th>
    </tr>

    @foreach (var item in Model)
    {
        <tr>
            <td>
                @Html.DisplayFor(modelItem => item.FirstName)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.LastName)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.BirthDate)
            </td>
            <td>
                @Html.ActionLink("Edit", "Edit", new { id = item.AuthorId }) |
                @Html.ActionLink("Details", "Details", new { id = item.AuthorId }) |
                @Html.ActionLink("Delete", "Delete", new { id = item.AuthorId })
            </td>
        </tr>
    }

</table>

<br />
Page @(Model.PageCount < Model.PageNumber ? 0 : Model.PageNumber) of @Model.PageCount

@Html.PagedListPager(Model, page => Url.Action("Index", new { page, sortOrder = ViewBag.CurrentSort }))
```

The `@model` statement at the top of the page specifies that the view now gets a `PagedList` object instead of a `List` object.

The `using` statement for `PagedList.Mvc` gives access to the MVC helper for the paging buttons.

```csharp
Page @(Model.PageCount < Model.PageNumber ? 0 : Model.PageNumber) of @Model.PageCount
```

The paging buttons are displayed by the `PagedListPager` helper.

```csharp
@Html.PagedListPager(Model, page => Url.Action("Index", new { page, sortOrder = ViewBag.CurrentSort }))
```

The `PagedListPager` helper provides a number of options that you can customize, including URLs and styling. Let's run your application and you will see pagination on `Author` index page.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/mvc-with-entity-framework-6/images/paging-2.png">

Click the paging links to make sure paging works.