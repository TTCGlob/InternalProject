using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeFramework.Exceptions
{
	public class NoSuchBrowserDriverException : Exception
	{
		public NoSuchBrowserDriverException(string message) : base(message) { }
		public NoSuchBrowserDriverException() : base() { }
	}
}
