using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace IntegrationTests
{
    [TestClass]
    public class HomePageTest : BaseWebDriverTest
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            ClassInitialize();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            BaseWebDriverTest.ClassCleanup();
        }

        // [TestMethod]
        public void GoToAllGames()
        {
            String path = "/Game";
            Click(By.PartialLinkText(path));
            AssertCurrentPage(BaseUrl + path);
        }

        [TestMethod]
        public void GoToGameDetails()
        {
            String path = "/Game/Details/14";
            Click(By.PartialLinkText(path));
            AssertCurrentPage(BaseUrl + path);
        }
    }
}
