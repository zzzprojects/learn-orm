---
PermaID: 100006
Name: User Input
---

#  User Input

The simplest way to get user input is by using the `ReadLine()` method of the `Console` class. It receives the input as a string, therefore you need to convert it. You can also use `Read()` and `ReadKey()` methods to get user input.

## ReadLine()

It reads the next line of input from the standard input stream and returns the same string.

```csharp
Console.WriteLine("Enter some text...");
var str = Console.ReadLine();
Console.WriteLine("You entered '{0}'", str);
```
Let's run the above code and you will see the following code.

```csharp
Enter some text...
Hello, this is a C# Tutorial.
You entered 'Hello, this is a C# Tutorial.'
```

## Read()

It reads the next character from the standard input stream and returns the ASCII value of the character. it takes a whole line but only returns the ASCII value of the first character.

```csharp
Console.WriteLine("Enter some text...");
var str = Console.Read();
Console.WriteLine("ASCII Value = {0}", str);
```
Let's run the above code and you will see the following code.

```csharp
Enter some text...
I am learning C#.
ASCII Value = 73
```

It will print the ASCII value of letter `I` which is 73.

## ReadKey()

It obtains the next key pressed by the user, it is usually used to hold the screen until the user press a key. 

```csharp
Console.WriteLine("Press any key to continue...");
var key = Console.ReadKey();
Console.WriteLine("\nYou pressed {0} key.", key.Key);
```

Let's run the above code and you will see the following code.

```csharp
Press any key to continue...
c
You pressed C key.
```


## Reading Numeric Values

In C#, reading a character or string is very simple but reading numeric values is slightly tricky. The `ReadLine()` method receives the input as a string, and it needs to be converted into an integer or floating-point type using the methods of `Convert` class.

```csharp
Console.WriteLine("Enter an integer...");
string userInputInt = Console.ReadLine();

// Converts to integer type
int intVal = Convert.ToInt32(userInputInt);
Console.WriteLine("You entered {0}", intVal);

Console.WriteLine("Enter a real/double value...");
string userInputDouble = Console.ReadLine();

// Converts to double type
double doubleVal = Convert.ToDouble(userInputDouble);
Console.WriteLine("You entered {0}", doubleVal);
```

Let's run the above code and you will see the following code.

```csharp
Enter an integer...
98
You entered 98
Enter a real/double value...
34.5
You entered 34.5
```

All the examples related to the user input are available in the `UserInput.cs` file of the source code. Download the source code and try out all the examples for better understanding.
