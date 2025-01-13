using System.ComponentModel.DataAnnotations;
using CoreBusiness;


namespace SuperMarketManagement.ViewModel
{
	public class CreateProductViewModel
	{
		[Required]
		public string Name { get; set; }
		[Required]

		[Display(Name = "Category")]
		public int CategoryId { get; set; }
		[Required]
		public double Price { get; set; }
		[Required]
		public int Quantity { get; set; }

		public IEnumerable<Category>? Categories { get; set; } // List of categories for the dropdown
	}
}
