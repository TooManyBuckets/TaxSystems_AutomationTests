using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;


namespace TaxSystemsTestCases
{
    class TaxSystems_Automation
    {

        IWebDriver driver;
        IWebElement element;
    

        [OneTimeSetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver("C:\\Users\\walke\\source\\repos\\TooManyBuckets\\TaxSystems_AutomationTests");
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

            //Find the Printed Summer Dress and Select it
            IWebElement DressDisplayed = driver.FindElement(By.LinkText("Printed Summer Dress"));
            Boolean ConfirmedDisplayed = DressDisplayed.Displayed;
            if (ConfirmedDisplayed == false)
            {
                Assert.Fail();
            }
            driver.FindElement(By.LinkText("Printed Summer Dress")).Click();

        }

        [Test]
        public void TestCase2()
        {
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


            
        }

        [Test]
        public void TestCase3()
        {
            //This wait allows for the checkout option to be displayed
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Func<IWebDriver, bool> waitforelement = new Func<IWebDriver, bool>((IWebDriver Web) =>
                {
                    Console.WriteLine("Confirmed Working");
                    IWebElement TotalValueCheck = Web.FindElement(By.XPath("//span[contains(@class,'ajax_block_cart_total')]"));
                    if(TotalValueCheck != null)
                    {
                        return true;
                    }
                    return false;
                });
            //wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until(waitforelement);

            //This selects the checkout button and confirms the next page
            IWebElement TotalValueCheck = driver.FindElement(By.XPath(string.Format("//span[contains(@class,'ajax_block_cart_total')]")));
            String PopupDisplayed = TotalValueCheck.Text;
            Console.Write(PopupDisplayed);
            if (PopupDisplayed != "59.96")
            {
                Console.Write("The total amount for this = " + PopupDisplayed + ". This is not the correct total");
                Assert.Fail();
            }
            driver.FindElement(By.CssSelector(".button-medium > span")).Click();
            driver.FindElement(By.Name("quantity_5_24_0_0")).Click();
            {
                var checkout = driver.FindElement(By.Name("quantity_5_24_0_0"));
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

        [Test]
        public void TestCase4()
        {
            //Update the amount to 3 dresses
            driver.FindElement(By.CssSelector(".icon-plus")).Click();
            driver.FindElement(By.CssSelector("#product_5_24_0_0 > .cart_total")).Click();

        }
        [Test]
        public void TestCase5()
        { 
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
        public void CloseBrowser()
        {
            driver.Close();
        }

    }
}