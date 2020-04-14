using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeFramework.Exceptions
{
	public class NoParentInitialisedException : Exception
	{
		public NoParentInitialisedException(string messsage) : base(messsage) { }
	}
}
