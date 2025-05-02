using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram.SOLID_Open_Close
{
	internal class Customer
	{
		public string CustomerType { get; set; }
		public double DiscountAmount { get; set; }
		public int Alder { get; set; }

		public Customer(string customerType, double discountAmount)
		{
			CustomerType = customerType;
			DiscountAmount = CalculateDiscount();
		}

		public double CalculateDiscount()
		{
			return Alder * 0.5;
		}
	}
}
