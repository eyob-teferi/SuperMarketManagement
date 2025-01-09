using System.ComponentModel.DataAnnotations;
using SuperMarketManagement.Models;

namespace SuperMarketManagement.ViewModel
{
	public class CreateProductViewModel
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public int CategoryId { get; set; }
		[Required]
		public double Price { get; set; }
		[Required]
		public int Quantity { get; set; }

		public List<Category>? Categories { get; set; } // List of categories for the dropdown
	}
}
