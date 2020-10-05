---
PermaID: 100002
Name: Elements Identification
---

# Elements Identification

The identification of web elements is one of the most critical section not only for the selenium web browser but in general element identification, it is a key aspects when it comes to doing any kind of functional test automation. It is one of the most critical skill that you can learn, if you can't identify an element you can't automate it.

### Using HTML

As automation engineers, you need to know how to use HTML to identify your web elements. The better you understand the HTML, the easier it will be for you to identify web elements.

### Using Chrome Browser

You can inspect the HTML of different elements using the chrome browser. The easiest way is to open up the page you want to interact with within the chrome browser.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/selenium-webdriver/images/elements-identification-1.png">

You can click on the three little dots on the top right.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/selenium-webdriver/images/elements-identification-2.png">

Select the **More tools > developer tools**. On developer tools, click on the little square with the pointer icon on the left-hand side that will allow you to select the elements that you would like to select.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/selenium-webdriver/images/elements-identification-3.png">

Now if you want to interact with the **Google Search** button, you can go ahead and click on this button and it will automatically highlight it for you in the HTML.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/selenium-webdriver/images/elements-identification-4.png">

Now you can see in HTML that if you move the mouse over different element tags, it provides you with a view of what that represents in the HTML. 

The other feature of developer tools is the control of feature, if you hit **Ctrl+F** while in developer tools, you will see a search bar open up at the end.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/selenium-webdriver/images/elements-identification-5.png">

In the search bar, it says **Find by string selector or XPath**, so you can use CSS, XPath, or strings to locate your element. For example, let's say you want to find all the `input` tags, you can simply type `//input` in the search bar and it will show you all the input elements.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/selenium-webdriver/images/elements-identification-6.png">

On the right side of the search bar, you can see that 12 inputs are found and currently it is showing the first input.

You can even search for a string, for example, let's search for *Google Search*.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/selenium-webdriver/images/elements-identification-7.png">

As you can see that the **Google Search** button is found.

