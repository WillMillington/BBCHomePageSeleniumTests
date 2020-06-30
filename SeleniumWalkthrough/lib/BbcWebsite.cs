
using System.Drawing.Imaging;
using OpenQA.Selenium;
using SeleniumWalkthrough.lib.Driver_Config;
using SeleniumWalkthrough.lib.Pages;

namespace SeleniumWalkthrough.lib
{
    public class BbcWebsite
    {
        public readonly BbcHomePage bbcHomePage;
        public readonly BbcLoginPage bbcLoginPage;
        public IWebDriver seleniumDriver;

        public BbcWebsite(string driverName, int pageLoadWaitInSecs = 10, int implicitWaitInSecs = 10)
        {
            seleniumDriver = new SeleniumDriverConfig(driverName, pageLoadWaitInSecs, implicitWaitInSecs).Driver;
            bbcHomePage = new BbcHomePage(seleniumDriver);
            bbcLoginPage = new BbcLoginPage(seleniumDriver);
        }

    }
}
