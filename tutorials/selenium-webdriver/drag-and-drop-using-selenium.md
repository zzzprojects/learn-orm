---
PermaID: 100010
Name: Drag and Drop using Selenium
---

# Drag and Drop using Selenium

In some web applications, you will see a drag and drop functionality where you can drag one element and drop it on a defined area or element. To demonstrate the drag and drop functionality, we will be using the example mentioned [here](https://jqueryui.com/droppable/). 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/selenium-webdriver/images/drag-and-drop-1.png">

It is a simple jQuery UI that allows an element to drag and drop on another element.

To automate drag and drop functionality, you can use the `DragAndDrop()` method of Actions class.

```csharp
public Actions DragAndDrop(IWebElement source, IWebElement target);
```

We need to pass two parameters to the `DragAndDrop` method.

 - **source:** The element on which the drag operation is started.
 - **target:** The element on which the drop is performed.

Let's open the page source and locate the draggable and droppable elements.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/selenium-webdriver/images/drag-and-drop-2.png">

You can see the ids of both elements i.e. draggable and droppable. The following example will drag the web element which has `id='draggable'` and drop over the element with `id='droppable'`.

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

So it will perform the drag and drop action by moving the source element into the target element.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/selenium-webdriver/images/drag-and-drop-3.png">