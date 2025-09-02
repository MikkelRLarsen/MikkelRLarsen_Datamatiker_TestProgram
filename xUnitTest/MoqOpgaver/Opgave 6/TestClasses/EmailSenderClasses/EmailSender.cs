using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitTest.MoqOpgaver.Opgave_6.TestClasses
{
	public class EmailSender : IEmailSender
	{
		public void Send(string message)
		{
			Console.WriteLine(message);
		}
	}
}
