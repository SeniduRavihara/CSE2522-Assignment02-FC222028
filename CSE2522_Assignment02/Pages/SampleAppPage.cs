using OpenQA.Selenium;

namespace CSE2522_Assignment02.Pages
{
    public class SampleAppPage : BasePage
    {
        public SampleAppPage(IWebDriver driver) : base(driver) { }

        private IWebElement Username => FindElement(By.Name("UserName"));
        private IWebElement Password => FindElement(By.Name("Password"));
        private IWebElement LoginButton => FindElement(By.Id("login"));
        private IWebElement StatusMessage => FindElement(By.Id("loginstatus"));

        public void Open()
        {
            _driver.Navigate().GoToUrl("https://uitestingplayground.com/sampleapp");
        }

        public bool IsPageLoaded()
        {
            try
            {
                return Username.Displayed && Password.Displayed && LoginButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void Login(string username, string password)
        {
            Username.Clear();
            Username.SendKeys(username);

            Password.Clear();
            Password.SendKeys(password);

            LoginButton.Click();
        }

        public string GetStatus()
        {
            return StatusMessage.Text;
        }
    }
}
