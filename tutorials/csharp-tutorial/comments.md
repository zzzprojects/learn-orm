---
PermaID: 100021
Name: Comments
---

# Comments

In programming languages, comments are used to understand a piece of code and what it will do when it is executed. 

 - Comments are written in a human-readable language and are completely ignored by the compiler.
 - They can be used to document what the program does and what specific blocks or lines of code do. 
 - The compiler ignores comments, so you can include them anywhere in a program without affecting your code.

In C#, there are 3 types of comments.

 - [Single Line Comment](#single-line-comment)
 - [Multiple Line Comment](#single-line-comment)
 - [XML Documentation Comment](#xml-documentation-comment)

## Single Line Comment

The single line or one line comment is the most basic type of comment in C#. It is started with two forward slashes (`//`)  and lasts until the end of the line.

 - It tells the compiler that this line is a comment so ignore it when code is executed.
 - You can also use it to prevent the execution of a particular line when testing alternative code.

Let's consider the following example.

```csharp
// Initialize the counter
int counter = 0;

// Execute the loop body while the loop condition holds
while (counter <= 5)
{
    // Print the counter value
    Console.WriteLine("Number: " + counter);

    // Increment the counter
    counter++;
}
```

Here you can see that we have added a single line comment for each statement which explains what it does. You can also use a single-line comment at the end of a line of code as shown below.

```csharp
Console.WriteLine("Number: " + counter);   // Print the counter value
counter++;                                 // Increment the counter
```

## Multiple Line Comment

The multiline or multiple line comments are used to comment more than one line. You can start multiline comment by specifying `/*` and end with `*/`, so everything in between these character sequences is treated as comments.

 - It makes more sense to use the multi-line comment instead of using `//` at the start of each line.
 - It is also used to comment on an entire block of code statements.

```csharp
/* This a parameterized constructor which takes the following parameters
    - id
    - name
    - address
   It will initialize the employee object with values passed as parameters. 
*/
public Employee(int id, string name, string address)
{
    this.Id = id;
    this.Name = name;
    this.Address = address;
}
```

```csharp
/*
for (int i = 0; i <= 10; i++)
{
    if (i > 3 && i < 8)
        continue;

    Console.WriteLine("Counter: {0}", i);
}
*/

Console.WriteLine(" Entire code block is commented");
```

## XML Documentation Comment

XML documentation comments are a special kind of comment, added above the definition of any user-defined type or member. 

 - They are special because they can be processed by the compiler to generate an XML documentation file at compile time.
 - XML documentation comments, like all other comments, are ignored by the compiler.

```csharp
/// <summary> 
/// Method to print all the information on console window. 
/// </summary> 
public void Print()
{
    Console.WriteLine("Id: {0}, Name: {1}, Address: {2}", this.Id, this.Name, this.Address);
}
```

For more information, see the official page for [Documenting your code with XML comments](https://docs.microsoft.com/en-us/dotnet/csharp/codedoc)

All the examples related to the comments are available in the `Comments.cs` file of the source code. Download the source code and try out all the examples for better understandings.
