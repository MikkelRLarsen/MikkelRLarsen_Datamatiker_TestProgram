using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTest.ServiceLifeTimeTest.SingletongServiceFolder
{
	internal class SingletonService : ISingletonService
	{
		private readonly Guid guid;

		public SingletonService()
		{
			guid = Guid.NewGuid();
		}

		public Guid GetGuid()
		{
			return guid;
		}
	}
}
