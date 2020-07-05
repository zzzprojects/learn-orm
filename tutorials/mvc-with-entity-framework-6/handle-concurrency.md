---
PermaID: 100017
Name: Handle Concurrency
---

# Handle Concurrency

A concurrency conflict occurs when one user displays an entity's data in order to edit it, and then another user updates the same entity's data before the first user's change is written to the database. 

## Pessimistic Concurrency

Pessimistic concurrency control is when a record is locked at the time the user begins his or her edit process.  

 - In this concurrency mode, the record remains locked for the duration of the edit.  
 - The primary advantage is that no other user is able to get a lock on the record for updating, and also inform any requesting user that they cannot update the record because it is in use.

## Optimistic Concurrency

The alternative to pessimistic concurrency is optimistic concurrency. Optimistic concurrency means allowing concurrency conflicts to happen, and then reacting appropriately if they do.

 - The optimistic concurrency control approach doesn't actually lock anything, instead, it remembers when a row is retrieved from the database. 
 - When user want to update the row, the row will be updated to the database only if the row still looks like when it was rertrieved. 
 - It doesn't prevent a possible conflict, but it can detect it before any damage is done and fail safely. 

## Default Concurrency in EF

By default, Entity Framework supports optimistic concurrency. 

 - EF saves an entity data to the database, assuming that the same data has not been changed since the entity was loaded. 
 - If it finds that the data has changed, then an exception is thrown and you must resolve the conflict before attempting to save it again.

## Add Optimistic Concurrency

In order to check concurrency for the `Author` entity, the Authors table must have a rowversion column. So, add a tracking property named `RowVersion` to the `Author` class.

```csharp
public class Author
{
    public int AuthorId { get; set; }

    [StringLength(50)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [StringLength(50)]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [NotMapped]
    [Display(Name = "Full Name")]
    public string FullName
    {
        get
        {
            return FirstName + " " + LastName;
        }
    }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime BirthDate { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }

    public virtual ICollection<Book> Books { get; set; }
}
```

The `Timestamp` attribute specifies that this column will be included in the `Where` clause of `Update` and `Delete` commands sent to the database. 

If you prefer to use the fluent API, you can use the `IsConcurrencyToken` method to specify the tracking property, as shown below.

```csharp
modelBuilder.Entity<Author>()
    .Property(p => p.RowVersion).IsConcurrencyToken();
```

The database has been changed, so we need to do another migration. In the **Package Manager Console**, run the following commands.

```csharp
Add-Migration RowVersion
Update-Database
``` 

Replace the existing code for the `HttpPost` `Edit` method with the following code.

```csharp
[HttpPost, ActionName("Edit")]
[ValidateAntiForgeryToken]
public ActionResult EditPost(int? id, byte[] rowVersion)
{
    string[] fieldsToBind = new string[] { "FirstName", "LastName", "BirthDate" };

    if (id == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }

    var authorToUpdate =  db.Authors.Find(id);
    if (authorToUpdate == null)
    {
        Author deletedAuthor = new Author();
        TryUpdateModel(deletedAuthor, fieldsToBind);
        ModelState.AddModelError(string.Empty,
            "Unable to save changes. The department was deleted by another user.");

        return View(deletedAuthor);
    }

    if (TryUpdateModel(authorToUpdate, fieldsToBind))
    {
        try
        {
            db.Entry(authorToUpdate).OriginalValues["RowVersion"] = rowVersion;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        catch (DbUpdateConcurrencyException ex)
        {
            var entry = ex.Entries.Single();
            var clientValues = (Author)entry.Entity;
            var databaseEntry = entry.GetDatabaseValues();
            if (databaseEntry == null)
            {
                ModelState.AddModelError(string.Empty,
                    "Unable to save changes. The department was deleted by another user.");
            }
            else
            {
                var databaseValues = (Author)databaseEntry.ToObject();

                if (databaseValues.FirstName != clientValues.FirstName)
                    ModelState.AddModelError("FirstName", "Current value: " + databaseValues.FirstName);

                if (databaseValues.LastName != clientValues.LastName)
                    ModelState.AddModelError("LastName", "Current value: " + String.Format("{0:c}", databaseValues.LastName));

                if (databaseValues.BirthDate != clientValues.BirthDate)
                    ModelState.AddModelError("BirthDate", "Current value: " + String.Format("{0:d}", databaseValues.BirthDate));

                ModelState.AddModelError(string.Empty, "The record you attempted to edit "
                    + "was modified by another user after you got the original value. The "
                    + "edit operation was canceled and the current values in the database "
                    + "have been displayed. If you still want to edit this record, click "
                    + "the Save button again. Otherwise click the Back to List hyperlink.");
                authorToUpdate.RowVersion = databaseValues.RowVersion;
            }
        }
        catch (RetryLimitExceededException /* dex */)
        {
            //Log the error (uncomment dex variable name and add a line here to write a log.)
            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
        }
    }

    return View(authorToUpdate);
}
```

 - The above code also sets the `RowVersion` value of the `Author` object to the new value retrieved from the database. 
 - The new `RowVersion` value will be stored in the hidden field when the Edit page is redisplayed, and the next time the user clicks `Save`, only concurrency errors that happen since the redisplay of the Edit page will be caught.

In ***Views\Author\Edit.cshtml***, add a hidden field to save the `RowVersion` property value, immediately following the hidden field for the `AuthorId` property.

```csharp
<h4>Author</h4>
<hr />
@Html.ValidationSummary(true, "", new { @class = "text-danger" })
@Html.HiddenFor(model => model.AuthorId)
@Html.HiddenFor(model => model.RowVersion)
```

Let's run your application and click Authors tab, open the same author for editing in two different tabs. 

 - The two tabs display the same information, so let's change a **Birth Date** field in the first browser tab and click `Save`.
 - The browser shows the Index page with the changed value.
 - Now change a **Birth Date** field in the second browser tab with different value and click Save. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/mvc-with-entity-framework-6/images/handle-concurrency-1.png">

You can see an error message, if you click `Save` again, the value you entered in the second browser tab is saved along with the original value of the data you changed in the first browser. You see the saved values when the Index page appears.