using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;

namespace UseCases.CatagoryUseCases
{
	public class ViewCategoriesUseCase:IViewCategoriesUseCase
	{
		private readonly ICategoriesRepo _categoryRepo;

		public ViewCategoriesUseCase(ICategoriesRepo categoryRepo)
		{
			_categoryRepo = categoryRepo;

		}
		public IEnumerable<Category> Execute()
		{
			return _categoryRepo.GetCategories();
		}
	}

	
}
