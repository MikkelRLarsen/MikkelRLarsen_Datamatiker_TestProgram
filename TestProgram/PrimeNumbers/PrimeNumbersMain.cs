using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram.PrimeNumbers
{
	internal class PrimeNumbersMain
	{
		public static void GeneratePrimenumbers(int maxNumber)
		{
			List<int> allPrimeNumbers = new List<int>();

			for (int i = 2; i < maxNumber; i++)
			{
				bool isItAPrimeNumber = true;
				foreach (int n in allPrimeNumbers)
				{
					if (i % n == 0)
					{
						isItAPrimeNumber = false;
						break;
					}
				}
				if (isItAPrimeNumber == true)
				{
					allPrimeNumbers.Add(i);
				}
			}

			foreach (int n in allPrimeNumbers)
			{
				Console.WriteLine(n);
			}
		}

		public static void FibonacciNumber(int number)
		{
			HashSet<int> fiboNumbers = new HashSet<int>();

			int currentFiboNumber1 = 0;
			int currentFiboNumber2 = 1;

			for (int i = 0; i < number; i++)
			{
				int newFiboNumber1 = currentFiboNumber1 + currentFiboNumber2;
				currentFiboNumber1 = currentFiboNumber2;
				currentFiboNumber2 = newFiboNumber1;
				fiboNumbers.Add(newFiboNumber1);
			}

			foreach(int n in fiboNumbers)
			{
				Console.WriteLine(n);
			}
		}
	}
}
