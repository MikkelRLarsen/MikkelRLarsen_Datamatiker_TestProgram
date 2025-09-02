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
			if (Double.IsInfinity(Accumulator) || Double.IsNaN(Accumulator))
			{
				throw new ArgumentException("Accumulator is infinite or not a number");
			}
			return Accumulator;
		}

		public double Subtract(double a, double b)
		{
			Accumulator = a - b;
			if (Double.IsInfinity(Accumulator) || Double.IsNaN(Accumulator))
			{
				throw new ArgumentException("Accumulator is infinite or not a number");
			}
			return Accumulator;
		}
		public double Divide(double a, double b)
		{
			if (b == 0)
			{
				throw new ArgumentException("You cannot divide with 0");
			}
			Accumulator = a / b;

			if (Double.IsInfinity(Accumulator) || Double.IsNaN(Accumulator))
			{
				throw new ArgumentException("Accumulator is infinite or not a number");
			}

			return Accumulator;
		}
		public double Multiply(double a, double b)
		{
			Accumulator = a * b;

			if (Double.IsInfinity(Accumulator) || Double.IsNaN(Accumulator))
			{
				throw new ArgumentException("Accumulator is infinite or not a number");
			}

			return Accumulator;
		}
		public double Exp(double a, double b)
		{
			Accumulator = Math.Pow(a, b);

			if (Double.IsInfinity(Accumulator) || Double.IsNaN(Accumulator))
			{
				throw new ArgumentException("Accumulator is infinite or not a number");
			}

			return Accumulator;
		}
		public double fac(double a)
		{
			if (a < 0)
			{
				throw new ArgumentException("You cannot fac wtih negativ numbers");
			}
			Accumulator = a;

			for (double i = a-1; i > 1; i--)
			{
				if (Double.IsInfinity(Accumulator) || Double.IsNaN(Accumulator))
				{
					throw new ArgumentException("Accumulator is infinite or not a number");
				}
				Accumulator *= i;
			}


			return Accumulator;
		}
	}
}