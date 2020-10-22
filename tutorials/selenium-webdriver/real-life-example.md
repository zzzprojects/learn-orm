---
PermaID: 100012
Name: Real Life Example 
---

# Real Life Example

So far we have learned about the Selenium and how to identify and find an element using different techniques, navigate from one page to another, and perform different actions. 

 - Selenium works great for automating tasks in the browser. 
 - It can be used to script interaction with a website by taking control of the browser in any of the programming language of your choice, such as C# Java, and Python, etc. 
 
Now let's have a look into a real example, where we will log in to a Facebook and then navigate to the profile. When you navigate through the **Email address or phone number** box and inspect the element, you will see various web elements as shown below.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/selenium-webdriver/images/real-example-1.png">

You can see an `id` whose value is "email". Now you can use the following code to find the **Email address or phone number** box using the `id` locator. Now look for a **Password** box and you can see that `id` value is "pass" as shown below.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/selenium-webdriver/images/real-example-2.png">

Similarly, locate the Login button locator as shown below.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/selenium-webdriver/images/real-example-3.png">

Let's write some code to automate the Facebook login. The following code will open the driver to maximize the browser window and then navigate to the Facebook login page.

```csharp
IWebDriver driver = new ChromeDriver();
driver.Manage().Window.Maximize();
driver.Navigate().GoToUrl("https://www.facebook.com/");
```

The next step is to find the email, password fields respectively.

```csharp
// Find the username field (Facebook calls it "email") and enter value
var email = driver.FindElement(By.Id("email"));
email.SendKeys("your email");

// Find the password field and enter value
var password = driver.FindElement(By.Id("pass"));
password.SendKeys("your password");
```

You must specify your own email and password in the above code to make it work. Now locate the login button by its id and click the login button using the `Click()` method as shown below.

```csharp
var loginButtonLocator = By.Id("u_0_b");

wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(loginButtonLocator));
var loginButton = driver.FindElement(loginButtonLocator);

loginButton.Click();
```

When you are logged-in successfully, now we need to click on the profile link using the following code.

```csharp
var profileElement = driver.FindElement(By.XPath("//*[@id='mount_0_0']/div/div[1]/div[1]/div[3]/div/div/div[1]/div[1]/div/div[1]/div/div/div[1]/div/div/div[1]/ul/li/div/a/div[1]/div[2]/div/div/div/div/span/span"));

profileElement.Click();
```

You can see the long XPath, but due to the new changes this the way to locate the profile link. Here is the complete code which will log in to the Facebook page and then navigate to the user profile.

```csharp
IWebDriver driver = new ChromeDriver();
driver.Manage().Window.Maximize();
driver.Navigate().GoToUrl("https://www.facebook.com/");

// Find the username field (Facebook calls it "email") and enter value
var email = driver.FindElement(By.Id("email"));
email.SendKeys("your email");

// Find the password field and enter value
var password = driver.FindElement(By.Id("pass"));
password.SendKeys("your password");

var loginButtonLocator = By.Id("u_0_b");

try
{
    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

    wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(loginButtonLocator));
    var loginButton = driver.FindElement(loginButtonLocator);

    loginButton.Click();
    wait.Until(ExpectedConditions.StalenessOf(loginButton));
    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

    var profileElement = driver.FindElement(By.XPath("//*[@id='mount_0_0']/div/div[1]/div[1]/div[3]/div/div/div[1]/div[1]/div/div[1]/div/div/div[1]/div/div/div[1]/ul/li/div/a/div[1]/div[2]/div/div/div/div/span/span"));

    profileElement.Click();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
```