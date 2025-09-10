using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShardLibrary.Models
{
	public class ShoppingItem
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Quantity { get; set; }
		public bool IHaveBought { get; set; }

		public ShoppingItem(int id, string name, int quantity, bool iHaveBought)
		{
			Id = id;
			Name = name;
			Quantity = quantity;
			IHaveBought = iHaveBought;
		}
	}
}
