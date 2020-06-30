using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;

namespace SeleniumWalkthrough.lib.Pages
{
    public class BbcLoginPage
    {
        private IWebDriver seleniumDriver;
        private string loginPageUrl = AppConfigReader.SignInPageUrl;

        public BbcLoginPage(IWebDriver seleniumDriver)
        {
            this.seleniumDriver = seleniumDriver;
        }

        internal void EnterUsername(string userName)
        {
            seleniumDriver.FindElement(By.Id("user-identifier-input")).SendKeys(userName);

        }

        internal void GoToLoginPage()
        {
            seleniumDriver.Manage().Window.Maximize();
            seleniumDriver.Navigate().GoToUrl(loginPageUrl);
        }

        internal void ClearInformation()
        {
            seleniumDriver.FindElement(By.Id("user-identifier-input")).Clear();
            seleniumDriver.FindElement(By.Id("password-input")).Clear();
        }

        internal void EnterPassword(string password)
        {
            seleniumDriver.FindElement(By.Id("password-input")).SendKeys(password);
        }

        internal void Submit()
        {
            seleniumDriver.FindElement(By.Id("submit-button")).Click();
        }

        internal string GetErrorMessages(string messageType)
        {
            string errorMessage = "";
            switch (messageType.ToLower())
            {
                case "username":
                    errorMessage = seleniumDriver.FindElement(By.Id("form-message-username")).Text;
                    break;
                case "password":
                    errorMessage = seleniumDriver.FindElement(By.Id("form-message-password")).Text;
                    break;
                case "general":
                    errorMessage = seleniumDriver.FindElement(By.Id("form-message-general")).Text;
                    break;
            }
            return errorMessage;
        }
    }
}
