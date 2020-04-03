using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeFramework.Config;
using SeFramework.Constant.Framework;
using SeFramework.Exceptions;

namespace SeFramework.Hooks.GeneralHook
{
	internal static class InitialisationActions
	{
		private static ConfigReader reader;
		internal static ConfigReader GetConfigReader()
		{
			if (!(reader is ConfigReader))
				reader = new ConfigReader();
			return reader;
		}

		internal static IWebDriver InitialiseDriver()
		{
			IWebDriver driver;
			switch (GetConfigReader().Browser)
			{
				case BrowserType.Chrome:
					driver = new ChromeDriver(GetChromeOptions());
					break;
				case BrowserType.Firefox:
					driver = new FirefoxDriver(GetFirefoxOptions());
					break;
				default:
					throw new NoSuchBrowserDriverException($"The driver {GetConfigReader().Browser} has no suitable driver.");
			}
			driver.Manage().Window.Maximize();
			return driver;
		}

		private static ChromeOptions GetChromeOptions()
		{
			var options = new ChromeOptions();
			options.AddArgument("start-maximized");
			if (GetConfigReader().Headless)
				options.AddArgument("--headless");
			return options;
		}

		private static FirefoxOptions GetFirefoxOptions()
		{
			var options = new FirefoxOptions();
			if (GetConfigReader().Headless)
				options.AddArgument("-headless");
			return options;
		}
	}
}
