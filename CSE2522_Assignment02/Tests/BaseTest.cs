using CSE2522_Assignment02.Drivers;
using OpenQA.Selenium;

namespace CSE2522_Assignment02.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = WebDriverSetup.GetDriver();
        }

        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}
