using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using xUnitTest.MoqOpgaver.Opgave_2.TestClasses;

namespace xUnitTest.MoqOpgaver.Opgave_2.xUnitTest
{
	public class LoggerServiceTest
	{
		[Theory]
		[InlineData("")]
		[InlineData("Foo")]
		public void LogMessage_ShouldBeCalled_WhenGivenString(string message)
		{
			//Arrange
			Mock<ILogger> loggerMock = new Mock<ILogger>();

			//Act
			loggerMock.Object.LogMessage(message);

			//Assert
			loggerMock.Verify(log => log.LogMessage(message), Times.Once());
		}
	}
}
