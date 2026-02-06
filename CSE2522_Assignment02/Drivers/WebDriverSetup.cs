using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CSE2522_Assignment02.Drivers
{
    public static class WebDriverSetup
    {
        public static IWebDriver GetDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--allow-running-insecure-content");
            // options.AddArgument("--headless"); // Uncomment for headless mode
            
            return new ChromeDriver(options);
        }
    }
}
