---
PermaID: 100008
Name: Implicit and Explicit Wait
---

# Implicit and Explicit Wait

## What is Wait?

In most of the web applications, Ajax and Javascript are used and when a page is loaded by the browser the elements which we want to interact with may load at different time intervals which makes it difficult to identify the element but also if the element is not located it will throw an `ElementNotVisibleException` exception. 

This problem can be resolved with waits and Selenium provides two types of waits.

 - Implicit Wait
 - Explicit Wait

### Implicit Wait

The Implicit Wait tells the Selenium web driver to wait for a certain amount of time when trying to find an element or elements if they are not immediately available before it throws a `NoSuchElementException`.

 - So it's checking the DOM to see if that element is present if it's not present it's going to keep checking for a specific duration of time.
 - The default setting is 0, once we set the time, the web driver will wait for the element for that time before throwing an exception.

In the following example, we have declared an implicit wait with the time frame of 3 seconds. 

```csharp
webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
```

It means that if the element is not located on the web page within that time frame, it will throw an exception.

#### Disadvantages of Implicit Wait

 - If the element is there but it's simply just hidden on the page, the implicit wait will not work and it will fail immediately.
 - The implicit wait applies to all the future commands utilized in your test.
 - So it slows down the testing of your automation script, as the driver has to wait for a specific amount of time. 

#### When to use an implicit wait?

If you use the implicit wait in selenium it applies to the web driver globally and increases the execution time for the entire script. so it is not always advisable.

 - Let's say you have set an implicit wait of 5 sec, and the driver can identify the web element in 2 seconds, as you have applied implicit wait driver will wait for 3 more seconds (till 5 seconds). 
 - The driver will not continue after 2 seconds, it will slow down the automation process.

### Explicit Wait

The Explicit Wait tells the Selenium web driver to wait for certain conditions or maximum time exceeded before throwing the `ElementNotVisibleException` exception. 

 - It is an intelligent kind of wait, but it can be applied only for specified elements. 
 - It gives better options than implicit wait as it waits for dynamically loaded Ajax elements.

In the following example, we are instantiating the `WebDriverWait` class using the `WebDriver` reference, and giving a maximum time frame of 5 seconds.

```csharp
var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
wait.Until(f => f.FindElement(By.XPath("//button[.='Search']")));
```

#### When to use an explicit wait?

You should always use an explicit wait since it is dynamic. 

 - Let's say you have set explicit wait of 5 sec, and the driver can identify the web element in 2 seconds, as we have applied explicit wait driver will not wait for 3 more seconds (till 5 seconds). 
 - The driver will continue after 2 seconds, it will fasten up the automation process.

## Difference between Implicit Wait Vs Explicit Wait

|Implicit Wait                    | Explicit Wait                      |
|:--------------------------------|:-----------------------------------|
|It is applied to all the elements in the script | It is applied only to those elements which are intended by the developer |
|We don't need to specify a condition on the element to be located | We need to specify a condition on the element to be located |
|It is recommended to use when the elements are located with the time frame specified in implicit wait | It is recommended to use when the elements are taking a long time to load and also for verifying the property of the element like (visibilityOfElementLocated, elementToBeClickable,elementToBeSelected) |