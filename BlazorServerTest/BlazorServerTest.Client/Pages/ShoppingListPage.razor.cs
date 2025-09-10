using BlazorServerTest.Client.Services;
using Microsoft.AspNetCore.Components;
using ShardLibrary.Models;

namespace BlazorServerTest.Client.Pages
{
	public partial class ShoppingListPage
	{
		[Inject]
		public IShoppingService Service { get; set; }

		private List<ShoppingItem> _items = new List<ShoppingItem>();

		protected override async Task OnInitializedAsync()
		{
			_items = (await Service.GetAllItems()).ToList();
		}
	}
}
