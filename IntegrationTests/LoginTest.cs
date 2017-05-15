using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests
{
    [TestClass]
    public class LoginTest : BaseWebDriverTest
    {

        [ClassCleanup]
        public static void ClassCleanup()
        {
            BaseWebDriverTest.ClassCleanup();
        }

        [TestMethod]
        public void LoginAsModerator()
        {
            Login(Users.Moderator);
        }
    }
}