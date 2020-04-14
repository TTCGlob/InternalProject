using OpenQA.Selenium;
using SeFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeFramework.PageObject
{
	public class ProductPage : BaseObject
	{
		private readonly string category;
		private By ProductBy(string product) => By.XPath($".//div[@class='product-item'][descendant::*[text()='{product}']]");
		private static ProductPage Instance { get; set; }
		protected override string Title => $"Demo Web Shop. {category}";
		protected ProductPage(IWebDriver driver, string category) : base(driver, null)
		{
			this.category = category;
		}

		public static ProductPage Get(IWebDriver driver, string product)
		{
			if (Instance == null) Instance = new ProductPage(driver, product);
			return Instance;
		}

		public ProductPage WithProduct(string product)
		{
			Parent = Driver.FindElement(ProductBy(product));
			return this;
		}

		[ChildControl]
		public enum ProductBox
		{
			[Control(ByType.ClassName, "product-title")]
			Title,
			[Control(ByType.TagName, "input")]
			AddToCart
		}

		public enum ViewControls
		{
			[Control(ByType.Id, "products-orderby")]
			SortBy,
			[Control(ByType.Id, "products-pagesize")]
			PageSize,
			[Control(ByType.Id, "products-viewmode")]
			ViewMode
		}
	}
}
