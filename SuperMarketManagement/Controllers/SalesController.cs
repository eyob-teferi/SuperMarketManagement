using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Data;
using SuperMarketManagement.ViewModel;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;
using UseCases.ProductUseCases;

namespace SuperMarketManagement.Controllers
{
	[Authorize(Policy = "Cashiers")]
	public class SalesController : Controller
	{
		private readonly IViewSelectedProductUseCase _viewSelectedProductUseCase;
		private readonly IAddTransactionUseCase _addTransactionUseCase;
		private readonly IEditProductUseCase _editProductUseCase;
		private readonly IViewCategoriesUseCase _viewCategoriesUseCase;
		private readonly IViewProductsByCategoryUseCase _viewProductsByCategoryUseCase;


		public SalesController(
			IViewSelectedProductUseCase viewSelectedProductUseCase,
			IAddTransactionUseCase addTransactionUseCase,
			IEditProductUseCase editProductUseCase,
			IViewCategoriesUseCase viewCategoriesUseCase,
			IViewProductsByCategoryUseCase viewProductsByCategoryUseCase)
		{
			_viewSelectedProductUseCase = viewSelectedProductUseCase;
			_addTransactionUseCase = addTransactionUseCase;
			_editProductUseCase = editProductUseCase;
			_viewCategoriesUseCase = viewCategoriesUseCase;
			_viewProductsByCategoryUseCase = viewProductsByCategoryUseCase;
		}
		public IActionResult Index()
		{
			var model = new SalesViewModel();
			model.Categories = _viewCategoriesUseCase.Execute();
			
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

				model.SelectedCategoryId = product.CategoryId;

			}

			model.SelectedCategoryId = _viewSelectedProductUseCase.Execute(model.SelectedProductId).CategoryId;
			model.Categories = _viewCategoriesUseCase.Execute();

			return View(nameof(Index),model);
		}

		public IActionResult ProductsByCategoryPartial(int Id)
		{
			var products = _viewProductsByCategoryUseCase.Execute(Id);
			return PartialView("_Products", products);
		}
	}
}
