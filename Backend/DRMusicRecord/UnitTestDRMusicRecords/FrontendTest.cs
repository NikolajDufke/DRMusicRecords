using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTestDRMusicRecords
{
    [TestClass]
    class FrontendTest
    {
        private static string _driverPath = "C:\\SeleniumDrivers";
        private static IWebDriver _driver;

        [ClassInitialize]
        public void Setup(TestContext context)
        {
            _driver = new ChromeDriver(_driverPath);
        }

        [ClassCleanup]
        public void CleanUp()
        {
            _driver.Dispose();
        }

        [TestMethod]

    }
}
