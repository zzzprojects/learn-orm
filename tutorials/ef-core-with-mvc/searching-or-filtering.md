---
PermaID: 100006
Name: Searching or Filtering
---

# Searching or Filtering

In this article, we will add searching or filtering to the `Authors` index page. To add searching we will add a text box and a submit button to the view and make corresponding changes in the Index method. The text box lets you enter a string to search for in the first name and last name fields. 

## Update Index Action

In ***Controllers\AuthorController.cs***, replace the `Index` method with the following code.

```csharp
public async Task<IActionResult> Index(string sortOrder, string searchString)
{
    ViewData["FirstNameSortParm"] = sortOrder == "first_name" ? "first_name_desc" : "first_name";
    ViewData["LastNameSortParm"] = sortOrder == "last_name" ? "last_name_desc" : "last_name";
    ViewData["BirthDateSortParm"] = sortOrder == "birth_date" ? "birth_date_desc" : "birth_date";
    ViewData["CurrentFilter"] = searchString;

    var authors = _context.Authors.AsQueryable();

    if (!String.IsNullOrEmpty(searchString))
    {
        authors = authors.Where(a => a.LastName.Contains(searchString)
                               || a.FirstName.Contains(searchString));
    }

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
    return View(await authors.ToListAsync());
}
```

 - The above code adds a `searchString` parameter to the Index method. The `searchString` value is received from a text box that the user will add to the Index view. 
 - It has also added a where clause to the LINQ statement that selects only authors whose first name or last name contains the search string. 
 - The statement that adds the where clause is executed only if there's a value to search for.

## Update Index View

In ***Views\Author\Index.cshtml***, replace the following code. 

```csharp
@model IEnumerable<MvcWithEFCoreDemo.Models.Author>

@{
    ViewData["Title"] = "Index";
}

<h1>Index</h1>

<p>
    <a asp-action="Create">Create New</a>
</p>

<form asp-action="Index" method="get">
    <div class="form-actions no-color">
        <p>
            Find by name: <input type="text" name="SearchString" value="@ViewData["currentFilter"]" />
            <input type="submit" value="Search" class="btn btn-default" /> |
            <a asp-action="Index">Back to Full List</a>
        </p>
    </div>
</form>

<table class="table">
    <thead>
        <tr>
            <th>
                <a asp-action="Index" asp-route-sortOrder="@ViewData["FirstNameSortParm"]">@Html.DisplayNameFor(model => model.FirstName)</a>
            </th>
            <th>
                <a asp-action="Index" asp-route-sortOrder="@ViewData["LastNameSortParm"]">@Html.DisplayNameFor(model => model.LastName)</a>
            </th>
            <th>
                <a asp-action="Index" asp-route-sortOrder="@ViewData["BirthDateSortParm"]">@Html.DisplayNameFor(model => model.BirthDate)</a>
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
    @foreach (var item in Model) {
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
                <a asp-action="Edit" asp-route-id="@item.AuthorId">Edit</a> |
                <a asp-action="Details" asp-route-id="@item.AuthorId">Details</a> |
                <a asp-action="Delete" asp-route-id="@item.AuthorId">Delete</a>
            </td>
        </tr>
    }
    </tbody>
</table>
```

The following code will create a caption, a text box, and a Search button.

```csharp
<form asp-action="Index" method="get">
    <div class="form-actions no-color">
        <p>
            Find by name: <input type="text" name="SearchString" value="@ViewData["currentFilter"]" />
            <input type="submit" value="Search" class="btn btn-default" /> |
            <a asp-action="Index">Back to Full List</a>
        </p>
    </div>
</form>
```

Let's run your application, select the Authors tab, enter a search string, and click Search to verify that filtering is working.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/mvc-with-entity-framework-core/images/searching-or-filtering-1.png">
