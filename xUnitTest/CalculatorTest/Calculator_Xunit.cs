using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitTest.CalculatorTest
{
	public class Calculator_Xunit
	{
		[Theory]
		[InlineData(1, 1, 2)]
		[InlineData(0, 0, 0)]
		[InlineData(0, 1, 1)]
		[InlineData(-1, 1, 0)]
		[InlineData(-1, -1, -2)]
		public void Add(double number1, double number2, double expected)
		{
			// Arrange
			Calculator calculator = new Calculator();

			// Act
			calculator.Add(number1, number2);

			// Assert
			Assert.Equal(calculator.Accumulator, expected);
		}

		[Fact]
		public void Clear()
		{
			// Arrange
			Calculator calculator = new Calculator();
			calculator.Add(100, 100);

			// Act
			calculator.Clear();

			// Assert
			Assert.Equal(0, calculator.Accumulator);
		}

		[Theory]
		[InlineData(1, 1, 0)]
		[InlineData(0, 0, 0)]
		[InlineData(100, 0, 100)]
		[InlineData(0, 1, -1)]
		[InlineData(-1, 1, 0)]
		[InlineData(-1, -1, 2)]
		public void Subtract(double number1, double number2, double expected)
		{
			// Arrange
			Calculator calculator = new Calculator();

			// Act
			calculator.Subtract(number1, number2);

			// Assert
			Assert.Equal(calculator.Accumulator, expected);
		}

		[Theory]
		[InlineData(1, 1, 1)]
		[InlineData(0, 0, 0)]
		[InlineData(100, 0, 0)]
		[InlineData(0, 1, 0)]
		[InlineData(-1, 1, -1)]
		[InlineData(-1, -1, 1)]
		public void Divide(double number1, double number2, double expected)
		{
			// Arrange
			Calculator calculator = new Calculator();

			// Act
			calculator.Divide(number1, number2);

			// Assert
			Assert.Equal(calculator.Accumulator, expected);
		}

		// Multiply, Exp, Fac
		[Theory]
		[InlineData(1, 1, 1)]
		[InlineData(0, 0, 0)]
		[InlineData(100, 0, 0)]
		[InlineData(0, 1, 0)]
		[InlineData(-1, 1, -1)]
		[InlineData(-1, -1, 1)]
		public void Multiply(double number1, double number2, double expected)
		{
			// Arrange
			Calculator calculator = new Calculator();

			// Act
			calculator.Divide(number1, number2);

			// Assert
			Assert.Equal(calculator.Accumulator, expected);
		}
	}
}
