using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using xUnitTest.MoqOpgaver.Opgave_3.TestClasses;

namespace xUnitTest.MoqOpgaver.Opgave_3.xUnitTest
{
	public class AccountManagerTest
	{
		[Theory]
		[InlineData(100, 1000)]
		[InlineData(0, 1000)]
		[InlineData(100, 101)]
		[InlineData(100, 100)]
		[InlineData(-100, 100)]
		public void CanWithdraw_ShouldReturnTrue_WhenGivenWithdrawAmountLessThanBalance(decimal withdrawAmount, decimal balance)
		{
			// Arrange
			int accountId = 1;
			Mock<IBankService> bankServiceMock = new Mock<IBankService>();
			bankServiceMock.Setup(bankService => bankService.GetBalance(accountId)).Returns(balance);

			AccountManager accountManager = new AccountManager(bankServiceMock.Object);

			// Act
			bool canAmountBeWithdrawn =  accountManager.CanWithdraw(accountId, withdrawAmount);

			// Assert
			Assert.True(canAmountBeWithdrawn);
		}

		[Theory]
		[InlineData(1000, 100)]
		[InlineData(100, 0)]
		[InlineData(101, 100)]
		[InlineData(100, -100)]
		public void CanWithdraw_ShouldThrowInvalidOperationException_WhenGivenWithdrawAmountGreaterThanBalance(decimal withdrawAmount, decimal balance)
		{
			// Arrange
			int accountId = 1;
			Mock<IBankService> bankServiceMock = new Mock<IBankService>();
			bankServiceMock.Setup(bankService => bankService.GetBalance(accountId)).Returns(balance);

			AccountManager accountManager = new AccountManager(bankServiceMock.Object);

			// Act + Assert
			Assert.Throws<InvalidOperationException>(
				() => accountManager.CanWithdraw(accountId, withdrawAmount));
		}
	}
}
