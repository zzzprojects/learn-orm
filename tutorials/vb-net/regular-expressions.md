---
PermaID: 100046
Name: Regular Expressions
---

# Regular Expressions

Regular expressions are powerful tools for text processing and allow searching matches by a pattern. Regular expressions make text processing easier and more accurate, such as, 

 - Extracting some resources from texts
 - Searching for phone numbers
 - Finding email addresses in a text
 - Splitting all the words in a sentence
 - Data validation, etc.

In VB.NET, `Regex` represents the regular expression engine. It can be used to quickly parse large amounts of text to find specific character patterns to extract, edit, replace, or delete text substrings.

Let's have a look into a simple example that creates a `Regex` from a pattern to match a word starting with char "S".

```csharp
Public Sub Example1()
    Dim customers As String = "John, samantha, Andy, Smith, Allen, Mark, Stella, Scarlett"
    Dim pattern As String = "\b[S]\w+"
    Dim expr As Regex = New Regex(pattern)
    Dim matchedCustomers As MatchCollection = expr.Matches(customers)
    Console.WriteLine("The following names of the customers start with ""S""" & vbLf)

    For Each match In matchedCustomers
        Console.WriteLine(match)
    Next
End Sub
```

The `\b[S]\w+` creates a pattern for a word that starts with the letter "S". Let's run the above code and you will see the following output.

```csharp
The following names of the customers start with "S"

Smith
Stella
Scarlett
```

As you can see the pattern only matches the names that start with "S" and ignore the name that start with "s". You can use the `RegexOptions.IgnoreCase` parameter to make sure that `Regex` does not look for uppercase or lowercase.

```csharp
Public Sub Example2()
    Dim customers As String = "John, samantha, Andy, Smith, Allen, Mark, Stella, Scarlett"
    Dim pattern As String = "\b[S]\w+"
    Dim expr As Regex = New Regex(pattern, RegexOptions.IgnoreCase)
    Dim matchedCustomers As MatchCollection = expr.Matches(customers)
    Console.WriteLine("The following names of the customers start with ""S"" or  or ""s""" & vbLf)

    For Each match In matchedCustomers
        Console.WriteLine(match)
    Next
End Sub
```

Let's run the above code and you will see the following output.

```csharp
The following names of the customers start with "S" or  or "s"

samantha
Smith
Stella
Scarlett
```

Let's consider another example, where we want to validate an email Ids.

```csharp
Private Function IsValidEmail(ByVal email As String) As Boolean
    Dim strRegex As String = "\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z"
    Dim re As Regex = New Regex(strRegex, RegexOptions.IgnoreCase)

    If re.IsMatch(email) Then
        Return (True)
    Else
        Return (False)
    End If
End Function
```

You can call the `IsValidEmail()` bypassing the user email as a parameter, if it is a valid email it will return `true`, otherwise, `false`.

```csharp
Public Sub EmailValidation()
    Dim emails As String() =
    {
        "parth@gmail.com",
        "john@gmail.com",
        "stella@gmail",
        "andy.123@gmail.com",
        "mark.gmail.com",
        "@gmail.com"
    }

    For Each email As String In emails

        If IsValidEmail(email) Then
            Console.WriteLine("{0, 20}: is a valid E-mail address.", email)
        Else
            Console.WriteLine("{0, 20}: is not a valid E-mail address.", email)
        End If
    Next
End Sub
```

Let's run the above code and you will see the following output.

```csharp
     parth@gmail.com: is a valid E-mail address.
      john@gmail.com: is a valid E-mail address.
        stella@gmail: is not a valid E-mail address.
  andy.123@gmail.com: is a valid E-mail address.
      mark.gmail.com: is not a valid E-mail address.
          @gmail.com: is not a valid E-mail address.
```
