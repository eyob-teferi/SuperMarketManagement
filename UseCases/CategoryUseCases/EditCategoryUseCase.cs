using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;

namespace UseCases.CategoryUseCases
{
    public class EditCategoryUseCase : IEditCategoryUseCase
	{
		private readonly ICategoriesRepo _categoryRepo;

		public EditCategoryUseCase(ICategoriesRepo categoryRepo)
		{
			_categoryRepo = categoryRepo;

		}
		public void Execute(Category category)
		{
			_categoryRepo.UpdateCategory(category);
		}
	}
}
