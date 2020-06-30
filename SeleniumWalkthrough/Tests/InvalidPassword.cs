using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWalkthrough;
using SeleniumWalkthrough.lib;

namespace SpecFlowSeleniumWalkthrough.Tests
{
    [TestFixture]
    public class BbcPasswordLoginTest
    {
        public BbcWebsite bbcWebsite;
        [OneTimeSetUp]
        public void SetUp()
        {
            bbcWebsite = new BbcWebsite("chrome");
            bbcWebsite.bbcLoginPage.GoToLoginPage();
        }
        [Test]
        public void Password1_ReturnsTooEasyMessage()
        {
            bbcWebsite.bbcLoginPage.EnterUsername("testing@example.com");
            bbcWebsite.bbcLoginPage.EnterPassword("Password1");
            bbcWebsite.bbcLoginPage.Submit();
            System.Threading.Thread.Sleep(500);

            string result = bbcWebsite.bbcLoginPage.GetErrorMessages("password");
 
            Assert.That(result, Is.EqualTo("Sorry, that password isn't valid. Make sure it's hard to guess."));
            
        }
        [Test]
        public void NoNumberPassword_ReturnsIncludeNotALetterMessage()
        {
            bbcWebsite.bbcLoginPage.EnterUsername("testing@example.com");
            bbcWebsite.bbcLoginPage.EnterPassword("Password");
            bbcWebsite.bbcLoginPage.Submit();
            System.Threading.Thread.Sleep(500);

            string result = bbcWebsite.bbcLoginPage.GetErrorMessages("password");
   
            Assert.That(result, Is.EqualTo("Sorry, that password isn't valid. Please include something that isn't a letter."));
        }
        [Test]
        public void ShortPassword_ReturnsEightCharactersMessage()
        {
            bbcWebsite.bbcLoginPage.EnterUsername("testing@example.com");
            bbcWebsite.bbcLoginPage.EnterPassword("Pass");
            bbcWebsite.bbcLoginPage.Submit();
            System.Threading.Thread.Sleep(500);

            string result = bbcWebsite.bbcLoginPage.GetErrorMessages("password");
            Assert.That(result, Is.EqualTo("Sorry, that password is too short. It needs to be eight characters or more."));
        }
        [Test]
        public void ValidEmailWrongPassword_WrongPasswordMessage()
        {
            bbcWebsite.bbcLoginPage.EnterUsername(AppConfigReader.EmailAddress);
            bbcWebsite.bbcLoginPage.EnterPassword("AbCdEf12");
            bbcWebsite.bbcLoginPage.Submit();
            System.Threading.Thread.Sleep(1000);

            string result = bbcWebsite.bbcLoginPage.GetErrorMessages("password");

            Assert.That(result, Is.EqualTo("Uh oh, that password doesn’t match that account. Please try again."));
        }
        [Test]
        public void NoPassword_SomethingMissingMessage()
        {
            bbcWebsite.bbcLoginPage.EnterUsername("testing@example.com");
            bbcWebsite.bbcLoginPage.EnterPassword("");
            bbcWebsite.bbcLoginPage.Submit();
            System.Threading.Thread.Sleep(500);

            string result = bbcWebsite.bbcLoginPage.GetErrorMessages("password");

            Assert.That(result, Is.EqualTo("Something's missing. Please check and try again."));
        }
        [TearDown]
        public void TearDown()
        {
            bbcWebsite.bbcLoginPage.ClearInformation();
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            bbcWebsite.bbcLoginPage.EnterUsername(AppConfigReader.EmailAddress);
            bbcWebsite.bbcLoginPage.EnterPassword(AppConfigReader.Password);
            bbcWebsite.bbcLoginPage.Submit();
            bbcWebsite.seleniumDriver.Dispose();
        }
    }
}