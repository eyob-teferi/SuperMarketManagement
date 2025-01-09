using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Data;
using SuperMarketManagement.Models;
using SuperMarketManagement.ViewModel;

namespace SuperMarketManagement.Controllers
{
	public class ProductsController : Controller
	{
		public IActionResult Index()
		{
			var products = ProductsRepo.GetProductsWithCategoryNames();
			return View(products);
		}

		public IActionResult Create()
		{
			var model = new CreateProductViewModel
			{
				Categories = CategoriesRepo.GetCategories() // Assuming this is your list of categories
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

				ProductsRepo.Create(newProduct);
				return RedirectToAction(nameof(Index));
			}

			product.Categories=CategoriesRepo.GetCategories();
			return View(product);
		}

		[HttpGet]
		public IActionResult Edit(int Id)
		{
			var product = ProductsRepo.GetProducts().FirstOrDefault(p => p.Id == Id);
			if (product != null)
			{
				var model = new CreateProductViewModel()
				{
					Name = product.Name,
					Quantity = product.Quantity,
					Price = product.Price,
					CategoryId = product.CategoryId,
					Categories = CategoriesRepo.GetCategories()
				};
				return View(model);
			}

			return NotFound();
		}

		[HttpPost]
		public IActionResult Edit(int Id,CreateProductViewModel model)
		{
			model.Categories=CategoriesRepo.GetCategories();
			if(ModelState.IsValid)
			{
				var product = new Product()
				{
					Name = model.Name,
					Quantity = model.Quantity,
					Price = model.Price,
					CategoryId = model.CategoryId,
					Id = Id
				};

				ProductsRepo.UpdateProduct(product);
				return RedirectToAction(nameof(Index));
			}

			return View(model);
		}

		[HttpPost]
		public IActionResult Delete(int Id)
		{
			if (Id != null)
			{
				ProductsRepo.DeleteProduct(Id);
				return RedirectToAction(nameof(Index));
			}

			return View(nameof(Index));
		}

		public IActionResult ProductsByCategoryPartial(int Id)
		{
			var products = ProductsRepo.GetProductsByCategory(Id);
			return PartialView("_Products", products);
		}

	
	}
}
