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
    public class ViewSelectedCategoryUseCase : IViewSelectedCategoryUseCase
	{
		private readonly ICategoriesRepo _categoryRepo;

		public ViewSelectedCategoryUseCase(ICategoriesRepo categoryRepo)
		{
			_categoryRepo = categoryRepo;
		}
		public Category Execute(int Id)
		{
			return _categoryRepo.GetCategoryById(Id);
		}
	}

	
}
