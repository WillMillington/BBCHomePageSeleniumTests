using System;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumWalkthrough.lib;

namespace SeleniumWalkthrough.Tests
{
    class GeneralTests
    {
        public BbcWebsite bbcWebsite;
        [SetUp]
        public void SetUp()
        {
            bbcWebsite = new BbcWebsite("chrome");
        }
        [Test]
        public void CanAccessLoginPage()
        {
            bbcWebsite.bbcHomePage.VisitHomePage();
            bbcWebsite.bbcHomePage.ClickSignInLink();
            System.Threading.Thread.Sleep(2000);

            string resultUrl = bbcWebsite.seleniumDriver.Url.ToString();

            Assert.That(resultUrl.Substring(0,30), Is.EqualTo(AppConfigReader.SignInPageUrl));
        }
        [Test]
        public void CorrectDetails_SuccessfulLogin()
        {
            bbcWebsite.bbcLoginPage.GoToLoginPage();
            bbcWebsite.bbcLoginPage.ClearInformation();
            bbcWebsite.bbcLoginPage.EnterUsername(AppConfigReader.EmailAddress);
            bbcWebsite.bbcLoginPage.EnterPassword(AppConfigReader.Password);
            bbcWebsite.bbcLoginPage.Submit();
                
            Assert.That(bbcWebsite.seleniumDriver.Url.ToString(), Is.EqualTo("https://www.bbc.com/"));
        }
        [Test]
        public void NoEntry_NotFilledInMessage()
        {
            bbcWebsite.bbcLoginPage.GoToLoginPage();
            bbcWebsite.bbcLoginPage.ClearInformation();
            bbcWebsite.bbcLoginPage.Submit();

            string resultUserName = bbcWebsite.bbcLoginPage.GetErrorMessages("username");
            string resultPassword = bbcWebsite.bbcLoginPage.GetErrorMessages("password");
            string resultGeneral = bbcWebsite.bbcLoginPage.GetErrorMessages("general");

            Assert.That(resultUserName, Is.EqualTo("Something's missing. Please check and try again."));
            Assert.That(resultPassword, Is.EqualTo("Something's missing. Please check and try again."));
            Assert.That(resultGeneral, Is.EqualTo("Sorry, those details don't match. Check you've typed them correctly."));
        }
        [Test]
        public void ValidEmailIncorrectPassword_ReturnsMatchError()
        {
            bbcWebsite.bbcLoginPage.GoToLoginPage();
            bbcWebsite.bbcLoginPage.ClearInformation();
            bbcWebsite.bbcLoginPage.EnterUsername(AppConfigReader.EmailAddress);
            bbcWebsite.bbcLoginPage.EnterPassword("Password");
            bbcWebsite.bbcLoginPage.Submit();

            string result = bbcWebsite.bbcLoginPage.GetErrorMessages("password");

            Assert.That(result, Is.EqualTo("Sorry, that password isn't valid. Please include something that isn't a letter."));
        }
        [TearDown]
        public void TearDown()
        {
            bbcWebsite.seleniumDriver.Dispose();
        }
    }
}
