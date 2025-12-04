using ShardLibrary.Models;

namespace BlazorServerTest.Client.Services
{
	public interface IBookService
	{
		Task<Book[]?> GetAllItems();
		Task<Book?> GetItem(int id);
		Task<int> AddItem(Book item);
		Task<int> DeleteItem(int id);
		Task<int> updateItem(Book item);
	}
}
