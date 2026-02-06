using NUnit.Framework;
using CSE2522_Assignment02.Pages;

namespace CSE2522_Assignment02.Tests
{
    [TestFixture]
    public class SampleAppTests : BaseTest
    {
        [Test]
        [Description("TC002_1 - Sample App Page Verification")]
        public void VerifySampleAppPage()
        {
            var page = new SampleAppPage(driver);
            page.Open();

            Assert.That(page.IsPageLoaded(), Is.True);
        }

        [Test]
        [Description("TC002_2 - Successful Login")]
        public void VerifySuccessfulLogin()
        {
            var page = new SampleAppPage(driver);
            page.Open();
            page.Login("test", "pwd");

            Assert.That(page.GetStatus(), Does.Contain("Welcome"));
        }

        [Test]
        [Description("TC002_3 - Unsuccessful Login")]
        public void VerifyUnsuccessfulLogin()
        {
            var page = new SampleAppPage(driver);
            page.Open();
            page.Login("test", "wrong");

            Assert.That(page.GetStatus(), Does.Contain("Invalid"));
        }
    }
}
