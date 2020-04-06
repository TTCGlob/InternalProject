using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeFramework.ExtensionResources
{
	public static class SeleniumExtensions
	{
		/// <summary>
		/// Overload method that waits and then returns the requested element.
		/// </summary>
		/// <param name="driver">The current webdriver.</param>
		/// <param name="parent">An (optional) parent element to search through.</param>
		/// <param name="by">The locator to find the element</param>
		/// <param name="timeout">Amount of time before throwing a NoSuchElementException.</param>
		/// <returns>The requested IWebElement.</returns>
		public static IWebElement WaitThenFindElement(this IWebDriver driver, IWebElement parent, By by, TimeSpan timeout)
		{
			var wait = new WebDriverWait(driver, timeout);
			return wait.Until(FindElement(by, parent));
		}

		public static IWebElement WaitThenFindElement(this IWebDriver driver, By by, TimeSpan timeout) => WaitThenFindElement(driver, null, by, timeout);

		private static Func<IWebDriver, IWebElement> FindElement(By locator, IWebElement parent = null)
		{
			return (IWebDriver driver) =>
			{
				if (parent is IWebElement) return parent.FindElement(locator);
				return driver.FindElement(locator);
			};
		}
	}
}
