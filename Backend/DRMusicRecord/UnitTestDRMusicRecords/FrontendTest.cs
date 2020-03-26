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
            _driver.Navigate().GoToUrl("http://localhost:3000/");

            string title = _driver.Title;
            Assert.AreEqual("Coding Template", title);
        }

        [TestMethod]
        public void TestTabelWithAllRecords()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");

            WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0,0,10));

            IEnumerable<IWebElement> content = _driver.FindElements(By.Id("tablecontent"));
           
            Assert.AreEqual(8, content.Count());
        }
    }
}
