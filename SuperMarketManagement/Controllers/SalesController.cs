using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Data;
using SuperMarketManagement.ViewModel;

namespace SuperMarketManagement.Controllers
{
	public class SalesController : Controller
	{
		public IActionResult Index()
		{
			var model = new SalesViewModel();
			
			return View(model);
		}

		public IActionResult SellProduct(int Id)
		{
			var product = ProductsRepo.GetProductById(Id);
			return PartialView("_SellProduct", product);
		}

		public IActionResult Sell(SalesViewModel model)
		{
			if (ModelState.IsValid)
			{
				var product = ProductsRepo.GetProductById(model.SelectedProductId);
				if (product != null)
				{
					TransactionRepo.Add("Cashier1", product.Id, product.Name, product.Price, product.Quantity,
						model.QuantityToSell);

					product.Quantity -= model.QuantityToSell;
					ProductsRepo.UpdateProduct(product);
				}
			}

			model.SelectedCategoryId = ProductsRepo.GetProductById(model.SelectedProductId).CategoryId;
			
			return View(nameof(Index),model);
		}
	}
}
