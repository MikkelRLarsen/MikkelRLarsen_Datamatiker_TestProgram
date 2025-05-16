using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTest.ServiceLifeTimeTest.ScopedServiceFolder
{
	internal interface IScopedService
	{
		public Guid GetGuid();
	}
}
