using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xUnitTest.MoqOpgaver.Opgave_4.TestClasses;

namespace xUnitTest.MoqOpgaver.Opgave_4.xUnitTest
{
	public class UserServiceTest
	{
		[Fact]
		public void PerformAction_ShouldCallLogger_WhenGivenUsernameAndAction()
		{
			// Arrange
			string username = "Admin";
			string action = "LogIn";
			string expectedLoggedMessage = "Admin performed LogIn";
			string? loggedMessageFromMock = null;

			//Mock<ILogger> logMock = new Mock<ILogger>();
			//logMock
			//	.Setup(log => log.Log(It.IsAny<string>()))
			//	.Callback<string>(loggedMessage => loggedMessageFromMock = loggedMessage);

			Mock<ILogger> logMock = new Mock<ILogger>();
			logMock
				.Setup(log => log.Log(It.IsAny<string>()))
				.Callback((string loggedMessage) => loggedMessageFromMock = loggedMessage);

			UserService userService = new UserService(logMock.Object);

			// Act
			userService.PerformAction(username, action);

			// Assert
			logMock.Verify(log => log.Log($"{username} performed {action}"), Times.Once);
			Assert.Equal(expectedLoggedMessage, loggedMessageFromMock);
		}
	}
}
