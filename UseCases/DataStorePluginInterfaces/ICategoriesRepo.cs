using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
	public interface ICategoriesRepo
	{
		IEnumerable<Category> GetCategories();
		void DeleteCategory(int id);
		void UpdateCategory(Category category);
		Category? GetCategoryById(int id);
		void AddCategory(Category category);
	}
}
