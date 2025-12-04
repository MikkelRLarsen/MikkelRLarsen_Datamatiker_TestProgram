using Microsoft.EntityFrameworkCore;
using ShardLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShardLibrary.Repository
{
	public class ShoppingItemRepository : IShoppingItemRepository
	{
		private readonly ShoppingDBContext _dbContext;

		public ShoppingItemRepository(ShoppingDBContext dbContext)
		{
			_dbContext = dbContext;
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
			return await _dbContext.ShoppingItems.ToArrayAsync();
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
