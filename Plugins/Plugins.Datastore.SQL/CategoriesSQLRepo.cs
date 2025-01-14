using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.Datastore.SQL
{
	public class CategoriesSQLRepo:ICategoriesRepo
	{
		private readonly MarketContext _db;
		public CategoriesSQLRepo(MarketContext db)
		{
			_db = db;
		}
		public IEnumerable<Category> GetCategories()
		{
			return _db.Categories.ToList();
		}

		public void DeleteCategory(int id)
		{
			var category = _db.Categories.Find(id);

			// Check if the category exists
			if (category != null)
			{
				// Remove the category from the context
				_db.Categories.Remove(category);

				// Save changes to the database
				_db.SaveChanges();
			}
			else
			{
				// Handle the case where the category wasn't found (optional)
				throw new Exception("Category not found.");
			}
		}

		public void UpdateCategory(Category category)
		{
			// Check if the category exists in the database
			var existingCategory = _db.Categories.Find(category.Id);

			if (existingCategory != null)
			{
				// Update the properties of the existing category
				existingCategory.Name = category.Name; // Update other properties as needed
				existingCategory.Description = category.Description; // Example property

				// Save changes to the database
				_db.SaveChanges();
			}
			else
			{
				// Handle the case where the category wasn't found (optional)
				throw new Exception("Category not found.");
			}
		}

		public Category? GetCategoryById(int id)
		{
			return _db.Categories.Find(id);
		}

		public void AddCategory(Category category)
		{
			// Add the new category to the DbSet
			_db.Categories.Add(category);

			// Save changes to the database
			_db.SaveChanges();
		}
	}
}
