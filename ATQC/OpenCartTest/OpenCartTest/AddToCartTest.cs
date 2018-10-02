using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;

namespace OpenCartTest
{
    [TestClass]
    public class AddToCartTest
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
        public void Test_add_products_to_cart_first_type()
        {
            // Steps                       
            driver.FindElement(By.XPath("//a[text() = 'MacBook']/../../..//child::i[@class='fa fa-shopping-cart']")).Click();
            driver.FindElement(By.CssSelector("a>i.fa.fa-shopping-cart")).Click();
            IWebElement actual = driver.FindElement(By.LinkText("MacBook"));
            
            //assert
            Assert.True(actual.Text.Contains("MacBook"));
        }

        [Test]
        public void Test_add_products_to_cart_second_type()
        {
            // Steps                       
            driver.FindElement(By.XPath("//a[text() = 'MacBook']")).Click();//Find element 'MacBook'
            driver.FindElement(By.CssSelector(".btn.btn-primary.btn-lg.btn-block")).Click();
            driver.FindElement(By.CssSelector("a>i.fa.fa-shopping-cart")).Click();
            IWebElement actual = driver.FindElement(By.LinkText("MacBook"));

            //assert
            Assert.True(actual.Text.Contains("MacBook"));
        }
        [Test]
        public void Test_add_products_to_cart_thirst_type()
        {
            // Steps                       
            driver.FindElement(By.XPath("//a[text() = 'MacBook']/../../..//child::i[@class='fa fa-shopping-cart']")).Click();
            var element = driver.FindElement(By.XPath("//span/i"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            element.Click();
            IWebElement actual = driver.FindElement(By.XPath("//td/a[text() = 'MacBook']"));
            driver.FindElement(By.XPath("//td[text() = 'x 1']"));
            //assert
            Assert.True(actual.Text.Contains("MacBook"));
        }

        [Test]
        public void Test_checking_the_price()
        {
            // Steps                       
          

            //assert
            
        }
    }
}