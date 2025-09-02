using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitTest.MoqOpgaver.Opgave_4.TestClasses
{
	public class UserService
	{
		private readonly ILogger _logger;

		public UserService(ILogger logger)
		{
			_logger = logger;
		}

		public void PerformAction(string username, string action)
		{
			_logger.Log($"{username} performed {action}");
		}
	}
}
