using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTest.ServiceLifeTimeTest.TransientServiceFolder
{
	internal class TransientService : ITransientService
	{
		private readonly Guid guid;

		public TransientService()
		{
			guid = Guid.NewGuid();
		}

		public Guid GetGuid()
		{
			return guid;
		}
	}
}
