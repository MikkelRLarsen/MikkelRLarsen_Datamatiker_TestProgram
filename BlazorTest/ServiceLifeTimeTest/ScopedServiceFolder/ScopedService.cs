using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTest.ServiceLifeTimeTest.ScopedServiceFolder
{
	internal class ScopedService : IScopedService
	{
		private readonly Guid guid;

		public ScopedService()
		{
			guid = Guid.NewGuid();
		}

		public Guid GetGuid()
		{
			return guid;
		}
	}
}
