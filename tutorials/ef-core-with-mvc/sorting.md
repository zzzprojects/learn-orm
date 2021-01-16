---
PermaID: 100005
Name: Sorting
---

# Sorting

With the help of sorting, you can sort any column by clicking a column heading repeatedly to toggles between ascending and descending sort order. To add sorting to the `Author` Index page, we need to change the `Index` method of the `AuthorController` and the ***Views\Author\Index.cshtml*** view.

## Update Index Action

In ***Controllers\AuthorController.cs***, replace the `Index` method with the following code.

```csharp
public async Task<IActionResult> Index(string sortOrder)
{
    ViewData["FirstNameSortParm"] = sortOrder == "first_name" ? "first_name_desc" : "first_name";
    ViewData["LastNameSortParm"] = sortOrder == "last_name" ? "last_name_desc" : "last_name";
    ViewData["BirthDateSortParm"] = sortOrder == "birth_date" ? "birth_date_desc" : "birth_date";

    var authors = _context.Authors.AsQueryable();

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

The above code receives a `sortOrder` parameter from the query string in the URL. The parameter is a string that's either "first_name", "last_name" or " birth_date", optionally followed by an underscore and the string "desc" to specify descending order.

The three ViewData variables are used so that the view can configure the column heading hyperlinks with the appropriate query string values.

```csharp
ViewData["FirstNameSortParm"] = sortOrder == "first_name" ? "first_name_desc" : "first_name";
ViewData["LastNameSortParm"] = sortOrder == "last_name" ? "last_name_desc" : "last_name";
ViewData["BirthDateSortParm"] = sortOrder == "birth_date" ? "birth_date_desc" : "birth_date";
```

The method uses LINQ to Entities to specify the column to sort by. The code creates an `IQueryable<T>` variable before the switch statement, modifies it in the switch statement, and calls the `ToList` method after the switch statement. 

 - The first time the `Index` page is requested, there's no query string. 
 - The authors are displayed in ascending order by `LastName`, which is the default as established by the fall-through case in the switch statement. 
 - When the user clicks a column heading hyperlink, the appropriate `sortOrder` value is provided in the query string.


## Update Index View

In ***Views\Authort\Index.cshtml***, replace the following code.

```csharp
@model IEnumerable<MvcWithEFCoreDemo.Models.Author>

@{
    ViewData["Title"] = "Index";
}

<h1>Index</h1>

<p>
    <a asp-action="Create">Create New</a>
</p>
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

This code uses the information in the `ViewBag` properties to set up hyperlinks with the appropriate query string values. Let's run your application and click on the **Authors** menu option.

<img src="images/sorting-1.png">

The column headings are links that the user can click to sort by that column.
