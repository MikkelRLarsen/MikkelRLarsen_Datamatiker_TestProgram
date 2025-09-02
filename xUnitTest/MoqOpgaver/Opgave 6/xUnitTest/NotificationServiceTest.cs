using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xUnitTest.MoqOpgaver.Opgave_4.TestClasses;
using xUnitTest.MoqOpgaver.Opgave_6.TestClasses;
using xUnitTest.MoqOpgaver.Opgave_6.TestClasses.NotificationClasses;

namespace xUnitTest.MoqOpgaver.Opgave_6.xUnitTest
{
	public class NotificationServiceTest
	{
		[Fact]
		public void Notify_ShouldCallEmailService_WhenGivenMessageOnce()
		{
			// Act
			string expectedMessage = "Email Send";
			string? recievedMessage = null;

			Mock<IEmailSender> emailMock = new Mock<IEmailSender>();
			emailMock
				.Setup(email => email.Send(It.IsAny<string>()))
				.Callback((string email) => recievedMessage = email);

			NotificationService notificationService = new NotificationService(emailMock.Object);

			// Act
			notificationService.Notify(expectedMessage);

			// Assert
			emailMock.Verify(email => email.Send(It.IsAny<string>()), Times.Once());
			Assert.Equal(expectedMessage, recievedMessage);
		}

		[Fact]
		public void Notify_ShouldCallEmailService_WhenGivenMultipleMessage()
		{
			// Arrange
			string[] expectedMessage = { "Email Send", "Email Send Again" };
			List<string> recievedMessage = new List<string>();

			Mock<IEmailSender> emailMock = new Mock<IEmailSender>();
			emailMock
				.Setup(email => email.Send(It.IsAny<string>()))
				.Callback((string email) => recievedMessage.Add(email));

			NotificationService notificationService = new NotificationService(emailMock.Object);

			// Act
			for (int i = 0; i < expectedMessage.Length; i++)
			{
				notificationService.Notify(expectedMessage[i]);
			}

			// Assert
			emailMock.Verify(email => email.Send(It.IsAny<string>()), Times.Exactly(2));

			for (int i = 0; i < expectedMessage.Length; i++)
			{
				Assert.Equal(expectedMessage[i], recievedMessage[i]);
			}
		}
	}
}
