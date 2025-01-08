using SuperMarketManagement.Models;

namespace SuperMarketManagement.Data
{
	public static class CategoriesRepo
	{
		private static List<Category> _categories = new List<Category>()
		{
			new Category { Id = 1, Name = "Beverage", Description = "Various drinks" },
			new Category { Id = 2, Name = "Meat", Description = "Fresh meat products" },
			new Category { Id = 3, Name = "Bakery", Description = "Baked goods and bread" }
		};

		public static List<Category> GetCategories()
		{
			return _categories; // Return a read-only collection for safety
		}

		public static void Create(Category category)
		{
			if (category == null) throw new ArgumentNullException(nameof(category));
			category.Id = _categories.Count > 0 ? _categories.Max(c => c.Id) + 1 : 1;
			_categories.Add(category);
		}

		public static void UpdateCategory(Category category)
		{
			if (category == null) throw new ArgumentNullException(nameof(category));

			var categoryToUpdate = _categories.FirstOrDefault(c => c.Id == category.Id);
			if (categoryToUpdate != null)
			{
				categoryToUpdate.Name = category.Name;
				categoryToUpdate.Description = category.Description;
			}
		}

		public static void DeleteCategory(int categoryId)
		{
			var categoryToRemove = _categories.FirstOrDefault(c => c.Id == categoryId);
			if (categoryToRemove != null)
			{
				_categories.Remove(categoryToRemove);
			}
		}
	}
}
