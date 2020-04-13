using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeFramework.Core
{
	[AttributeUsage(AttributeTargets.Enum)]
	public class Parent : Control
	{
		public Parent(ByType byType, string byParam) : base(byType, byParam)
		{
		}
	}
}
