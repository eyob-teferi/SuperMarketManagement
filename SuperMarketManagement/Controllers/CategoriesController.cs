using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Data;
using SuperMarketManagement.Models;

namespace SuperMarketManagement.Controllers
{
	public class CategoriesController : Controller
	{
		public IActionResult Index()
		{
			List<Category> categories = CategoriesRepo.GetCategories();

			return View(categories);
		}

		[HttpGet]
		public IActionResult Edit(int Id)
		{
			ViewBag.action = "edit";
			var category = CategoriesRepo.GetCategories().FirstOrDefault(C => C.Id == Id);
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
				CategoriesRepo.UpdateCategory(category);
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
				CategoriesRepo.Create(category);
				return RedirectToAction(nameof(Index));
			}
			return View(category);
		}

		public IActionResult Delete(int id)
		{
			if (id != null)
			{
				CategoriesRepo.DeleteCategory(id);
				return RedirectToAction(nameof(Index));
			}

			return View("Index");
		}
	}
}
