using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecflowNunit
{
    [Binding]
    public class Hooks
    {
        private IWebDriver webDriver;
        public IWebDriver CriaDriver(bool headless = false, int timeout = 15)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", true);
            chromeOptions.AddArgument("--disable-notifications");
            if (headless)
            {
                chromeOptions.AddArgument("--headless");
            }
            webDriver = new ChromeDriver(chromeOptions);
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
            return webDriver;
        }
        [BeforeScenario]
        public void GetSessaoDriver(ScenarioContext context)
        {
            context["WEB_DRIVER"] = CriaDriver();
        }

        [AfterScenario]
        public void FecharDriver()
        {
            webDriver.Quit();
        }

        [AfterStep]
        public void TakeScreenshot(ScenarioContext context)
        {
            DateTime timeStamp = DateTime.Now;
            string caminho = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\..\\screenshots\\" + context.ScenarioInfo.Title));

            if (!System.IO.Directory.Exists(caminho)) System.IO.Directory.CreateDirectory(caminho);

            string fileName = context.ScenarioInfo.Title + "_" + timeStamp.ToString("dd_MM_yyyy-HH_mm_ss") + ".png";
            var driver = context["WEB_DRIVER"] as ChromeDriver;

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            Dictionary<string, Object> metrics = new Dictionary<string, Object>
            {
                ["width"] = js.ExecuteScript("return Math.max(window.innerWidth,document.body.scrollWidth,document.documentElement.scrollWidth)"),
                ["height"] = js.ExecuteScript("return Math.max(window.innerHeight,document.body.scrollHeight,document.documentElement.scrollHeight)"),
                ["deviceScaleFactor"] = js.ExecuteScript("return window.devicePixelRatio"),
                ["mobile"] = js.ExecuteScript("return typeof window.orientation !== 'undefined'")
            };
            driver.ExecuteChromeCommand("Emulation.setDeviceMetricsOverride", metrics);
            driver.GetScreenshot().SaveAsFile(caminho + "//" + fileName, ScreenshotImageFormat.Png);
            driver.ExecuteChromeCommand("Emulation.clearDeviceMetricsOverride", new Dictionary<string, Object>());

        }

    }
}
