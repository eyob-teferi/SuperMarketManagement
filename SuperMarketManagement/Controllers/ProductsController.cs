using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Data;
using CoreBusiness;
using SuperMarketManagement.ViewModel;
using UseCases.Interfaces;
using UseCases.ProductUseCases;
using Microsoft.AspNetCore.Authorization;

namespace SuperMarketManagement.Controllers
{
	[Authorize(Policy = "Inventory")]
	public class ProductsController : Controller
	{
		private readonly IViewProductsUseCase _viewProductsUseCase;
		private readonly IViewCategoriesUseCase _viewCategoriesUseCase;
		private readonly IAddProductUseCase _addProductUseCase;
		private readonly IDeleteProductUseCase _deleteProductUseCase;
		private readonly IEditProductUseCase _editProductUseCase;
		private readonly IViewSelectedProductUseCase _viewSelectedProductUseCase;

		public ProductsController(
			IViewProductsUseCase viewProductsUseCase,
			IViewCategoriesUseCase viewCategoriesUseCase,
			IAddProductUseCase addProductUseCase,
			IDeleteProductUseCase deleteProductUseCase,
			IEditProductUseCase editProductUseCase,
			IViewSelectedProductUseCase viewSelectedProductUseCase
			)
		{
			_viewProductsUseCase = viewProductsUseCase;
			_viewCategoriesUseCase = viewCategoriesUseCase;
			_addProductUseCase = addProductUseCase;
			_deleteProductUseCase = deleteProductUseCase;
			_editProductUseCase = editProductUseCase;
			_viewSelectedProductUseCase = viewSelectedProductUseCase;
		}
		public IActionResult Index()
		{
			var products = _viewProductsUseCase.Execute(loadCategory:true);
			return View(products);
		}

		public IActionResult Create()
		{
			var model = new CreateProductViewModel
			{
				Categories = _viewCategoriesUseCase.Execute()// Assuming this is your list of categories
			};
			return View(model);
			
		}

		[HttpPost]
		public IActionResult Create([FromForm] CreateProductViewModel product)
		{
			if (ModelState.IsValid)
			{
				var newProduct = new Product()
				{
					Name = product.Name,
					Quantity = product.Quantity,
					Price = product.Price,
					CategoryId = product.CategoryId
				};

				_addProductUseCase.Execute(newProduct);
				return RedirectToAction(nameof(Index));
			}

			product.Categories= _viewCategoriesUseCase.Execute();
			return View(product);
		}

		[HttpGet]
		public IActionResult Edit(int Id)
		{
			var product = _viewProductsUseCase.Execute().FirstOrDefault(p => p.Id == Id);
			if (product != null)
			{
				var model = new CreateProductViewModel()
				{
					Name = product.Name,
					Quantity = product.Quantity,
					Price = product.Price,
					CategoryId = product.CategoryId,
					Categories = _viewCategoriesUseCase.Execute()
				};
				return View(model);
			}

			return NotFound();
		}

		[HttpPost]
		public IActionResult Edit(int Id,CreateProductViewModel model)
		{
			model.Categories= _viewCategoriesUseCase.Execute();
			if (ModelState.IsValid)
			{
				var product = new Product()
				{
					Name = model.Name,
					Quantity = model.Quantity,
					Price = model.Price,
					CategoryId = model.CategoryId,
					Id = Id
				};

				_editProductUseCase.Execute(product);
				return RedirectToAction(nameof(Index));
			}

			return View(model);
		}

		[HttpPost]
		public IActionResult Delete(int Id)
		{
			if (Id != null)
			{
				_deleteProductUseCase.Execute(Id);
				return RedirectToAction(nameof(Index));
			}

			return View(nameof(Index));
		}

		

	
	}
}
