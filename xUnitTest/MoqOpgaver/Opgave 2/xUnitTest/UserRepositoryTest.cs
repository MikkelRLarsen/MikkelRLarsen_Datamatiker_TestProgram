using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using xUnitTest.MoqOpgaver.Opgave_2.TestClasses;

namespace xUnitTest.MoqOpgaver.Opgave_2.xUnitTest
{
	public class UserRepositoryTest
	{
		[Theory]
		[InlineData(1, "Admin")]
		[InlineData(2, "Public User")]
		public void GetUserRole_ShouldReturnCorrectUserRole_WhenGivenUserID(int userId, string exceptedUserRole)
		{
			// Arrange
			Mock<IUserRepository> repoMock = new Mock<IUserRepository>();
			repoMock.Setup(repo => repo.GetUserRole(userId)).Returns(exceptedUserRole);

			// Act
			string userRole = repoMock.Object.GetUserRole(userId);

			// Assert
			Assert.Equal(exceptedUserRole, userRole);
		}
	}
}
