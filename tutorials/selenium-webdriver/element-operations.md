---
PermaID: 100007
Name: Element Operations
---

# Element Operations

Element operations or element manipulation simply means that once you find an element then you can manipulate that element as you want.

 - Manipulation means to do operations on a page such as a click on a button, select a radio button, select a dropdown box item, write a text into a text box, etc. 
 - To do these operations first we have to find that web element, then acts on it. 

## WebElement Operations/Actions

All the operations used to interact with a web page are performed through the `IWebElement` Interface.

 - [TagName](#tagname)
 - Text
 - Enabled
 - Selected
 - Location
 - Size
 - Displayed
 - Clear()
 - Click()
 - GetAttribute(string attributeName)
 - GetCssValue(string propertyName)
 - GetProperty(string propertyName)
 - SendKeys(string text)
 - Submit()

### TagName

The `TagName` property returns the tag name of the element, not the value of the name attribute. For example, it will return `input` for an element specified by the HTML markup <input name="foo" />.

```csharp
IWebElement element = driver.FindElement(By.Id("SubmitBtn"));
String tagName = element.TagName;
```

You can also get the tag name like this. 

```csharp
String tagName = driver.FindElement(By.Id("SubmitBtn")).TagName;
```

### Text

The `Text` property returns the innerText of this element, without any leading or trailing whitespace, and with other whitespace collapsed. It accepts nothing as a parameter but returns a String value.

```csharp
IWebDriver driver = new ChromeDriver();
driver.Navigate().GoToUrl("https://www.facebook.com/");
IWebElement element = driver.FindElement(By.Xpath("//*[@id='reg_pages_msg']/a"));
string linkText = element.Text;
```

### Enabled

The `Enabled` property determines whether the element currently is Enabled or not? It will generally return true for everything except explicitly disabled input elements.

```csharp
IWebDriver driver = new ChromeDriver();
driver.Navigate().GoToUrl("https://www.facebook.com/");
IWebElement element = driver.FindElement(By.Id("email"));
bool status = element.Enabled;

// Check that if the Text field is enabled, if yes enter value
if(status){
    element.SendKeys("email id");
}
```

### Selected

The `Selected` property determines whether the element is selected or not. This operation only applies to input elements such as Checkboxes, Select Options, and Radio Buttons. It returns True if the element is currently selected or checked, false otherwise. 

```csharp
IWebElement element = driver.FindElement(By.Id("rememberme"));
bool status = element.Selected;
```

### Location

The `Location` property returns a `System.Drawing.Point` object containing the coordinates of the upper-left corner of this element relative to the upper-left corner of the page. It accepts nothing as a parameter but returns the Point object.

```csharp
IWebElement element = driver.FindElement(By.Id("SubmitBtn"));
Point point = element.Location;
Console.WriteLine("X cordinate : " + point.X + "Y cordinate: " + point.Y);
```

### Size

The `Size` property returns the width and height of the rendered element. It accepts nothing as a parameter but returns the Dimension object.

```csharp
IWebElement element = driver.FindElement(By.Id("SubmitBtn"));
Dimension dimensions = element.Size();
Console.WriteLine(“Height :” + dimensions.Height + ”Width : "+ dimensions.Width);
```

### Displayed

The `Displayed` property determines if an element is currently being displayed or not. It avoids the problem of having to parse an element's "style" attribute to determine the visibility of an element. It accepts nothing as a parameter but returns a boolean value(true/false).

```csharp
IWebElement element = driver.FindElement(By.Id("email"));
bool status = element.Displayed;
```

### Clear()

The `Clear()` method clears the content of the element. If the element is a text entry element, the `Clear` method will clear the value. It does not affect other elements. Text entry elements are defined as elements with `input` or `textarea` tags.

```csharp

IWebElement element = driver.findElement(By.Id("email"));
element.Clear();
```

### Click()

The `Click()` method clicked the element. If the click causes a new page to load, the `Click` method will attempt to block until the page has loaded. 

 - After calling the `Click` method, you should discard all references to this element unless you know that the element and the page will still be present. 
 - Otherwise, any further operations performed on this element will have undefined behavior.
 - If the element is not clickable, then this operation is ignored.

```csharp
IWebDriver driver = new ChromeDriver();
driver.Navigate().GoToUrl("https://www.facebook.com/");
IWebElement element = driver.FindElement(By.LinkText("Create a Page"));
element.Click();
```

### GetAttribute(string attributeName)

The `GetAttribute()` returns the value of the specified attribute for this element. The attributes are Ids, Name, Class, etc.

```csharp
IWebDriver driver = new ChromeDriver();
driver.Navigate().GoToUrl("https://www.facebook.com/");
IWebElement element = driver.FindElement(By.LinkText("Create a Page"));
String attValue = element.GetAttribute("id");
```

### GetCssValue(string propertyName)

The `GetCssValue()` method returns the CSS property value of the given element. This accepts a string as a parameter which is the property name.

 - The value returned by the `GetCssValue` method is likely to be unpredictable in a cross-browser environment. 
 - The color values should be returned as hex strings. For example, a "background-color" property set as "green" in the HTML source, will return "#008000" for its value.

```csharp
IWebDriver driver = new ChromeDriver();
driver.Navigate().GoToUrl("https://www.facebook.com/");
IWebElement element = driver.FindElement(By.LinkText("Create a Page"));
String fontSize = element.GetCssValue("font-size");
```

### GetProperty(string propertyName)

The `GetProperty()` method returns the value of a JavaScript property of the given element.

```csharp
var element = driver.FindElement(By.Id("email"));
string prop = element.GetProperty("value");
```

### SendKeys(string text)

The `SendKeys` method simulates typing text into the element to set its value. The text to be typed may include special characters like arrow keys, backspaces, function keys, etc. This method works fine with text entry elements like `input` and `textarea` elements.

```csharp
IWebDriver driver = new ChromeDriver();
driver.Navigate().GoToUrl("https://www.facebook.com/");
var element = driver.FindElement(By.Id("email"));
element.SendKeys("abc@gmail.com");
```
### Submit()

The `Submit()` method works well/better than the `Click()` method if the current element is a form or an element within a form. If this causes the current page to change, then this method will wait until the new page is loaded.

```csharp
IWebElement element = driver.FindElement(By.Id("SubmitBtn"));
element.Submit();
```
