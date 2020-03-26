using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        [TestMethod]
        public void Title()
        {
            _driver.Navigate().GoToUrl(_webPage);

            string title = _driver.Title;
            Assert.AreEqual("Coding Template", title);
        }

        [TestMethod]
        public void TestTabelWithAllRecords()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driver.Navigate().GoToUrl(_webPage);
            
            IWebElement FirstResult = wait.Until(d => d.FindElement(By.Id("tablecontent")));
            IList<IWebElement> tableRow = FirstResult.FindElements(By.TagName("tr"));

            Assert.AreEqual(8, tableRow.Count());
        }
    }
}
