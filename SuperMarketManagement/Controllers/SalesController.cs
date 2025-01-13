using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Data;
using SuperMarketManagement.ViewModel;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;
using UseCases.ProductUseCases;

namespace SuperMarketManagement.Controllers
{
	public class SalesController : Controller
	{
		private readonly IViewSelectedProductUseCase _viewSelectedProductUseCase;
		private readonly IAddTransactionUseCase _addTransactionUseCase;
		private readonly IEditProductUseCase _editProductUseCase;


		public SalesController(
			IViewSelectedProductUseCase viewSelectedProductUseCase,
			IAddTransactionUseCase addTransactionUseCase,
			IEditProductUseCase editProductUseCase)
		{
			_viewSelectedProductUseCase = viewSelectedProductUseCase;
			_addTransactionUseCase = addTransactionUseCase;
			_editProductUseCase = editProductUseCase;
		}
		public IActionResult Index()
		{
			var model = new SalesViewModel();
			
			return View(model);
		}

		public IActionResult SellProduct(int Id)
		{
			var product = _viewSelectedProductUseCase.Execute(Id);
			return PartialView("_SellProduct", product);
		}

		[HttpPost]
		public IActionResult Sell(SalesViewModel model)
		{
			if (ModelState.IsValid)
			{
				var product =_viewSelectedProductUseCase.Execute(model.SelectedProductId);
				if (product != null)
				{
					_addTransactionUseCase.Execute("Cashier1", product.Id, product.Name, product.Price, product.Quantity,
						model.QuantityToSell);

					product.Quantity -= model.QuantityToSell;
					_editProductUseCase.Execute(product);
				}
			}

			model.SelectedCategoryId = _viewSelectedProductUseCase.Execute(model.SelectedProductId).CategoryId;
			
			return View(nameof(Index),model);
		}
	}
}
