---
PermaID: 100006
Name: Sorting
---

# Sorting

With the help of sorting, you can sort any column by clicking a column repeatedly heading to toggles between ascending and descending sort order. To add sorting to the `Author` Index page, we need to change the `Index` method of the `AuthorController` and the ***Views\Author\Index.cshtml*** view.

## Update Index Action

In ***Controllers\AuthorController.cs***, replace the `Index` method with the following code.

```csharp
// GET: AuthorController
public ActionResult Index(string sortOrder)
{
    string sqlAuthors = "SELECT * FROM Authors;";

    using (var connection = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=AuthorDb;Trusted_Connection=True;MultipleActiveResultSets=true"))
    {
        var authors = connection.Query<Author>(sqlAuthors).AsQueryable();

        ViewData["FirstNameSortParm"] = sortOrder == "first_name" ? "first_name_desc" : "first_name";
        ViewData["LastNameSortParm"] = sortOrder == "last_name" ? "last_name_desc" : "last_name";
        ViewData["AddressSortParm"] = sortOrder == "address" ? "address_desc" : "address";
        ViewData["CitySortParm"] = sortOrder == "city" ? "city_desc" : "city";
        ViewData["PostalCodeSortParm"] = sortOrder == "postal_code" ? "postal_code_desc" : "postal_code";
        ViewData["CountrySortParm"] = sortOrder == "country" ? "country_desc" : "country";


        switch (sortOrder)
        {
            case "first_name_desc":
                authors = authors.OrderByDescending(a => a.FirstName);
                break;
            case "first_name":
                authors = authors.OrderBy(a => a.FirstName);
                break;
            case "last_name_desc":
                authors = authors.OrderByDescending(a => a.LastName);
                break;
            case "last_name":
                authors = authors.OrderBy(a => a.LastName);
                break;
            case "address":
                authors = authors.OrderBy(a => a.Address);
                break;
            case "address_desc":
                authors = authors.OrderByDescending(a => a.Address);
                break;
            case "city":
                authors = authors.OrderBy(a => a.City);
                break;
            case "city_desc":
                authors = authors.OrderByDescending(a => a.City);
                break;
            case "postal_code":
                authors = authors.OrderBy(a => a.PostalCode);
                break;
            case "postal_code_desc":
                authors = authors.OrderByDescending(a => a.PostalCode);
                break;
            case "country":
                authors = authors.OrderBy(a => a.Country);
                break;
            case "country_desc":
                authors = authors.OrderByDescending(a => a.Country);
                break;
            default:
                authors = authors.OrderBy(a => a.LastName);
                break;
        }
        return View(authors.ToList());
    }
}
```

The above code receives a `sortOrder` parameter from the query string in the URL. The parameter is a string that's either "first_name", "last_name", "address", "city", "postal_code", "country" optionally followed by an underscore and the string "desc" to specify descending order.

The following `ViewData` variables are used so that the view can configure the column heading hyperlinks with the appropriate query string values.

```csharp
ViewData["FirstNameSortParm"] = sortOrder == "first_name" ? "first_name_desc" : "first_name";
ViewData["LastNameSortParm"] = sortOrder == "last_name" ? "last_name_desc" : "last_name";
ViewData["AddressSortParm"] = sortOrder == "address" ? "address_desc" : "address";
ViewData["CitySortParm"] = sortOrder == "city" ? "city_desc" : "city";
ViewData["PostalCodeSortParm"] = sortOrder == "postal_code" ? "postal_code_desc" : "postal_code";
ViewData["CountrySortParm"] = sortOrder == "country" ? "country_desc" : "country";
```

The method uses LINQ to Entities to specify the column to sort by. The code creates an `IQueryable<T>` variable before the switch statement, modifies it in the switch statement, and calls the `ToList` method after the switch statement. 

 - The first time the `Index` page is requested, there's no query string. 
 - The authors are displayed in ascending order by `LastName`, which is the default as established by the fall-through case in the `switch` statement. 
 - When the user clicks a column heading hyperlink, the appropriate `sortOrder` value is provided in the query string.


## Update Index View

In ***Views\Authort\Index.cshtml***, replace the following code. 

```csharp
@model IEnumerable<MvcWithDapper.Models.Author>

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
                <a asp-action="Index" asp-route-sortOrder="@ViewData["AddressSortParm"]">@Html.DisplayNameFor(model => model.Address)</a>
            </th>
            <th>
                <a asp-action="Index" asp-route-sortOrder="@ViewData["CitySortParm"]">@Html.DisplayNameFor(model => model.City)</a>
            </th>
            <th>
                <a asp-action="Index" asp-route-sortOrder="@ViewData["PostalCodeSortParm"]">@Html.DisplayNameFor(model => model.PostalCode)</a>
            </th>
            <th>
                <a asp-action="Index" asp-route-sortOrder="@ViewData["CountrySortParm"]">@Html.DisplayNameFor(model => model.Country)</a>
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
                @Html.DisplayFor(modelItem => item.Address)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.City)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.PostalCode)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Country)
            </td>
            <td>
                @Html.ActionLink("Edit", "Edit", new { id = item.AuthorId }) |
                @Html.ActionLink("Details", "Details", new {  id = item.AuthorId  }) |
                @Html.ActionLink("Delete", "Delete", new { id = item.AuthorId })
            </td>
        </tr>
}
    </tbody>
</table>
```

The above code uses the information in the `ViewBag` properties to set up hyperlinks with the appropriate query string values and also remove the `AuthorId` field. Let's run your application and click on the **Authors** menu option.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/mvc-with-dapper/images/sorting-1.png">

The column headings are links that the user can click to sort by that column.
