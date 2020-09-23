---
PermaID: 100003
Name: Finding Elements
---

# Finding Elements

One of the most fundamental technique to learn when using `WebDriver` is how to find elements on the page. Selenium defines two methods for identifying web elements.

 - **FindElement:** Used to uniquely identify a web element within the web page.
 - **FindElements:** Used to identify a list of web elements within the web page.

The `FindElement` method returns an object of type `WebElement`. `WebDriver` offers a number of built-in selector types.

## Element Finding Strategies

There are eight different built-in element location strategies in WebDriver.

| Locator     | Description                                                                                        |
|:------------|:---------------------------------------------------------------------------------------------------|
|Id           |Locates elements whose ID attribute matches the search value                                        |
|Name         |Locates elements whose NAME attribute matches the search value                                      |
|LinkText     |Locates anchor elements whose visible text matches the search value                                 |
|ClassName    |Locates elements whose class name contains the search value (compound class names are not permitted)|
|CssSelector  |Locates elements matching a CSS selector                                                            |
|XPath        |Locates elements matching an XPath expression                                                       |
|TagName      |Locates elements whose tag name matches the search value                                            |
|PartialLinkText| Locates anchor elements whose visible text contains the search value. If multiple elements are matching, only the first one will be selected.|

### By Id

The `id` is uniquely defined for each element and is the most common way to find elements using the `id` attribute. For example, let's take www.facebook.com for automating and find the elements. When you navigate through the **Email address or phone number** box and inspect the element, you will see various web elements as shown below.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/selenium-webdriver/images/finding-elements-1.png">

You can see an `id` whose value is "email". Now you can use the following code to find the **Email address or phone number** box using the `id` locator.

```csharp
[TestMethod]
public void FindEmailFieldByIdOnFacebookLoginPage()
{
    IWebDriver driver = new ChromeDriver();
    driver.Navigate().GoToUrl("https://www.facebook.com/");
    var emailField = driver.FindElement(By.Id("email"));

    Assert.IsNotNull(emailField);
}
```

### By Name

To find an element by name is similar to find an element by id except the driver will locate an element by `name` attribute instead of `id`. Let's take the same www.facebook.com webpage. The **Email address or phone number** box also has a name locator whose value is "email" as shown below.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/selenium-webdriver/images/finding-elements-2.png">

You can use the following code to find the **Email address or phone number** box using the `Name` locator.

```csharp
[TestMethod]
public void FindEmailFieldByNameOnFacebookLoginPage()
{
    IWebDriver driver = new ChromeDriver();
    driver.Navigate().GoToUrl("https://www.facebook.com/");
    var emailField = driver.FindElement(By.Name("email"));

    Assert.IsNotNull(emailField);
}
```

### By LinkText

The `LinkText` is helpful to find links on a webpage. It is the most efficient way of finding web elements containing links. Let's find a **Create a Page** link using the link text whose value is "Create a Page" as shown below.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/selenium-webdriver/images/finding-elements-3.png">

You can use the following code to find the **Create a Page** link using `LinkText` locator.

```csharp
[TestMethod]
public void FindCreatePageLinkByLinkTextOnFacebookLoginPage()
{
    IWebDriver driver = new ChromeDriver();
    driver.Navigate().GoToUrl("https://www.facebook.com/");
    var createPageLink = driver.FindElement(By.LinkText("Create a Page"));

    Assert.IsNotNull(createPageLink);
}
```

### By ClassName

The `ClassName` is used when you want to locate an element by CSS class name. With this strategy, the first element with the matching class name attribute will be returned. Let's find a **Create a Page** link using the class name whose value in "_8esh" as shown below.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/selenium-webdriver/images/finding-elements-4.png">

You can use the following code to find the **Create a Page** link using the `ClassName` locator.

```csharp
[TestMethod]
public void FindCreatePageLinkByClassNameOnFacebookLoginPage()
{
    IWebDriver driver = new ChromeDriver();
    driver.Navigate().GoToUrl("https://www.facebook.com/");
    var createPageLink = driver.FindElement(By.ClassName("_8esh"));

    Assert.IsNotNull(createPageLink);
}
```

### By CSS Selector

The `CssSelector` is used to provide style rules for web pages and also can be used to identify one or more web elements. Let's find a **Password** box using the CSS selector `id` whose value is "pass" as shown below.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/selenium-webdriver/images/finding-elements-5.png">

You can use the following code to find the **Password** box using the `CssSelector` locator.

```csharp
[TestMethod]
public void FindPasswordFieldByCssSelectorOnFacebookLoginPage()
{
    IWebDriver driver = new ChromeDriver();
    driver.Navigate().GoToUrl("https://www.facebook.com/");
    var passwordField = driver.FindElement(By.CssSelector("#pass"));

    Assert.IsNotNull(passwordField);
}
```

### By XPath

In Selenium, if the elements are not found by the general locators like id, class, name, etc. then XPath is used to find an element on the web page.

 - It is a technique to navigate through the HTML structure of a page. 
 - It enables you to navigate through the XML structure of any document and can be used on both HTML and XML documents.

Let's try to locate the same **Password** box on the Facebook page with the help of XPath. We can see that it contains an `id` locator.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/selenium-webdriver/images/finding-elements-5.png">

The input tag starts with `//input` which implies a tag name and also use of the `id` attribute with the value 'pass' in single quotes. This will give the XPath expression shown below.

```csharp
//input[@id='pass']
```

You can use the following code to find the **Password** box using the `XPath` locator.

```csharp
[TestMethod]
public void FindPasswordFieldByXPathOnFacebookLoginPage()
{
    IWebDriver driver = new ChromeDriver();
    driver.Navigate().GoToUrl("https://www.facebook.com/");
    var passwordField = driver.FindElement(By.XPath("//input[@id='pass']"));

    Assert.IsNotNull(passwordField);
}
```

### By TagName

The `TagName` is used when you want to locate an element by tag name. When the `FindElement` method is used, then the first element with the given tag name will be returned. Let's use the `FindElements` method which will return all the `input` elements on the web page. 

```csharp
[TestMethod]
public void FindAllInputElementsByTagNameOnFacebookLoginPage()
{
    IWebDriver driver = new ChromeDriver();
    driver.Navigate().GoToUrl("https://www.facebook.com/");
    var inputElements = driver.FindElements(By.TagName("input"));

    Assert.AreEqual(inputElements.Count, 5);
}
```
