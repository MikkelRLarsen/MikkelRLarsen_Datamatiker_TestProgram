using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitTest.CalculatorTest
{
	public class Calculator
	{
		public double Accumulator { get; private set; } = 0;
		public Calculator()
		{
			Accumulator = 0;
		}

		public void Clear()
		{
			Accumulator = 0;
		}
		public double Add(double a, double b)
		{
			Accumulator = a + b;
			return a + b;
		}

		public double Subtract(double a, double b)
		{
			Accumulator = a - b;
			return Accumulator;
		}
		public double Divide(double a, double b)
		{
			if (b == 0)
			{
				Accumulator = 0;
			}
			else
			{
				Accumulator = a / b;
			}
			return Accumulator;
		}
		public double Multiply(double a, double b)
		{
			Accumulator = a * b;
			return Accumulator;
		}
		public double Exp(double a, double b)
		{
			Accumulator = Math.Pow(a, b);
			return Accumulator;
		}
		public double fac(double a)
		{
			Accumulator = a;

			for (double i = a-1; i > 1; i--)
			{
				Accumulator *= i;
			}

			return Accumulator;
		}
	}
}