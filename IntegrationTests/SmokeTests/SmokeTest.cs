using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace IntegrationTests
{
    [TestClass]
    public class SmokeTest : BaseWebDriverTest
    {
        private static int ScreenShotCounter = 0;

        private static string LoginURL = "/Account/Login";
        private static string RegistrationURL = "/Account/Register";
        private static string AllGamesURL = "/Game";
        private static string Top20GamesURL = "/Game/Top20Games";
        private static string ReviewURL = "/Review";
        private static string OldNewsURL = "/Home/OldNews";
        private static string SomeGameDetailsURL = "/Game/Details/14";

        private static string LoginTitle = "Log in - PlanszoWeb";
        private static string RegistrationTitle = "Register - PlanszoWeb";
        private static string AllGamesTitle = "Index - PlanszoWeb";
        private static string Top20Title = "Top20Games - PlanszoWeb";
        private static string ReviewTitle = "";//unknown
        private static string OldNewsTitle = "";//unknown
        private static string SomeGameDetailsTitle = "Details - PlanszoWeb";

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
        [TestCategory("SmokeUITests")]
        public void SmokeLoginTest()
        {
            OpenModuleWithScreenShot(LoginURL, LoginTitle);
        }

        [TestMethod]
        [TestCategory("SmokeUITests")]
        public void SmokeRegistrationTest()
        {
            OpenModuleWithScreenShot(RegistrationURL, RegistrationTitle);
        }

        [TestMethod]
        [TestCategory("SmokeUITests")]
        public void SmokeAllGamesTest()
        {
            OpenModuleWithScreenShot(AllGamesURL, AllGamesTitle);
        }

        [TestMethod]
        [TestCategory("SmokeUITests")]
        public void SmokeTop20GamesTest()
        {
            OpenModuleWithScreenShot(Top20GamesURL, Top20Title);
        }

        [TestMethod]
        [TestCategory("SmokeUITests")]
        public void SmokeReviewTest()
        {
            OpenModuleWithScreenShot(ReviewURL, ReviewTitle);
        }

        [TestMethod]
        [TestCategory("SmokeUITests")]
        public void SmokeOldNewsTest()
        {
            OpenModuleWithScreenShot(OldNewsURL, OldNewsTitle);
        }
        
        [TestMethod]
        [TestCategory("SmokeUITests")]
        public void SmokeSomeGameDetailsTest()
        {
            OpenModuleWithScreenShot(SomeGameDetailsURL, SomeGameDetailsTitle);
        }


        private void OpenModuleWithScreenShot(string URL, string title)
        {
            using (var ChromeDriver = new ChromeDriver())
            {
                ChromeDriver.Navigate().GoToUrl(string.Concat(BaseUrl, URL));
                string name = string.Concat(ScreenShotCounter.ToString(), ".png");
                ScreenShotCounter++;
                ChromeDriver.GetScreenshot().SaveAsFile(name, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }
}