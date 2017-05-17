using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace IntegrationTests
{
    [TestClass]
    public class LoginTest : BaseWebDriverTest
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
        public void LoginAsModerator()
        {
            AssertCurrentPage(BaseUrl);
        }

        // todo verify when error pages/redirection is established
        [TestMethod]
        public void CannotAccessProfileDataAfterLogOff()
        {
            GetElement("logoutForm").Submit();
            Open("/Account/ProfileData");
            Wait(d => d.FindElement(By.TagName("h1")).Text.Contains("Error"), 1000);
        }
    }
}