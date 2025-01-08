using SuperMarketManagement.Data;
using SuperMarketManagement.Models;

namespace SuperMarketManagement.ViewModel
{
	public class SalesViewModel
	{
		public int SelectedCategoryId { get; set; }
		public List<Category> Categories { get; set; } = CategoriesRepo.GetCategories();
	}
}
