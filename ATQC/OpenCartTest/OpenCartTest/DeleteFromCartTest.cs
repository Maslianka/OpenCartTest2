using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;

namespace OpenCartTest
{
    class DeleteFromCartTest
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl(ConstantsOpenCart.MAIN_PAGE_OPEN_CART);
        }

        [TearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [Test]
        public void Test_delete_product_from_cart()
        {

            // Steps          
            driver.FindElement(By.XPath("//a[text() = 'MacBook']")).Click();//Find element 'MacBook'
            driver.FindElement(By.CssSelector(".btn.btn-primary.btn-lg.btn-block")).Click();
            driver.FindElement(By.CssSelector("a>i.fa.fa-shopping-cart")).Click();
            driver.FindElement(By.LinkText("MacBook"));
            driver.FindElement(By.XPath("//form/div/table/tbody/tr/td[4]/div/span/button[2]")).Click();
            IWebElement actual1 = driver.FindElement(By.LinkText("Continue"));
            actual1.Click();
            Thread.Sleep(4000);


        }
    }
}
