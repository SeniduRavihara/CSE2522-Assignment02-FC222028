using OpenQA.Selenium;

namespace CSE2522_Assignment02.Pages
{
    public class AlertsPage : BasePage
    {
        private readonly By alertButton = By.Id("alertButton");
        private readonly By confirmButton = By.Id("confirmButton");
        private readonly By promptButton = By.Id("promptButton");

        public AlertsPage(IWebDriver driver) : base(driver) { }

        public void Open()
        {
            _driver.Navigate().GoToUrl("https://uitestingplayground.com/alerts");
            FindElement(alertButton); // Ensure loaded
        }

        public bool IsAlertButtonDisplayed() => FindElement(alertButton).Displayed;
        public bool IsConfirmButtonDisplayed() => FindElement(confirmButton).Displayed;
        public bool IsPromptButtonDisplayed() => FindElement(promptButton).Displayed;

        public string SimpleAlert()
        {
            FindElement(alertButton).Click();

            IAlert alert = _wait.Until(d => d.SwitchTo().Alert());
            string text = alert.Text ?? string.Empty;
            alert.Accept();

            return text;
        }

        public string ConfirmYes()
        {
            FindElement(confirmButton).Click();

            IAlert confirm = _wait.Until(d => d.SwitchTo().Alert());
            confirm.Accept();

            IAlert result = _wait.Until(d => d.SwitchTo().Alert());
            string text = result.Text ?? string.Empty;
            result.Accept();

            return text;
        }

        public string ConfirmNo()
        {
            FindElement(confirmButton).Click();

            IAlert confirm = _wait.Until(d => d.SwitchTo().Alert());
            confirm.Dismiss();

            IAlert result = _wait.Until(d => d.SwitchTo().Alert());
            string text = result.Text ?? string.Empty;
            result.Accept();

            return text;
        }

        public string PromptAccept(string input)
        {
            FindElement(promptButton).Click();

            IAlert prompt = _wait.Until(d => d.SwitchTo().Alert());
            prompt.SendKeys(input);
            prompt.Accept();

            IAlert result = _wait.Until(d => d.SwitchTo().Alert());
            string rawText = result.Text ?? string.Empty;
            result.Accept();

            return rawText.Replace("User value:", "user value").Trim();
        }

        public string PromptCancel()
        {
            FindElement(promptButton).Click();

            IAlert prompt = _wait.Until(d => d.SwitchTo().Alert());
            prompt.Dismiss();

            IAlert result = _wait.Until(d => d.SwitchTo().Alert());
            string rawText = result.Text ?? string.Empty;
            result.Accept();

            return rawText
                .Replace("User value:", "user value -")
                .Replace("no answer", "No answer")
                .Trim();
        }
    }
}
