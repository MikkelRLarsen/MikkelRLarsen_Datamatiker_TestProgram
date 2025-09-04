using Microsoft.AspNetCore.Components;
using WebAssemblyTest.Models;

namespace WebAssemblyTest.SharedChildComponents
{
	public partial class ShowProductItem
	{
		[Parameter, EditorRequired]
		public ProductBlazorModel Product {  get; set; }
	}
}
