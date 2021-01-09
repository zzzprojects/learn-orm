---
PermaID: 100010
Name: Searching or Filtering
---

# Searching or Filtering

In this article, we will add searching or filtering to `Authors` index page. To add searching we will add a text box and a submit button to the view and make corresponding changes in the Index method. The text box lets you enter a string to search for in the first name and last name fields. 

## Update Index Action

In ***Controllers\AuthorController.cs***, replace the `Index` method with the following code.

```csharp
public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
{
    ViewBag.CurrentSort = sortOrder;

    ViewBag.FirstNameSortParm = sortOrder == "first_name" ? "first_name_desc" : "first_name";
    ViewBag.LastNameSortParm = sortOrder == "last_name" ? "last_name_desc" : "last_name";
    ViewBag.BirthDateSortParm = sortOrder == "birth_date" ? "birth_date_desc" : "birth_date";

    if (searchString != null)
    {
        page = 1;
    }
    else
    {
        searchString = currentFilter;
    }

    ViewBag.CurrentFilter = searchString;

    var authors = db.Authors.AsQueryable();

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

    int pageSize = 3;
    int pageNumber = (page ?? 1);
    return View(authors.ToPagedList(pageNumber, pageSize));
}
```

The above code adds a `currentFilter`, `searchString` parameters to the method signature. The `searchString` value is received from a text box that the user will add to the Index view.

```csharp
if (searchString != null)
{
    page = 1;
}
else
{
    searchString = currentFilter;
}

ViewBag.CurrentFilter = searchString;
```

The `ViewBag.CurrentFilter` provides the view with the current filter string. This value must be included in the paging links in order to maintain the filter settings during paging, and it must be restored to the text box when the page is redisplayed.

## Update Index View

In ***Views\Author\Index.cshtml***, replace the following code. 

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

@using (Html.BeginForm("Index", "Author", FormMethod.Get))
{
    <p>
        Find by name: @Html.TextBox("SearchString", ViewBag.CurrentFilter as string)
        <input type="submit" value="Search" />
    </p>
}

<table class="table">
    <tr>
        <th>
            @Html.ActionLink("First Name", "Index", new { sortOrder = ViewBag.FirstNameSortParm, currentFilter = ViewBag.CurrentFilter })
        </th>
        <th>
            @Html.ActionLink("Last Name", "Index", new { sortOrder = ViewBag.LastNameSortParm, currentFilter = ViewBag.CurrentFilter })
        </th>
        <th>
            @Html.ActionLink("Birth Date", "Index", new { sortOrder = ViewBag.BirthDateSortParm, currentFilter = ViewBag.CurrentFilter })
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

@Html.PagedListPager(Model, page => Url.Action("Index", new { page, sortOrder = ViewBag.CurrentSort, currentFilter = ViewBag.CurrentFilter }))
```

The following code will create a caption, a text box, and a Search button.

```csharp
@using (Html.BeginForm("Index", "Author", FormMethod.Get))
{
    <p>
        Find by name: @Html.TextBox("SearchString", ViewBag.CurrentFilter as string)
        <input type="submit" value="Search" />
    </p>
}
```

The column header links use the query string to pass the current search string to the controller so that the user can sort within filter results as shown below.

```csharp
<tr>
    <th>
        @Html.ActionLink("First Name", "Index", new { sortOrder = ViewBag.FirstNameSortParm, currentFilter = ViewBag.CurrentFilter })
    </th>
    <th>
        @Html.ActionLink("Last Name", "Index", new { sortOrder = ViewBag.LastNameSortParm, currentFilter = ViewBag.CurrentFilter })
    </th>
    <th>
        @Html.ActionLink("Birth Date", "Index", new { sortOrder = ViewBag.BirthDateSortParm, currentFilter = ViewBag.CurrentFilter })
    </th>
    <th></th>
</tr>
```

Let's run your application and you will see pagination on `Author` index page.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/mvc-with-entity-framework-6/images/searching-or-filtering-1.png">

Enter a search string, and click Search to verify that filtering is working and also click the paging links in different sort orders to make sure paging works.
