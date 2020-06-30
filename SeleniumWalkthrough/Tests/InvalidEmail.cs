
using NUnit.Framework;
using SeleniumWalkthrough;
using SeleniumWalkthrough.lib;

namespace SpecFlowSeleniumWalkthrough.Tests
{
    [TestFixture]
    public class BbcEmailLoginTest
    {
        public BbcWebsite bbcWebsite;
        [OneTimeSetUp]
        public void SetUp()
        {
            bbcWebsite = new BbcWebsite("chrome");
            bbcWebsite.bbcLoginPage.GoToLoginPage();
        }
        [Test]
        public void NotRecognisedEmail_SetupAccountMessage()
        {
            bbcWebsite.bbcLoginPage.EnterUsername("testing@example.com");
            bbcWebsite.bbcLoginPage.EnterPassword("AbCdEf12");
            bbcWebsite.bbcLoginPage.Submit();
            System.Threading.Thread.Sleep(500);

            string result = bbcWebsite.bbcLoginPage.GetErrorMessages("username");

            Assert.That(result, Is.EqualTo("Sorry, we can’t find an account with that email. You can register for a new account or get help here."));
        }
        [Test]
        public void NoDotComEmail_NotRecognisedEmailsMessage()
        {

            bbcWebsite.bbcLoginPage.EnterUsername("testing@example");
            bbcWebsite.bbcLoginPage.EnterPassword("AbCdEf12");
            bbcWebsite.bbcLoginPage.Submit();
            System.Threading.Thread.Sleep(500);

            string result = bbcWebsite.bbcLoginPage.GetErrorMessages("username");

            Assert.That(result, Is.EqualTo("Sorry, that email doesn’t look right. Please check it's a proper email."));
        }
        [Test]
        public void NoAtSymbolEmail_NotRecognisedEmailsMessage()
        {

            bbcWebsite.bbcLoginPage.EnterUsername("testingexample.");
            bbcWebsite.bbcLoginPage.EnterPassword("AbCdEf12");
            bbcWebsite.bbcLoginPage.Submit();
            System.Threading.Thread.Sleep(500);

            string result = bbcWebsite.bbcLoginPage.GetErrorMessages("username");

            Assert.That(result, Is.EqualTo("Usernames can only include... Letters, numbers and these characters: ?/|}{+=_-^~`%$#"));
        }
        [Test]
        public void NoEmail_SomethingMissingMessage()
        {
            bbcWebsite.bbcLoginPage.EnterUsername("");
            bbcWebsite.bbcLoginPage.EnterPassword("AbCdEf12");
            bbcWebsite.bbcLoginPage.Submit();
            System.Threading.Thread.Sleep(500);

            string result = bbcWebsite.bbcLoginPage.GetErrorMessages("username");

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