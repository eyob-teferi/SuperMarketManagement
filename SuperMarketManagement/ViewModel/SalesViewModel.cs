using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SuperMarketManagement.Data;
using CoreBusiness;
using SuperMarketManagement.ViewModel.Validation;

namespace SuperMarketManagement.ViewModel
{
	public class SalesViewModel
	{
		public int SelectedCategoryId { get; set; }
		public IEnumerable<Category>? Categories { get; set; }= Enumerable.Empty<Category>();
		[Required]
		public int  SelectedProductId { get; set; }

		[DisplayName("Quantity")]
		[Required]
	    [SalesViewModel_EnsureQuantityToSellAmount]
		public int QuantityToSell { get; set; }
	}
}
