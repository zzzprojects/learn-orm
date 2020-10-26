---
PermaID: 100032
Name: Regular Expressions
---

# Regular Expressions

Regular expressions are powerful tools for text processing and allow searching matches by a pattern. Regular expressions make text processing easier and more accurate, such as, 

 - Extracting some resources from texts
 - Searching for phone numbers
 - Finding email addresses in a text
 - Splitting all the words in a sentence
 - Data validation, etc.

In C#, `Regex` represents the regular expression engine. It can be used to quickly parse large amounts of text to find specific character patterns to extract, edit, replace, or delete text substrings.

Let's have a look into a simple example that creates a `Regex` from a pattern to match a word starting with char "S".

```csharp
string customers = "John, samantha, Andy, Smith, Allen, Mark, Stella, Scarlett";

// Create a pattern for a word that starts with letter "S"  
string pattern = @"\b[S]\w+";

Regex expr = new Regex(pattern);

MatchCollection matchedCustomers = expr.Matches(customers);

Console.WriteLine("The following names of the customers start with \"S\"\n");

foreach (var match in matchedCustomers)
{
    Console.WriteLine(match);
}
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
string customers = "John, samantha, Andy, Smith, Allen, Mark, Stella, Scarlett";

// Create a pattern for a word that starts with letter "S"  
string pattern = @"\b[S]\w+";

Regex expr = new Regex(pattern, RegexOptions.IgnoreCase);

MatchCollection matchedCustomers = expr.Matches(customers);

Console.WriteLine("The following names of the customers start with \"S\" or  or \"s\"\n");

foreach (var match in matchedCustomers)
{
    Console.WriteLine(match);
}
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
private static bool IsValidEmail(string email)
{
    // This Pattern is use to verify the email 
    string strRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

    Regex re = new Regex(strRegex, RegexOptions.IgnoreCase);

    if (re.IsMatch(email))
        return (true);
    else
        return (false);
}
```

You can call the `IsValidEmail()` bypassing the user email as a parameter, if it is a valid email it will return `true`, otherwise, `false`.

```csharp
string[] emails =
{
    "parth@gmail.com",
    "john@gmail.com",
    "stella@gmail",
    "andy.123@gmail.com",
    "mark.gmail.com",
    "@gmail.com"
};

foreach (string email in emails)
{
    if (IsValidEmail(email))
       Console.WriteLine("{0, 20}: is a valid E-mail address.", email);
    else
       Console.WriteLine("{0, 20}: is not a valid E-mail address.", email);
}
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

For more information about Regular Expressions, visit [https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex](https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex)

All the examples related to the regular expressions are available in the `RegularExpressionsTests.cs` file of the source code. Download the source code and try out all the examples for better understanding.
