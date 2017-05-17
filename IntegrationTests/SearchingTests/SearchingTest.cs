using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Text;
using System;

namespace IntegrationTests
{
    [TestClass]
    public class SearchingTest : BaseWebDriverTest
    {
        private static string TextSearchingScreenshotName = "textSearchingScreenshot.png";
        private static string TextWithCategorySearchingScreenshotName = "textWithCategorySearchingScreenshot.png";
        private static string CategorySearchingScreenshotName = "CategorySearchingScreenshot.png";

        

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
        public void TextSearching()
        {
            using (var driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:9083/Game");
                var searchField = driver.FindElementById("searchString");
                searchField.SendKeys("Testowy ciag");
                var button = driver.FindElementByXPath("//input[@value='Filter']");
                button.Click();

                // var filterButton = driver.FindElementById()
                driver.GetScreenshot().SaveAsFile(TextSearchingScreenshotName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        [TestMethod]
        public void CategorySearchingTest()
        {
            using (var driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:9083/Game");

                var category = driver.FindElementById("filterCategory");
                category.SendKeys("Adventure");

                var button = driver.FindElementByXPath("//input[@value='Filter']");
                button.Click();
                driver.GetScreenshot().SaveAsFile(CategorySearchingScreenshotName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        [TestMethod]
        public void TextWithCategorySearchingTest()
        {
            using (var driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:9083/Game");
                var searchField = driver.FindElementById("searchString");
                searchField.SendKeys("Testowy ciag");


                var category = driver.FindElementById("filterCategory");
                category.SendKeys("Dice");

                var button = driver.FindElementByXPath("//input[@value='Filter']");
                button.Click();
                driver.GetScreenshot().SaveAsFile(TextWithCategorySearchingScreenshotName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }


    }
}
