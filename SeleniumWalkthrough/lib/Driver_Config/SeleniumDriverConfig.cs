using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SeleniumWalkthrough.lib.Driver_Config
{
    public class SeleniumDriverConfig
    {
        public IWebDriver Driver { get; set; }
        public SeleniumDriverConfig(string driverName, int pageLoadInSecs, int implicitWaitInSecs)
        {
            DirverSetUp(driverName, pageLoadInSecs, implicitWaitInSecs);
        }

        private void DirverSetUp(string driverName, int pageLoadInSecs, int implicitWaitInSecs)
        {
            if (driverName.ToLower() == "chrome")
            {
                SetChromeDriver();
            }
            else if (driverName.ToLower() == "firefox")
            {
                SetFirefoxDriver();
            }
            else
            {
                throw new Exception("Use 'chrome' or 'firefox'");
            }
            SetDriverConfiguration(pageLoadInSecs, implicitWaitInSecs);
        }

        private void SetDriverConfiguration(int pageLoadInSecs, int implicitWaitInSecs)
        {
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadInSecs);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitInSecs);
        }

        private void SetFirefoxDriver()
        {
            Driver = new FirefoxDriver();
        }

        private void SetChromeDriver()
        {
            Driver = new ChromeDriver();
        }
    }
}
