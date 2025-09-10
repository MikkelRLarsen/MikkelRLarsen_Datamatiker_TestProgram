using ShardLibrary.Models;
using System.Net.Http.Json;

namespace BlazorServerTest.Client.Services
{
	public class ShoppingService : IShoppingService
	{
		private readonly HttpClient httpClient;

		public ShoppingService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public Task<int> AddItem(ShoppingItem item)
		{
			throw new NotImplementedException();
		}

		public Task<int> DeleteItem(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<ShoppingItem[]?> GetAllItems()
		{
			var result = await httpClient.GetFromJsonAsync<ShoppingItem[]>("sample-data/shoppingdata.json");
			return result;
		}

		public Task<ShoppingItem?> GetItem(int id)
		{
			throw new NotImplementedException();
		}

		public Task<int> updateItem(ShoppingItem item)
		{
			throw new NotImplementedException();
		}
	}
}
