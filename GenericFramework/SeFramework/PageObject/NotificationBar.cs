using OpenQA.Selenium;
using SeFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeFramework.PageObject
{
	public class NotificationBar : BaseObject
	{
		private static NotificationBar Instance { get; set; }
		private NotificationBar(IWebDriver driver, By iFrameId = null) : base(driver, iFrameId)
		{
		}

		public static NotificationBar Get(IWebDriver driver)
		{
			if (Instance == null) Instance = new NotificationBar(driver);
			return Instance;
		}

		protected override string Title => "";

		[Parent(ByType.Id, "bar-notification")]
		public enum Controls
		{
			[Control(ByType.ClassName, "content")]
			Text,
			[Control(ByType.ClassName, "close")]
			Close
		}
	}
}
