---
PermaID: 100011
Name: Code Refactoring
---

# Code Refactoring

Refactoring is the process of modifying code in order to make it easier to maintain, understand, and extend, but without changing its behavior.

 - Refactoring includes operations such as intelligent renaming of variables, extracting one or more lines of code into a new method, changing the order of method parameters, etc.
 - In Visual Studio 2019, Microsoft made a lot of improvements and it provides more suggestions for your code refactoring.
 - Refactoring is now enhanced by IntelliCode which spots repetition quickly and suggests other places in your code where you might want to apply that same change.

## Refactoring to Convert for loop to foreach

In some cases, you might want to convert a `for` loop to a `foreach` statement to avoid the local loop variable inside the loop or to simplify your code and reduce the likelihood of logic errors in the initializer, condition, and iterator sections.

Let's consider the following simple example of `for` loop which we can easily convert to `foreach` statement using code refactoring.

```csharp
using System;
using System.Collections.Generic;
using System.IO;

namespace VisualStudioTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();

            customers.Add(new Customer { Id = 1, Name = "John" });
            customers.Add(new Customer { Id = 2, Name = "Mark" });
            customers.Add(new Customer { Id = 3, Name = "Stella" });

            for (int i = 0; i < customers.Count; i++)
            {
                int id = customers[i].Id;
                string name = customers[i].Name;

                Console.WriteLine("{0}, {1}", id, name);
            }
        }

        class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
```

Now you can convert the `for` loop by placing your mouse cursor in the `for` keyword and click the screwdriver icon in the margin of the code file.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/code-refactoring-1.png">

You can select the **Convert to 'foreach'** option if you want to change the code, but if you want to see the changes before, select **Preview changes** to open the Preview Changes dialog. So let's click on the **Preview changes**.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/code-refactoring-2.png">

Click the **Apply** button and you will see that `for` loop is converted to `foreach` statement.

```csharp
foreach (Customer v in customers)
{
    int id = v.Id;
    string name = v.Name;

    Console.WriteLine("{0}, {1}", id, name);
}
```


## Refactoring to Convert for loop to foreach

In some cases, you might want to convert a `foreach` statement to a `for` loop to use the local loop variable inside the loop for more than just accessing the item or you are iterating through a multi-dimensional array and you want more control over the array elements.

Let's consider the following example.

```csharp
foreach (Customer customer in customers)
{
    int id = customer.Id;
    string name = customer.Name;

    Console.WriteLine("{0}, {1}", id, name);
}
```

Similarly, you can convert the `foreach` statement by placing your mouse cursor in the `for` keyword and click the screwdriver icon.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/visual-studio/images/code-refactoring-3.png">

Click the **Convert to 'for'** option and you will see that the `forearch` statement is converted to the following `for` loop.

```csharp
for (int i = 0; i < customers.Count; i++)
{
    Customer customer = customers[i];
    int id = customer.Id;
    string name = customer.Name;

    Console.WriteLine("{0}, {1}", id, name);
}
```  
