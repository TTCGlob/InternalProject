using OpenQA.Selenium;
using SeFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeFramework.PageObject.Geordie
{
	public class ShoppingCart : BaseObject
	{
		private static ShoppingCart Instance { get; set; }
		private readonly By ProductRowby = By.ClassName("cart-item-row");
		private ShoppingCart(IWebDriver driver, By iFrameId = null) : base(driver, iFrameId)
		{
		}

		public static ShoppingCart Get(IWebDriver driver)
		{
			if (Instance == null) Instance = new ShoppingCart(driver);
			return Instance;
		}

		protected override string Title => "Demo Web Shop. Shopping Cart";

		public ShoppingCart WithProduct(int index)
		{
			Parent = Driver.FindElements(ProductRowby).ElementAt(index);
			return this;
		}

		[ChildControl]
		public enum ProductControls
		{
			[Control(ByType.Name, "removefromcart")]
			RemoveFromCart,
			[Control(ByType.ClassName, "product-name")]
			Name,
			[Control(ByType.ClassName, "product-unit-price")]
			Price,
			[Control(ByType.CssSelector, ".qty-input")]
			Quantity,
			[Control(ByType.ClassName, "product-subtotal")]
			Subtotal
		}

		public enum Controls
		{
			[Control(ByType.ClassName, "order-summary-content")]
			CartEmpty,
			[Control(ByType.Name, "updatecart")]
			UpdateCart
		}
	}
}
