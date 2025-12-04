using BlazorServerTest.Client.Services;
using Microsoft.AspNetCore.Components;
using ShardLibrary.Models;

namespace BlazorServerTest.Client.Pages
{
	public partial class BookPage
	{
		[Inject]
		public IBookService Service { get; set; }

		private List<Book> _items = new List<Book>();

		protected override async Task OnInitializedAsync()
		{
			_items = (await Service.GetAllItems()).ToList();
		}
	}
}
