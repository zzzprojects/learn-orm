---
PermaID: 100008
Name: Sorting
---

# Sorting

With the help of sorting, you can sort any column by clicking a column heading repeatedly to toggles between ascending and descending sort order. To add sorting to the `Author` Index page, we need to change the `Index` method of the `AuthorController` and the ***Views\Author\Index.cshtml*** view.

## Update Index Action

In ***Controllers\AuthorController.cs***, replace the `Index` method with the following code.

```csharp
public ActionResult Index(string sortOrder)
{
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
    return View(authors.ToList());
}
```

The above code receives a `sortOrder` parameter from the query string in the URL. The parameter is a string that's either "first_name", "last_name" or " birth_date", optionally followed by an underscore and the string "desc" to specify descending order.

The three ViewBag variables are used so that the view can configure the column heading hyperlinks with the appropriate query string values.

```csharp
ViewBag.FirstNameSortParm = sortOrder == "first_name" ? "first_name_desc" : "first_name";
ViewBag.LastNameSortParm = sortOrder == "last_name" ? "last_name_desc" : "last_name";
ViewBag.BirthDateSortParm = sortOrder == "birth_date" ? "birth_date_desc" : "birth_date";
```

The method uses LINQ to Entities to specify the column to sort by. The code creates an `IQueryable<T>` variable before the switch statement, modifies it in the switch statement, and calls the `ToList` method after the switch statement. 

 - The first time the `Index` page is requested, there's no query string. 
 - The authors are displayed in ascending order by `LastName`, which is the default as established by the fall-through case in the switch statement. 
 - When the user clicks a column heading hyperlink, the appropriate `sortOrder` value is provided in the query string.


## Update Index View

In ***Views\Authort\Index.cshtml***, replace the following code.

```csharp
@model IEnumerable<MvcWithEF6Demo.Models.Author>

@{
    ViewBag.Title = "Index";
}

<h2>Index</h2>

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
            @Html.ActionLink("Edit", "Edit", new { id=item.AuthorId }) |
            @Html.ActionLink("Details", "Details", new { id=item.AuthorId }) |
            @Html.ActionLink("Delete", "Delete", new { id=item.AuthorId })
        </td>
    </tr>
}

</table>
```

This code uses the information in the `ViewBag` properties to set up hyperlinks with the appropriate query string values. Let's run your application and click on the **Authors** menu option.

<img src="images/sorting-1.png">

The column headings are links that the user can click to sort by that column.

