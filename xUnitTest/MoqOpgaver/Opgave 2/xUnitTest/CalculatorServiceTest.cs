using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using xUnitTest.MoqOpgaver.Opgave_2.TestClasses;

namespace xUnitTest.MoqOpgaver.Opgave_2.xUnitTest
{
	public class CalculatorServiceTest
	{
		[Theory]
		[InlineData(1, 1, 2)]
		[InlineData(-1, -1, -2)]
		[InlineData(-1, 1, 0)]
		public void Add_ShouldReturnCorrectly_WhenGivenTwoInts(int number1, int number2, int expected)
		{
			//Arrange
			Mock<ICalculatorService> calculatorMock = new Mock<ICalculatorService>();
			calculatorMock.Setup(calc => calc.Add(number1, number2)).Returns(expected);

			//Act
			int returnedNumber = calculatorMock.Object.Add(number1, number2);

			//Assert
			Assert.Equal(expected, returnedNumber);
		}

		[Theory]
		[InlineData(2, 2, 4)]
		[InlineData(-2, -2, 4)]
		[InlineData(-2, 2, -4)]
		public void Multiply_ShouldReturnCorrectly_WhenGivenTwoInts(int number1, int number2, int expected)
		{
			//Arrange
			Mock<ICalculatorService> calculatorMock = new Mock<ICalculatorService>();
			calculatorMock.Setup(calc => calc.Multiply(number1, number2)).Returns(expected);

			//Act
			int returnedNumber = calculatorMock.Object.Multiply(number1, number2);

			//Assert
			Assert.Equal(expected, returnedNumber);
		}
	}
}
