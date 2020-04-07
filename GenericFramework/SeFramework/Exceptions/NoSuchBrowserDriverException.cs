using System;

namespace SeFramework.Exceptions
{
	public class NoSuchBrowserDriverException : Exception
	{
		public NoSuchBrowserDriverException(string message) : base(message) { }
		public NoSuchBrowserDriverException() : base() { }
	}
}
