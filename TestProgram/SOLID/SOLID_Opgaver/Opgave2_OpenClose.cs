using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace TestProgram.SOLID.SOLID_Opgaver
{
	internal class Opgave2_OpenClose
	{
		private class Before
		{
			private class DiscountCalculator
			{
				public double GetDiscount(string customerType)
				{
					if (customerType == "Regular")

						return 10;

					else if (customerType == "Premium")

						return 20;

					else

						return 0;
				}
			}
		}


		private class After
		{
			private class DiscountCalculator
			{
				public double CalculateDiscount(ICustomerType cucustomerType)
				{
					return cucustomerType.GetDiscount();
				}
			}

			private interface ICustomerType
			{
				public int GetDiscount();
			}

			private class PrivateCustomer : ICustomerType
			{
				public int GetDiscount()
				{
					return 10;
				}
			}
			private class VIPCustomer : ICustomerType
			{
				public int GetDiscount()
				{
					return 60;
				}
			}
			private class VirksomhedCustomer : ICustomerType
			{
				public int GetDiscount()
				{
					return 30;
				}
			}
		}
	}
}
