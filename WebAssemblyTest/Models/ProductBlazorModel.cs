using System.ComponentModel.DataAnnotations;

namespace WebAssemblyTest.Models
{
	public class ProductBlazorModel
	{
		[Required]
		[StringLength(50, ErrorMessage = "Name must be less than 50 characters.")]
		public string Name { get; set; }
		public decimal Price { get; set; }
		public string Description { get; set; }
		public bool IsPublished { get; set; }
		public DateTime PublishedDate { get; set; } = DateTime.UtcNow;
		public string Materiale {  get; set; }

		public override string ToString()
		{
			return $"{Name} koster {Price} lavet i {Materiale}. {Description}";
		}
	}
}
