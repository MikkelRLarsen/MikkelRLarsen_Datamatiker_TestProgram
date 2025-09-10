using ShardLibrary.Models;

namespace BlazorServerTest.Client.Services
{
	public interface IShoppingService
	{
		Task<ShoppingItem[]?> GetAllItems();
		Task<ShoppingItem?> GetItem(int id);
		Task<int> AddItem(ShoppingItem item);
		Task<int> DeleteItem(int id);
		Task<int> updateItem(ShoppingItem item);
	}
}
