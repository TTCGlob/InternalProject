using OpenQA.Selenium;
using SeFramework.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeFramework.PageObject
{
	public class ProductCategoryLinks : BaseObject
	{
		private static ProductCategoryLinks Instance { get; set; }
		private ProductCategoryLinks(IWebDriver driver, By iFrameId = null) : base(driver, iFrameId)
		{
		}

		public static ProductCategoryLinks Get(IWebDriver driver)
		{
			if (Instance == null) Instance = new ProductCategoryLinks(driver);
			return Instance;
		}

		protected override string Title => "Demo Web Shop";

		public Categories this[string key]
		{
			get
			{
				TextInfo info = CultureInfo.CurrentCulture.TextInfo;
				var pascalKey = info.ToTitleCase(key).Replace(" ", string.Empty);
				return (Categories)Enum.Parse(typeof(Categories), pascalKey);
			}
		}

		[Parent(ByType.ClassName, "top-menu")]
		public enum Categories
		{	
			[Control(ByType.LinkText, "BOOKS")]
			Books,
			[Control(ByType.LinkText, "COMPUTERS")]
			Computers,
			[Control(ByType.LinkText, "ELECTRONICS")]
			Electronics,
			[Control(ByType.LinkText, "APPAREL & SHOES")]
			ApparelAndShoes,
			[Control(ByType.LinkText, "DIGITAL DOWNLOADS")]
			DigitalDownloads,
			[Control(ByType.LinkText, "JEWELERY")]
			Jewelery,
			[Control(ByType.LinkText, "GIFT CARDS")]
			GiftCards
		}
	}
}
