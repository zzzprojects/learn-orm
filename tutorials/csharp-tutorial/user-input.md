---
PermaID: 100006
Name: User Input
---

#  User Input

The simplest way to get user input is by using the `ReadLine()` method of the `Console` class. It receives the input as a string, therefore you need to convert it. You can also use `Read()` and `ReadKey()` methods to get user input.

## ReadLine()

It reads the next line of input from the standard input stream and returns the same string.

```csharp
var str = Console.ReadLine();
Console.WriteLine("You entered '{0}'", str);
```

## Read()

It reads the next character from the standard input stream and returns the ASCII value of the character. it takes a whole line but only returns the ASCII value of the first character.

```csharp
var str = Console.Read();
Console.WriteLine("Ascii Value = {0}", str);
```

It will print the Key pressed message after you press any key.

## ReadKey()

It obtains the next key pressed by the user, it is usually used to hold the screen until the user press a key. 

```csharp
Console.WriteLine("Press any key to continue...");
Console.ReadKey();
Console.WriteLine("Key pressed.");
```

## Reading Numeric Values

In C#, reading a character or string is very simple but reading numeric values is slightly tricky. The `ReadLine()` method receives the input as a string, and it needs to be converted into an integer or floating-point type using the methods of `Convert` class.

```csharp
string userInputInt = Console.ReadLine();

// Converts to integer type
int intVal = Convert.ToInt32(userInput);
Console.WriteLine("You entered {0}",intVal);

string userInputDouble = Console.ReadLine();

// Converts to double type
double doubleVal = Convert.ToDouble(userInput);
Console.WriteLine("You entered {0}",doubleVal);
```
