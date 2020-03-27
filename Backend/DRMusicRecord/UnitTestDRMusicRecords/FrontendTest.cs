using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
 

namespace UnitTestDRMusicRecords
{
    [TestClass]
   public class FrontendTest
    {
        private static string _driverPath = "C:\\SeleniumDrivers";
        private static IWebDriver _driver;
        private static string _webPage = "http://localhost:3000/";
        //private static string _webPage = "https://drrecordswebpage.azurewebsites.net/";
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(_driverPath);
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            _driver.Dispose();
        }

        [TestInitialize]
        public void init()
        {
            _driver.Navigate().GoToUrl(_webPage);
        }

        public WebDriverWait getWait()
        {
            return new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        [TestMethod]
        public void Title()
        {
            string title = _driver.Title;
            Assert.AreEqual("Coding Template", title);
        }

        [TestMethod]
        public void TestTabelWithAllRecords()
        {
            IWebElement FirstResult = getWait().Until(d => d.FindElement(By.Id("tablecontent")));
            IList<IWebElement> tableRow = FirstResult.FindElements(By.TagName("tr"));

            Assert.AreEqual(8, tableRow.Count());
        }

        [TestMethod]
        public void TestTitleSearch()
        {
            IWebElement buttonSearchelement = _driver.FindElement(By.Id("searchButton"));
            IWebElement textElement = _driver.FindElement(By.Id("searchText"));
            IWebElement selectElement = _driver.FindElement(By.Id("searchSelect"));
            SelectElement selec = new SelectElement(selectElement);


            textElement.SendKeys("Stjernen i det blå");

            selec.SelectByText("Title");

            buttonSearchelement.Click();


            IWebElement FirstResult = getWait().Until(d => d.FindElement(By.Id("tablecontent")));
            IList<IWebElement> tableRow = FirstResult.FindElements(By.TagName("tr"));
            Assert.AreEqual(1, tableRow.Count());
        }

        [TestMethod]
        public void TestYearSearch()
        {
            IWebElement buttonSearchelement = _driver.FindElement(By.Id("searchButton"));
            IWebElement textElement = _driver.FindElement(By.Id("searchText"));
            IWebElement selectElement = _driver.FindElement(By.Id("searchSelect"));
            SelectElement selec = new SelectElement(selectElement);

            textElement.SendKeys("2020");

            selec.SelectByText("Year of Publication");

            buttonSearchelement.Click();

            IWebElement FirstResult = getWait().Until(d => d.FindElement(By.Id("tablecontent")));
            IList<IWebElement> tableRow = FirstResult.FindElements(By.TagName("tr"));
            Assert.AreEqual(8, tableRow.Count());
        }
    }
}
