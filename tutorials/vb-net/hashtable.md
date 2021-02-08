---
PermaID: 100027
Name: Hashtable
---

# Hashtable

The `Hashtable` represents a collection of key/value pairs organized based on the hash code of the key.

 - The `HashTable` stores a `Key`/`Value` pair type collection of data. 
 - We can retrieve items from `HashTable` to provide the key. 
 - Both key and value are Objects.

The following example shows how to create, initialize and perform various functions to a `Hashtable` and how to print out its keys and values.

```csharp
Public Sub Example1()
    Dim openWith As Hashtable = New Hashtable()
    openWith.Add("txt", "notepad.exe")
    openWith.Add("bmp", "paint.exe")
    openWith.Add("dib", "paint.exe")
    openWith.Add("rtf", "wordpad.exe")

    Try
        openWith.Add("txt", "winword.exe")
    Catch
        Console.WriteLine("An element with Key = ""txt"" already exists.")
    End Try

    Console.WriteLine("For key = ""rtf"", value = {0}.", openWith("rtf"))
    openWith("rtf") = "winword.exe"
    Console.WriteLine("For key = ""rtf"", value = {0}.", openWith("rtf"))
    openWith("doc") = "winword.exe"

    If Not openWith.ContainsKey("ht") Then
        openWith.Add("ht", "hypertrm.exe")
        Console.WriteLine("Value added for key = ""ht"": {0}", openWith("ht"))
    End If

    Console.WriteLine()

    For Each de As DictionaryEntry In openWith
        Console.WriteLine("Key = {0}, Value = {1}", de.Key, de.Value)
    Next

    Dim valueColl As ICollection = openWith.Values
    Console.WriteLine()

    For Each s As String In valueColl
        Console.WriteLine("Value = {0}", s)
    Next

    Dim keyColl As ICollection = openWith.Keys
    Console.WriteLine()

    For Each s As String In keyColl
        Console.WriteLine("Key = {0}", s)
    Next

    Console.WriteLine(vbLf & "Remove(""doc"")")
    openWith.Remove("doc")

    If Not openWith.ContainsKey("doc") Then
        Console.WriteLine("Key ""doc"" is not found.")
    End If
End Sub
```

Let's run the above code and you will see the following output.

```csharp
An element with Key = "txt" already exists.
For key = "rtf", value = wordpad.exe.
For key = "rtf", value = winword.exe.
Value added for key = "ht": hypertrm.exe

Key = ht, Value = hypertrm.exe
Key = txt, Value = notepad.exe
Key = dib, Value = paint.exe
Key = rtf, Value = winword.exe
Key = doc, Value = winword.exe
Key = bmp, Value = paint.exe

Value = hypertrm.exe
Value = notepad.exe
Value = paint.exe
Value = winword.exe
Value = winword.exe
Value = paint.exe

Key = ht
Key = txt
Key = dib
Key = rtf
Key = doc
Key = bmp

Remove("doc")
Key "doc" is not found.
```

Each element is a key/value pair stored in a `DictionaryEntry` object. A key cannot be `null`, but a value can be.

 - The `For Each` returns an object of the type of the elements in the collection. 
 - Since each element of the `Hashtable` is a key/value pair, the element type is not the type of the key or the type of the value. 
 - Instead, the element type is `DictionaryEntry`.
