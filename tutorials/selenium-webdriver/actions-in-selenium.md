---
PermaID: 100009
Name: Actions in Selenium
---

# Actions in Selenium

## What is Actions Class?

The `Actions` class is a collection of individual actions that you want to perform. It is an ability provided by Selenium for handling keyboard and mouse events. 

 - In Selenium WebDriver, it contains operations such as drag and drop, clicking on multiple elements with the control key, etc. 
 - It mainly consists of Actions that are needed while performing these operations.

The `Actions` class is the user-facing API for emulating complex action events. You can directly use this class rather than using the input devices, i.e. keyboard and mouse.

## Why we need Actions Class?

You can do most of the user interactions like clicking on a button, entering text in textbox using the WebDriver Element Commands such as `WebElement.Click()` and WebElement.SendKeys() is used to click on buttons and enter text in text boxes. Submitting a form can be done using the WebElement.Submit() command. 

 - However, there are complex interactions like Drag-n-Drop and Double-click which cannot be done by simple WebElement commands. 
 - To handle those types of advanced actions we have the `Actions` class in Selenium.

## Methods of Action Class

`Actions` class is useful, especially for mouse and keyboard actions. To perform such actions, Selenium provides different methods for mouse and keyboard actions.

### Mouse Actions

The most popular actions related to mouse events are as follows. 

| Method                       | Description                                                    |
|:-----------------------------|:---------------------------------------------------------------|
|Click()                       | Clicks at the current mouse location.                          |
|DoubleClick()                 | Performs double click on the element                           |
|ClickAndHold()                | Performs long click on the mouse without releasing it          |
|DragAndDrop()                 | Drags the element from one point and drops to another          |
|MoveToElement()               | Shifts the mouse pointer to the center of the element          |
|ContextClick()                | Performs right-click on the mouse                              |
|Release()                     | Releases the left mouse button at the current mouse location.  |

### Keyboard Actions:

The most popular actions related to keyboard events are as follows.

| Method                       | Description                                                    |
|:-----------------------------|:---------------------------------------------------------------|
|SendKeys()                    | Sends a series of keys to the element                          |
|KeyUp()                       | Performs key release                                           |
|KeyDown()                     | Performs keypress without release                              |


## Actions

The following are the most used actions.

### Click

The `Click()` action method clicks at the current mouse location. It is very useful when combined with `MoveToElement()` or `MoveByOffset()` methods.

```csharp
IWebDriver driver = new ChromeDriver();
Actions action = new Actions(driver);
driver.Navigate().GoToUrl("https://www.facebook.com/");
var element = driver.FindElement(By.XPath("//*[@id='reg_pages_msg']/a"));
action.MoveToElement(element).Click();
```
### ClickAndHold

The `ClickAndHold()` action method clicks and holds the mouse button down on the specified element.

```csharp
IWebDriver driver = new ChromeDriver();
Actions action = new Actions(driver);
driver.Navigate().GoToUrl("https://jqueryui.com/resizable/");
var element = driver.FindElement(By.XPath("//*[@class='ui-resizable-handle ui-resizable-se ui-icon ui-icon-gripsmall-diagonal-se']"))
action.ClickAndHold(element).MoveByOffset(200, 200).Release().Perform();
```

### ContextClick

The `ContextClick()` action method right-clicks the mouse on the specified element.

```csharp
// Right click the button to launch right click menu options
Actions action = new Actions(driver);
var element = driver.findElement(By.cssSelector(".context-menu-one"));
action.ContextClick(element).Perform();
```

### DoubleClick

The `DoubleClick()` action method double-clicks the mouse on the specified element.

```csharp
Actions action = new Actions(driver);
var element = driver.FindElement(By.xpath("//button[text()='Double-Click Me To See Alert']"));
action.DoubleClick(element).Perform();
```

### DragAndDrop

The `DragAndDrop()` action method performs a drag-and-drop operation from one element to another.

```csharp
IWebDriver driver = new ChromeDriver();
Actions action = new Actions(driver);
var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));

var source = driver.FindElement(By.Id("draggable"));
var target = driver.FindElement(By.Id("droppable"));

action.DragAndDrop(source, target).Perform(); 
```

### KeyDown

The `KeyDown()` action method sends a modifier key down message to the specified element in the browser. 

```csharp
Actions action = new Actions(driver);
action.KeyDown(Keys.Control).SendKeys(Keys.Subtract).SendKeys(Keys.Subtract).KeyUp(Keys.Control).Perform(); 
```

In the above example, it will zoom out the web page using key down **Ctrl** key and then key up again the **Ctrl** key.

### KeyUp

The `KeyUp()` action method sends a modifier key up message to the specified element in the browser. 

```csharp
Actions action = new Actions(driver);
action.KeyDown(Keys.Control).SendKeys(Keys.Subtract).SendKeys(Keys.Subtract).KeyUp(Keys.Control).Perform(); 
```

In the above example, it will zoom out the web page using key down **Ctrl** key and then key up again the **Ctrl** key.

### MoveByOffset

The `MoveByOffset()` action method moves the mouse to the specified offset of the last known mouse coordinates. 

```csharp
IWebDriver driver = new ChromeDriver();
Actions action = new Actions(driver);```
driver.Navigate().GoToUrl("https://jqueryui.com/resizable/");
var element = driver.FindElement(By.XPath("//*[@class='ui-resizable-handle ui-resizable-se ui-icon ui-icon-gripsmall-diagonal-se']"))
action.ClickAndHold(element).MoveByOffset(200, 200).Perform();
```

### MoveToElement

The `MoveToElement()` action method moves the mouse to the specified element.

```csharp
IWebDriver driver = new ChromeDriver();
Actions action = new Actions(driver);
driver.Navigate().GoToUrl("https://www.facebook.com/");
var element = driver.FindElement(By.XPath("//*[@id='reg_pages_msg']/a"));
action.MoveToElement(element).Click();
```

### Release

The `Release()` action method Releases the mouse button on the specified element.

```csharp
IWebDriver driver = new ChromeDriver();
Actions action = new Actions(driver);
driver.Navigate().GoToUrl("https://jqueryui.com/resizable/");
var element = driver.FindElement(By.XPath("//*[@class='ui-resizable-handle ui-resizable-se ui-icon ui-icon-gripsmall-diagonal-se']"))
action.ClickAndHold(element).MoveByOffset(200, 200).Release().Perform();
```