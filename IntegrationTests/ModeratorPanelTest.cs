using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests
{
    [TestClass]
    public class ModeratorPanelTest : BaseWebDriverTest
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

        // [TestMethod]
        public void ShowNotAcceptedGames()
        {
            Open("/Game/NotAcceptedGames");
        }
    }
}