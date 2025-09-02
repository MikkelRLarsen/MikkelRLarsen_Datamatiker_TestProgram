using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xUnitTest.MoqOpgaver.Opgave_5.TestClasses;

namespace xUnitTest.MoqOpgaver.Opgave_5.xUnitTest
{
	public class PaymentServiceTest
	{
		[Fact]
		public void TrackPayment_ShouldReturnPaymentStatusAndChangeForeachCall_WhenGivenValidPaymentID_DoneWithQue()
		{
			// Arrange
			Queue<string> paymentStatus = new Queue<string>(new[] { "Pending", "Processing", "Completed" });
			string[] returnedPaymentStatus = new string[paymentStatus.Count];

			Mock<IPaymentService> payServiceMock = new Mock<IPaymentService>();
			payServiceMock
				.Setup(payService => payService.GetPaymentStatus(It.IsAny<int>()))
				.Returns(() => paymentStatus.Dequeue());

			PaymentProcessor paymentProcessor = new PaymentProcessor(payServiceMock.Object);

			// Act
			returnedPaymentStatus[0] = paymentProcessor.TrackPayment(It.IsAny<int>());
			returnedPaymentStatus[1] = paymentProcessor.TrackPayment(It.IsAny<int>());
			returnedPaymentStatus[2] = paymentProcessor.TrackPayment(It.IsAny<int>());


			// Assert
			payServiceMock.Verify(payService => payService.GetPaymentStatus(It.IsAny<int>()), Times.Exactly(3));
			Assert.Equal("Pending", returnedPaymentStatus[0]);
			Assert.Equal("Processing", returnedPaymentStatus[1]);
			Assert.Equal("Completed", returnedPaymentStatus[2]);
		}

		[Fact]
		public void TrackPayment_ShouldReturnPaymentStatusAndChangeForeachCall_WhenGivenValidPaymentID_DoneWithSetupSequence()
		{
			// Arrange
			string[] returnedPaymentStatus = new string[3];

			Mock<IPaymentService> payServiceMock = new Mock<IPaymentService>();
			payServiceMock
				.SetupSequence(payService => payService.GetPaymentStatus(It.IsAny<int>()))
				.Returns("Pending")
				.Returns("Processing")
				.Returns("Completed");

			PaymentProcessor paymentProcessor = new PaymentProcessor(payServiceMock.Object);

			// Act
			returnedPaymentStatus[0] = paymentProcessor.TrackPayment(It.IsAny<int>());
			returnedPaymentStatus[1] = paymentProcessor.TrackPayment(It.IsAny<int>());
			returnedPaymentStatus[2] = paymentProcessor.TrackPayment(It.IsAny<int>());


			// Assert
			payServiceMock.Verify(payService => payService.GetPaymentStatus(It.IsAny<int>()), Times.Exactly(3));
			Assert.Equal("Pending", returnedPaymentStatus[0]);
			Assert.Equal("Processing", returnedPaymentStatus[1]);
			Assert.Equal("Completed", returnedPaymentStatus[2]);
		}
	}
}
