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
		public void Add_Should_Expect_True(double number1, double number2, double expected)
		{
			// Arrange
			Calculator calculator = new Calculator();

			// Act
			calculator.Add(number1, number2);

			// Assert
			Assert.Equal(expected, calculator.Accumulator);
		}

		[Fact]
		public void Clear_Should_Expect_True()
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
		[InlineData(-1, 1, -2)]
		[InlineData(-1, -1, 0)]
		public void Subtract_Should_Expect_True(double number1, double number2, double expected)
		{
			// Arrange
			Calculator calculator = new Calculator();

			// Act
			calculator.Subtract(number1, number2);

			// Assert
			Assert.Equal(expected, calculator.Accumulator);
		}

		[Theory]
		[InlineData(1, 1, 1)]
		[InlineData(0, 1, 0)]
		[InlineData(-1, 1, -1)]
		[InlineData(-1, -1, 1)]
		public void Divide_Should_Expect_True(double number1, double number2, double expected)
		{
			// Arrange
			Calculator calculator = new Calculator();

			// Act
			calculator.Divide(number1, number2);

			// Assert
			Assert.Equal(expected, calculator.Accumulator);
		}
		[Fact]
		public void Divide_With_Zero_Should_Throw_Exception()
		{
			// Arrange 
			Calculator calculator = new Calculator();

			// Act + Assert
			Assert.Throws<ArgumentException>(
				() => calculator.Divide(100, 0));
		}

		[Theory]
		[InlineData(1, 1, 1)]
		[InlineData(0, 0, 0)]
		[InlineData(100, 0, 0)]
		[InlineData(0, 1, 0)]
		[InlineData(-1, 1, -1)]
		[InlineData(-1, -1, 1)]
		public void Multiply_Should_Expect_True(double number1, double number2, double expected)
		{
			// Arrange
			Calculator calculator = new Calculator();

			// Act
			calculator.Multiply(number1, number2);

			// Assert
			Assert.Equal(expected, calculator.Accumulator);
		}

		[Theory]
		[InlineData(1, 1, 1)]
		[InlineData(0, 0, 1)]
		[InlineData(100, 0, 1)]
		[InlineData(0, 1, 0)]
		[InlineData(-1, 2, 1)]
		[InlineData(-1, 3, -1)]
		[InlineData(-2, -2, 0.25)]
		[InlineData(2, -2, 0.25)]
		public void Exp_Should_Expect_True(double number1, double number2, double expected)
		{
			// Arrange
			Calculator calculator = new Calculator();

			// Act
			calculator.Exp(number1, number2);

			// Assert
			Assert.Equal(expected, calculator.Accumulator);
		}

		[Theory]
		[InlineData(1, 1)]
		[InlineData(0, 0)]
		[InlineData(5, 120)]
		public void Fac_Should_Expect_True(double number1, double expected)
		{
			// Arrange
			Calculator calculator = new Calculator();

			// Act
			calculator.fac(number1);

			// Assert
			Assert.Equal(expected, calculator.Accumulator);
		}
		[Fact]
		public void Fac_With_Zero_Should_Throw_Exception()
		{
			// Arrange 
			Calculator calculator = new Calculator();

			// Act + Assert
			Assert.Throws<ArgumentException>(
				() => calculator.fac(-100));
		}
	}
}
