using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;

namespace UseCases.CategoryUseCases
{
    public class DeleteCategoryUseCase : IDeleteCategoryUseCase
	{
		private readonly ICategoriesRepo _categoryRepo;

		public DeleteCategoryUseCase(ICategoriesRepo categoryRepo)
		{
			_categoryRepo = categoryRepo;

		}
		public void Execute(int Id)
		{
			_categoryRepo.DeleteCategory(Id);
		}
	}
}
