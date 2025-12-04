using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShardLibrary.Repository;

namespace BlazorServerTest.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShoppingItemController : ControllerBase
	{
		private readonly IShoppingItemRepository _shoppingItemRepository;

		public ShoppingItemController(IShoppingItemRepository shoppingItemRepository)
		{
			_shoppingItemRepository = shoppingItemRepository;
		}

		[HttpGet]
		public async Task<IActionResult?> GetItems()
		{
			try
			{
				var items = await _shoppingItemRepository.GetAllItems();
				return Ok(items);
			}
			catch (Exception ex)
			{
				// Returner fejlbesked for debugging
				return StatusCode(500, new { message = ex.Message, stack = ex.StackTrace });
			}
		}
	}
}
