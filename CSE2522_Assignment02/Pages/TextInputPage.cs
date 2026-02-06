using OpenQA.Selenium;

namespace CSE2522_Assignment02.Pages
{
    public class TextInputPage : BasePage
    {
        public TextInputPage(IWebDriver driver) : base(driver) { }

        private IWebElement InputField => FindElement(By.Id("newButtonName"));
        private IWebElement Button => FindElement(By.Id("updatingButton"));

        public void Open()
        {
            _driver.Navigate().GoToUrl("https://uitestingplayground.com/textinput");
        }

        public void EnterText(string text)
        {
            InputField.Clear();
            InputField.SendKeys(text);
        }

        public void UpdateButton()
        {
            Button.Click();
        }

        public string GetButtonText()
        {
            return Button.Text;
        }
    }
}
