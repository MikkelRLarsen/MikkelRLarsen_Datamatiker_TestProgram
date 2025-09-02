using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using xUnitTest.MoqOpgaver.Opgave_6.TestClasses.DisplayClasses;

namespace xUnitTest.MoqOpgaver.Opgave_6.TestClasses
{
	public class EmailSender : IEmailSender
	{
		private readonly IDisplay _display;

		public EmailSender(IDisplay display)
		{
			_display = display;
		}

		public void Send(string message)
		{
			// Send Email code...

			// Display Email
			_display.DisplayMessage(message);
		}
	}
}
