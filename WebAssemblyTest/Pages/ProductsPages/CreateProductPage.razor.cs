using Domain;
using Microsoft.AspNetCore.Components.Forms;
using WebAssemblyTest.Models;

namespace WebAssemblyTest.Pages.ProductsPages
{
	public partial class CreateProductPage
	{
		private ProductBlazorModel _product = new ProductBlazorModel();
		private List<ProductBlazorModel> _productList = new List<ProductBlazorModel>();
		private EditContext _editContext;
		private string[] _materials = { "træ", "plastik", "metal" };

		protected override void OnInitialized()
		{
			_editContext = new EditContext(_product);
			_product.Materiale = _materials[0];
		}

		private void HandleValidSubmit()
		{
			Product newProduct = new Product(_product.Name, 
											 _product.Price, 
											 _product.Description, 
											 _product.IsPublished, 
											 _product.PublishedDate);
			_productList.Add(_product);

			_product = new ProductBlazorModel();
			_editContext = new EditContext(_product);
		}

		private void HandleInvalidSubmit()
		{
			Console.WriteLine("HandleInvalidSubmit Called...");
		}

		private void ClearProducts()
		{
			_productList.Clear();
		}
	}
}

