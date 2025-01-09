using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SuperMarketManagement.Data;
using SuperMarketManagement.Models;
using SuperMarketManagement.ViewModel.Validation;

namespace SuperMarketManagement.ViewModel
{
	public class SalesViewModel
	{
		public int SelectedCategoryId { get; set; }
		public List<Category> Categories { get; set; } = CategoriesRepo.GetCategories();
		[Required]
		public int  SelectedProductId { get; set; }

		[DisplayName("Quantity")]
		[Required]
		[SalesViewModel_EnsureQuantityToSellAmount]
		public int QuantityToSell { get; set; }
	}
}
