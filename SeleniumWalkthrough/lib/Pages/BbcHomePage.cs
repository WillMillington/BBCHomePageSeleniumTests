using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumWalkthrough.lib.Pages
{
    public class BbcHomePage
    {
        private IWebDriver seleniumDriver;
        private string homePageUrl = AppConfigReader.BaseUrl;

        public BbcHomePage(IWebDriver seleniumDriver)
        {
            this.seleniumDriver = seleniumDriver;
        }

        internal void ClickSignInLink()
        {
            seleniumDriver.FindElement(By.Id("idcta-username")).Click();
        }

        internal void VisitHomePage()
        {
            seleniumDriver.Manage().Window.Maximize();
            seleniumDriver.Navigate().GoToUrl(homePageUrl);
        }
    }
}
