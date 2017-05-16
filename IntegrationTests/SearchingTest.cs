﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Text;

namespace IntegrationTests
{
    [TestClass]
    public class SearchingTest : BaseWebDriverTest
    {

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            ClassInitialize(Users.Moderator);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            BaseWebDriverTest.ClassCleanup();
        }

        [TestMethod]
        public void SimpleSearching()
        {
            using (var driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:9083/Game");
                var searchField = driver.FindElementById("searchString");
                searchField.SendKeys("Testowy ciag");
                var button = driver.FindElementByXPath("//input[@value='Filter']");
                button.Click();

                // var filterButton = driver.FindElementById()
                driver.GetScreenshot().SaveAsFile(@"screen.png", System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }
}
