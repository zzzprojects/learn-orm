---
PermaID: 100006
Name: Navigation
---

# Navigation

Navigation with selenium web driver is pretty straight forward, it provides some basic Browser Navigation Commands that allows the browser to move backward or forward in the browser's history. It provides basically four methods that allow you to navigate with selenium.

| Method              | Description                                                                         |
|:-----------------   |:------------------------------------------------------------------------------------|
| Back()              | Move back a single item in the browser's history.                                   |
| Forward()           | Move a single item forward in the browser's history.                                |
| GoToUrl(string url) | Load a new web page in the current browser window.                                  |
| GoToUrl(Uri url)    | Overloaded version of GoToUrl(string url) that makes it easy to pass in a `Uri`.    |
| Refresh()           | Refresh the current page.                                                           |

You can access the navigation methods provided by `WebDriver` by typing `webDriver.Navigate()'. 

## Back

In WebDriver, the `Back()` navigation method enables the web browser to click on the back button in the existing browser window. 

 - It does the same operation as clicking on the **Back** button of any browser. 
 - It neither accepts anything nor returns anything.

The following code takes you back by one page on the browser's history.

```csharp
webDriver.Navigate().Back();
```

## Forward

In WebDriver, the `Forward()` navigation method enables the web browser to click on the forward button in the existing browser window. 

 - It does the same operation as clicking on the **Forward** button of any browser.
 - It neither accepts anything nor returns anything.

The following code takes you forward by one page on the browser's history.

```csharp
webDriver.Navigate().Forward();
```

## Refresh

In WebDriver, the `Refresh()` navigation method refresh/reloads the current web page in the existing browser window. 

 - It does the same operation as right-clicking on the web page and select Refresh or pressing the F5 button.
 - It neither accepts anything nor returns anything.

The following code refreshes the current web page.

 ```csharp
webDriver.Navigate().Refresh();
```

## GoToUrl

In WebDriver, the `GoToUrl` navigation method loads a new web page in the existing browser window. It accepts a string as a parameter and returns void.

The following code loads the webpage specified as a parameter.

 ```csharp
webDriver.Navigate().GoToUrl("https://www.facebook.com/");
```