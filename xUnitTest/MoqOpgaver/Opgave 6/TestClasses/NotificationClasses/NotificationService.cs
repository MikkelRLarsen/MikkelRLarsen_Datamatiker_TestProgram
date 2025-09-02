using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitTest.MoqOpgaver.Opgave_6.TestClasses.NotificationClasses
{
	public class NotificationService : INotificationService
	{
		private readonly IEmailSender _emailSender;

		public NotificationService(IEmailSender emailSender)
		{
			_emailSender = emailSender;
		}

		public void Notify(string message)
		{
			_emailSender.Send(message);
		}
	}
}
