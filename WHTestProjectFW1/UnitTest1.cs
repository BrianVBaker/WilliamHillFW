using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using System.Collections.Generic;

namespace WHTestProjectFW1
{
    [TestClass]
    public class UnitTest1

    {
        string browser = "Chrome";

        IWebDriver fdriver = new ChromeDriver();

        [TestInitialize]
        public void TestInit1()
        {
            // Initialisation stuff
        }
        [TestMethod]
        public void TestMethod1()
        {

            WHPageObjects BBTestWH = new WHPageObjects();

            // Tests

            BBTestWH.WHHomePageLogo(fdriver);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            fdriver.Quit();
        }

    }
    public class WHPageObjects
    {
        public void WHHomePageLogo(IWebDriver fdriver)
        {
            // Opens Online betting page and checks if WH logo is visible

            fdriver.Navigate().GoToUrl("http://sports.williamhill.com/bet/en-gb");
            if (!waitForElement(fdriver, By.CssSelector("#logo > a")))
                Assert.Fail("Time out failure : Home Page");

        }

        public bool waitForElement(IWebDriver Fdriver, By Bystring)
        {
            WebDriverWait wait30 = new WebDriverWait(Fdriver, TimeSpan.FromSeconds(30));
            try
            {
                wait30.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(Bystring));
            }

            catch (Exception exp)
            {
                Debug.WriteLine(exp);
                return false;
            }

            return true;
        }
    }


}

