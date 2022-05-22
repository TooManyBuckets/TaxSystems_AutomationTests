using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Func<IWebDriver, bool> waitforelement = new Func<IWebDriver, bool>((IWebDriver Web) =>
                {
                    IWebElement TotalValueCheck = Web.FindElement(By.XPath("//span[contains(@class,'ajax_block_cart_total')]"));
                    if (TotalValueCheck != null)
                    {
                        return true;
                    }
                    return false;
                });
            //wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until(waitforelement);
            /*
                        //This selects the checkout button and confirms the next page
                        IWebElement TotalValueCheck = driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[4]/div[1]/div[2]/div[3]/span"));
                        Console.WriteLine(TotalValueCheck);

                        String PopupDisplayed = TotalValueCheck.Text;
                        //String PopupDisplayed = driver.FindElement(By.XPath(String.Format("//*[contains(@class,'ajax_block_cart_total')]"))).GetAttribute("value");
                        Console.Write(PopupDisplayed);
                        if (PopupDisplayed != "$59.96")
                        {
                            Console.Write("The total amount for this = " + PopupDisplayed + ". This is not the correct total");
                            Assert.Fail();
                        }
                        */
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
            //Validate that the full total after tax is correct
            IWebElement ConfirmTotal = driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div[2]/table/tfoot/tr[6]/td[2]/span"));
            String ConfirmTotalText = ConfirmTotal.Text;
            if (ConfirmTotalText != "$88.94")
            {
                Assert.Fail("The full total '" + ConfirmTotalText + "' is incorrect.");
            }
        }

        [Test]
        public void TestCase6()
        {
            //Validate that the size and colour are correct
            IWebElement ConfirmConfig = driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div[2]/table/tbody/tr/td[2]/small[2]/a"));
            String ConfirmConfigText = ConfirmConfig.Text;
            if (ConfirmConfigText != "Color : Blue, Size : M")
            {
                Assert.Fail("The size and colour of the dress being '" + ConfirmConfigText + "' is incorrect.");
            }
        }

        [Test]
        public void TestCase7()
        {
            //Validate that the total cost of products is correct
            IWebElement ConfirmSubTotal = driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div[2]/table/tfoot/tr[1]/td[3]"));
            String ConfirmSubTotalText = ConfirmSubTotal.Text;
            if (ConfirmSubTotalText != "$86.94")
            {
                Assert.Fail("The subtotal of products '" + ConfirmSubTotalText + "' is incorrect.");
            }
        }

        [Test]
        public void TestCase8()
        {
            //Validate that the total cost of products is correct
            IWebElement ConfirmShipping = driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div[2]/table/tfoot/tr[3]/td[2]"));
            String ConfirmShippingText = ConfirmShipping.Text;
            if (ConfirmShippingText != "$2.00")
            {
                Assert.Fail("The total cost of shipping '" + ConfirmShippingText + "' is incorrect.");
            }
        }

        [Test]
        public void TestCase9()
        { 
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
