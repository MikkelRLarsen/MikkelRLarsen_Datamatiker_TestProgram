using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xUnitTest.MoqOpgaver.Opgave_6.TestClasses;
using xUnitTest.MoqOpgaver.Opgave_6.TestClasses.DisplayClasses;
using xUnitTest.MoqOpgaver.Opgave_6.TestClasses.NotificationClasses;

namespace xUnitTest.MoqOpgaver.Opgave_6.xUnitTest
{
	public class EmailSenderTest
	{
		[Fact]
		public void EmailSender_ShouldCallDisplay_WhenGivenMessageOnce()
		{
			// Act
			string expectedMessage = "Email Send";
			string? recievedMessage = null;

			Mock<IDisplay> displayMock = new Mock<IDisplay>();
			displayMock
				.Setup(display => display.DisplayMessage(It.IsAny<string>()))
				.Callback((string displayMessage) => recievedMessage = displayMessage);

			EmailSender emailSender = new EmailSender(displayMock.Object);

			// Act
			emailSender.Send(expectedMessage);

			// Assert
			displayMock.Verify(display => display.DisplayMessage(It.IsAny<string>()), Times.Once());
			Assert.Equal(expectedMessage, recievedMessage);
		}

		[Fact]
		public void EmailSender_ShouldCallDisplay_WhenGivenMultipleMessage()
		{
			// Arrange
			string[] expectedMessage = { "Email Send", "Email Send Again" };
			List<string> recievedMessage = new List<string>();

			Mock<IDisplay> displayMock = new Mock<IDisplay>();
			displayMock
				.Setup(display => display.DisplayMessage(It.IsAny<string>()))
				.Callback((string displayMessage) => recievedMessage.Add(displayMessage));

			EmailSender emailSender = new EmailSender(displayMock.Object);

			// Act
			for (int i = 0; i < expectedMessage.Length; i++)
			{
				emailSender.Send(expectedMessage[i]);
			}

			// Assert
			displayMock.Verify(display => display.DisplayMessage(It.IsAny<string>()), Times.Exactly(2));

			for (int i = 0; i < expectedMessage.Length; i++)
			{
				Assert.Equal(expectedMessage[i], recievedMessage[i]);
			}
		}
	}
}
