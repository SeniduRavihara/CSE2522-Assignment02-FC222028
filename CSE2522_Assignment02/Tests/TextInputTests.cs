using NUnit.Framework;
using CSE2522_Assignment02.Pages;

namespace CSE2522_Assignment02.Tests
{
    [TestFixture]
    public class TextInputTests : BaseTest
    {
        [Test]
        [Description("Update Button Text With Valid Input")]
        public void UpdateButtonText_WithValidInput()
        {
            var page = new TextInputPage(driver);
            page.Open();

            page.EnterText("Test Button");
            page.UpdateButton(); 

            Assert.That(page.GetButtonText(), Is.EqualTo("Test Button"));
        }
    }
}
