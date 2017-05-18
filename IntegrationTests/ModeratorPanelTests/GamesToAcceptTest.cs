using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace IntegrationTests
{
    [TestClass]
    public class GamesToAcceptTest : BaseWebDriverTest
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
        public void ShowNotAcceptedGames()
        {
            Open("/Game/NotAcceptedGames");
            AssertTextContains(By.TagName("h2"), "Games to accept");
        }
    }
}