using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Data;
using SuperMarketManagement.Models;
using UseCases.Interfaces;
using CoreBusiness;
using Microsoft.AspNetCore.Authorization;
using Category = CoreBusiness.Category;


namespace SuperMarketManagement.Controllers
{
	[Authorize(Policy = "Inventory")]
	public class CategoriesController : Controller
	{
		private readonly IViewCategoriesUseCase _viewCategoriesUseCase;
		private readonly IAddCategoryUseCase _addCategoryUseCase;
		private readonly IDeleteCategoryUseCase _deleteCategoryUseCase;
		private readonly IEditCategoryUseCase _editCategoryUseCase;
		private readonly IViewSelectedCategoryUseCase _viewSelectedCategoryUseCase;

		public CategoriesController(
			IViewCategoriesUseCase ViewCategoriesUseCase, 
			IAddCategoryUseCase AddCategoryUseCase,
			IDeleteCategoryUseCase DeleteCategoryUseCase,
			IEditCategoryUseCase EditCategoryUseCase,
			IViewSelectedCategoryUseCase ViewSelectedCategoryUseCase
			)
		{
			_viewCategoriesUseCase = ViewCategoriesUseCase;
			_addCategoryUseCase = AddCategoryUseCase;
			_deleteCategoryUseCase = DeleteCategoryUseCase;
			_editCategoryUseCase = EditCategoryUseCase;
			_viewSelectedCategoryUseCase = ViewSelectedCategoryUseCase;
		}
		public IActionResult Index()
		{
			var categories = _viewCategoriesUseCase.Execute();

			return View(categories);
		}

		[HttpGet]
		public IActionResult Edit(int Id)
		{
			ViewBag.action = "edit";
			var category = _viewSelectedCategoryUseCase.Execute(Id);
			if (category != null)
			{
				return View(category);
			}

			return NotFound();
		}


		[HttpPost]
		public IActionResult Edit(Category category)
		{
			if (ModelState.IsValid)
			{
				_editCategoryUseCase.Execute(category);
				return RedirectToAction(nameof(Index));
			}

			return View(category);
		}

		[HttpGet]
		public IActionResult Create()
		{
			ViewBag.action = "create";
			return View();
		}

		[HttpPost]
		public IActionResult Create(Category category)
		{
			if (ModelState.IsValid)
			{
				_addCategoryUseCase.Execute(category);
				return RedirectToAction(nameof(Index));
			}
			return View(category);
		}

		public IActionResult Delete(int id)
		{
			if (id != null)
			{
				_deleteCategoryUseCase.Execute(id);
				return RedirectToAction(nameof(Index));
			}

			return View("Index");
		}
	}
}
