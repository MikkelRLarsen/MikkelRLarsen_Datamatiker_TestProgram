using ShardLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShardLibrary.Repository
{
	public interface IShoppingItemRepository
	{
		Task<ShoppingItem[]?> GetAllItems();
		Task<ShoppingItem?> GetItem(int id);
		Task<int> AddItem(ShoppingItem item);
		Task<int> DeleteItem(int id);
		Task<int> updateItem(ShoppingItem item);
	}
}
