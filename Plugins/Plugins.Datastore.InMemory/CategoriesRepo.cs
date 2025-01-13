using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.Datastore.InMemory
{
	public class CategoriesRepo:ICategoriesRepo
	{
		private readonly List<Category> _categories = new List<Category>()
		{
			new Category { Id = 1, Name = "Beverage", Description = "Various drinks" },
			new Category { Id = 2, Name = "Meat", Description = "Fresh meat products" },
			new Category { Id = 3, Name = "Bakery", Description = "Baked goods and bread" }
		};

		public  IEnumerable<Category> GetCategories()
		{
			return _categories; // Return a read-only collection for safety
		}

		public Category? GetCategoryById(int id)
		{
			return _categories.FirstOrDefault(c => c.Id == id);
		}

		public  void AddCategory(Category category)
		{
			if (category == null) throw new ArgumentNullException(nameof(category));
			category.Id = _categories.Count > 0 ? _categories.Max(c => c.Id) + 1 : 1;
			_categories.Add(category);
		}

		public  void UpdateCategory(Category category)
		{
			if (category == null) throw new ArgumentNullException(nameof(category));

			var categoryToUpdate = _categories.FirstOrDefault(c => c.Id == category.Id);
			if (categoryToUpdate != null)
			{
				categoryToUpdate.Name = category.Name;
				categoryToUpdate.Description = category.Description;
			}
		}

		public  void DeleteCategory(int categoryId)
		{
			var categoryToRemove = _categories.FirstOrDefault(c => c.Id == categoryId);
			if (categoryToRemove != null)
			{
				_categories.Remove(categoryToRemove);
			}
		}
	}
}
