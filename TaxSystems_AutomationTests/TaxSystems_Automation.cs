<<<<<<< HEAD
﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;


namespace TaxSystemsTestCases
{
    class TaxSystems_Automation 
    {
        static void Main(string[] args)
        {
            //IWebDriver driver = new ChromeDriver();
            TaxSystems_Automation tsa = new TaxSystems_Automation(new ChromeDriver());
            tsa.start_Browser();
            tsa.TestCase1();
            tsa.WindowClose();
        }

        IWebDriver driver;
        

        public TaxSystems_Automation(IWebDriver driver)
        {
            this.driver = driver;
        }

        [OneTimeSetUp]
        public void start_Browser()
        {
            driver.Manage().Window.Maximize();
            driver.Url = "http://automationpractice.com/index.php";
            Console.WriteLine("This is currently functional");
        }
        [Test]
        public void TestCase1()
        {
            //Search for the general title of the dress
            driver.FindElement(By.Id("search_query_top")).SendKeys("Printed Summer Dress");
            driver.FindElement(By.Name("submit_search")).Click();

            //Find the correct Summer Dress and Select it
            driver.FindElement(By.LinkText("Printed Summer Dress")).Click();

            //Adjust the colour of the dress to blue
            driver.FindElement(By.Id("color_14")).Click();

            //Adjust the size of the dress to Medium
            driver.FindElement(By.Id("group_1")).Click();
            {
                var dropdown = driver.FindElement(By.Id("group_1"));
                dropdown.FindElement(By.XPath("//option[. = 'M']")).Click();
            }

            //Set the amount of dresses to 2
            driver.FindElement(By.CssSelector(".icon-plus")).Click();

            //Add the dress to the cart
            driver.FindElement(By.CssSelector(".exclusive > span")).Click();

            //This wait allows for the checkout option to be displayed
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //This selects the checkout button and confirms the next page
            driver.FindElement(By.CssSelector(".button-medium > span")).Click();
            driver.FindElement(By.Name("quantity_5_24_0_0")).Click();
            {
                var element = driver.FindElement(By.Name("quantity_5_24_0_0"));
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Update the amount to 3 dresses
            driver.FindElement(By.CssSelector(".icon-plus")).Click();
            driver.FindElement(By.CssSelector("#product_5_24_0_0 > .cart_total")).Click();

            //Validate that correct values are appearing on the screen
            driver.FindElement(By.XPath("//*[contains(text(),'Printed Summer Dress')]"));
            driver.FindElement(By.XPath("//*[contains(text(),'Color : Blue')]"));
            driver.FindElement(By.XPath("//*[contains(text(),'Size : M')]"));
            driver.FindElement(By.XPath("//*[contains(text(),'88.94')]"));
            driver.FindElement(By.XPath("//*[contains(text(),'86.94')]"));
            driver.FindElement(By.XPath("//*[contains(text(),'$2.00')]"));
            driver.FindElement(By.XPath("//*[contains(text(),'Size : M')]"));

            //Navigate to final checkout page
            driver.FindElement(By.CssSelector(".standard-checkout > span")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public void WindowClose()
        {
            driver.Dispose();
        }

    }
=======
﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;


namespace TaxSystemsTestCases
{
    class TaxSystems_Automation 
    {
        static void Main(string[] args)
        {
            //IWebDriver driver = new ChromeDriver();
            TaxSystems_Automation tsa = new TaxSystems_Automation(new ChromeDriver());
            tsa.start_Browser();
            tsa.TestCase1();
            tsa.WindowClose();
        }

        IWebDriver driver;
        

        public TaxSystems_Automation(IWebDriver driver)
        {
            this.driver = driver;
        }

        [OneTimeSetUp]
        public void start_Browser()
        {
            driver.Manage().Window.Maximize();
            driver.Url = "http://automationpractice.com/index.php";
            Console.WriteLine("This is currently functional");
        }
        [Test]
        public void TestCase1()
        {
            //Search for the general title of the dress
            driver.FindElement(By.Id("search_query_top")).SendKeys("Printed Summer Dress");
            driver.FindElement(By.Name("submit_search")).Click();

            //Find the correct Summer Dress and Select it
            driver.FindElement(By.LinkText("Printed Summer Dress")).Click();

            //Adjust the colour of the dress to blue
            driver.FindElement(By.Id("color_14")).Click();

            //Adjust the size of the dress to Medium
            driver.FindElement(By.Id("group_1")).Click();
            {
                var dropdown = driver.FindElement(By.Id("group_1"));
                dropdown.FindElement(By.XPath("//option[. = 'M']")).Click();
            }

            //Set the amount of dresses to 2
            driver.FindElement(By.CssSelector(".icon-plus")).Click();

            //Add the dress to the cart
            driver.FindElement(By.CssSelector(".exclusive > span")).Click();

            //This wait allows for the checkout option to be displayed
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //This selects the checkout button and confirms the next page
            driver.FindElement(By.CssSelector(".button-medium > span")).Click();
            driver.FindElement(By.Name("quantity_5_24_0_0")).Click();
            {
                var element = driver.FindElement(By.Name("quantity_5_24_0_0"));
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Update the amount to 3 dresses
            driver.FindElement(By.CssSelector(".icon-plus")).Click();
            driver.FindElement(By.CssSelector("#product_5_24_0_0 > .cart_total")).Click();

            //Validate that correct values are appearing on the screen
            driver.FindElement(By.XPath("//*[contains(text(),'Printed Summer Dress')]"));
            driver.FindElement(By.XPath("//*[contains(text(),'Color : Blue')]"));
            driver.FindElement(By.XPath("//*[contains(text(),'Size : M')]"));
            driver.FindElement(By.XPath("//*[contains(text(),'88.94')]"));
            driver.FindElement(By.XPath("//*[contains(text(),'86.94')]"));
            driver.FindElement(By.XPath("//*[contains(text(),'$2.00')]"));
            driver.FindElement(By.XPath("//*[contains(text(),'Size : M')]"));

            //Navigate to final checkout page
            driver.FindElement(By.CssSelector(".standard-checkout > span")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public void WindowClose()
        {
            driver.Dispose();
        }

    }
>>>>>>> 8662ad15f2c7283875f0da362d33c5780c31a573
}