---
PermaID: 100007
Name: Searching or Filtering
---

# Searching or Filtering

In this article, we will add searching or filtering to the `Authors` index page. To add searching, we will add a text box and a submit button to the view and make corresponding changes in the `Index` method. The text box lets you enter a string to search for in the first and last name fields. 

## Update Index Action

In ***Controllers\AuthorController.cs***, replace the `Index` method with the following code.

```csharp
// GET: AuthorController
public ActionResult Index(string sortOrder, string searchString)
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
        ViewData["CurrentFilter"] = searchString;

        if (!String.IsNullOrEmpty(searchString))
        {
            authors = authors.Where(a => a.LastName.Contains(searchString)
                                   || a.FirstName.Contains(searchString));
        }

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

 - The above code adds a `searchString` parameter to the Index method. The `searchString` value is received from a text box that the user will add to the Index view. 
 - It has also added a where clause to the LINQ statement that selects only authors whose first name or last name contains the search string. 
 - The statement that adds the where clause is only executed if there's a value to search for.

## Update Index View

In ***Views\Author\Index.cshtml***, replace the following code. 

```csharp
@model IEnumerable<MvcWithDapper.Models.Author>

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

Let's run your application, select the **Authors** tab, enter a search string, and click **Search** to verify that filtering is working.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/mvc-with-dapper/images/searching-or-filtering-1.png">
