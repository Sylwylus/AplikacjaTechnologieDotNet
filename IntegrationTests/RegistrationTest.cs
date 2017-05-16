using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace IntegrationTests
{
    [TestClass]
    public class RegistrationTest : BaseWebDriverTest
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

        [TestMethod]
        public void CanFillTheFormAndSubmit()
        {
            Open("/Account/Register");
            Assert.AreEqual("Register - PlanszoWeb", Driver.Title);

            Type("UserName", "TestUser5");
            Type("FirstName", "TestName1");
            Type("LastName", "TestLastName1");
            Type("dateOfBirth", "2010-05-09" + Keys.Enter);
            Type("Email", "test@email.com");
            Type("Password", "pass1234");
            Type("ConfirmPassword", "pass1234" + Keys.Enter);

            WaitForTheNewPage("/");
        }
    }
}