using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace IntegrationTests
{
    [TestClass]
    public class RegistrationTest : BaseWebDriverTest
    {
        private static string RegistrationURL = "/Account/Register";
        private static string UserName = "ArtificialUser";

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

        [TestMethod]
        public void CanFillTheFormAndSubmit()
        {
            Open(RegistrationURL);
            Assert.AreEqual("Register - PlanszoWeb", Driver.Title);

            Type("UserName", UserName);
            Type("FirstName", "TestName1");
            Type("LastName", "TestLastName1");
            Type("dateOfBirth", "2010-05-09" + Keys.Enter);
            Type("Email", "test@email.com");
            Type("Password", "pass1234");
            Type("ConfirmPassword", "pass1234" + Keys.Enter);

            WaitForTheNewPage("/");
        }

        [TestMethod]
        public void DoNotAcceptFormWithoutUserName()
        {
            Open(RegistrationURL);
            Assert.AreEqual("Register - PlanszoWeb", Driver.Title);

            Type("UserName", "");
            Type("FirstName", "TestName1");
            Type("LastName", "TestLastName1");
            Type("dateOfBirth", "2010-05-09" + Keys.Enter);
            Type("Email", "test@email.com");
            Type("Password", "pass1234");
            Type("ConfirmPassword", "pass1234" + Keys.Enter);

            AssertCurrentPage(RegistrationURL);
            Wait(d => d.FindElement(By.Id("UserName-error")).Text.Equals("User name is required"), 500);
        }
    }
}