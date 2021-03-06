﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace IntegrationTests
{
    public class BaseWebDriverTest
    {
        public const string BaseUrl = "http://localhost:9083";

        private const int TimeOut = 5;

        private static readonly IWebDriver StaticDriver = CreateDriverInstance();
        private static User _currentlyLoggedInAs;

        static BaseWebDriverTest()
        {
            StaticDriver.Manage().Timeouts().ImplicitlyWait(
                TimeSpan.FromSeconds(TimeOut));
        }

        public static void ClassInitialize(User user = null)
        {
            if (user != null)
            {
                Login(user);
            }
            else
            {
                StaticDriver.Navigate().GoToUrl(BaseUrl);
            }
        }

        public static void ClassCleanup()
        {
            try
            {
                StaticDriver.Quit();
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        private static IWebDriver CreateDriverInstance(string baseUrl = BaseUrl)
        {
            return new ChromeDriver();
        }

        public IWebDriver Driver
        {
            get { return StaticDriver; }
        }

        public void Open(string url)
        {
            Driver.Navigate().GoToUrl(BaseUrl + url.Trim('~'));
        }

        public void Click(string id)
        {
            Click(By.Id(id));
        }

        public void Click(By locator)
        {
            Driver.FindElement(locator).Click();
        }

        public void AssertCurrentPage(string pageUrl)
        {
            var absoluteUrl = new Uri(new Uri(BaseUrl), pageUrl.Trim('~')).ToString();
            Assert.AreEqual(absoluteUrl, Driver.Url);
        }

        public void WaitForTheNewPage(string newUrl)
        {
            WebDriverWait wait = new WebDriverWait(Driver,
                TimeSpan.FromSeconds(TimeOut));
            wait.Until(d => d.Url.Contains(BaseUrl + newUrl));
        }

        public void Wait(Func<IWebDriver, bool> condition, double milisecondsToWait)
        {
            var wait = new WebDriverWait(StaticDriver, TimeSpan.FromMilliseconds(milisecondsToWait));
            wait.Until(condition);
        }

        public IWebElement GetElement(string id)
        {
            return Driver.FindElement(By.Id(id));
        }

        public void Type(string id, string text)
        {
            var element = GetElement(id);
            element.Clear();
            element.SendKeys(text);
        }

        public void AssertTextContains(By locator, string text)
        {
            Assert.IsTrue(Driver.FindElement(locator).Text.Contains(text));
        }

        private static void Login(User user)
        {
            StaticDriver.Navigate().GoToUrl(BaseUrl + "/Account/Login");

            StaticDriver.FindElement(By.Id("UserName")).SendKeys(user.Username);
            StaticDriver.FindElement(By.Id("Password")).SendKeys(user.Password + Keys.Enter);

            _currentlyLoggedInAs = user;
        }
    }

    public class User
    {
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public override bool Equals(object obj)
        {
            User compareTo = obj as User;
            if (compareTo == null)
                return false;

            return compareTo.Username == Username &&
                   compareTo.Password == Password;
        }
    }

    public class Users
    {
        public static User Moderator
        {
            get { return new User("Minion", "asdfghj1"); }
        }
    }
}