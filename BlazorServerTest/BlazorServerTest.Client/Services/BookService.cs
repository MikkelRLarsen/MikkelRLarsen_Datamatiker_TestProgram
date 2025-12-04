using ShardLibrary.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorServerTest.Client.Services
{
	public class BookService : IBookService
	{
		private readonly HttpClient _httpClient;

		public BookService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public Task<int> AddItem(Book item)
		{
			throw new NotImplementedException();
		}

		public Task<int> DeleteItem(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<Book[]?> GetAllItems()
		{
			var result = await _httpClient.GetFromJsonAsync<Book[]>("sample-data/bogdata.json");
			return result;
		}

		public Task<Book?> GetItem(int id)
		{
			throw new NotImplementedException();
		}

		public Task<int> updateItem(Book item)
		{
			throw new NotImplementedException();
		}
	}
}
