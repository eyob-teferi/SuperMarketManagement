using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;

namespace UseCases.ProductUseCases
{
    public class ViewProductsByCategoryUseCase : IViewProductsByCategoryUseCase
	{
		private readonly IProductsRepo _productsRepo;

		public ViewProductsByCategoryUseCase(IProductsRepo productsRepo)
		{
			_productsRepo = productsRepo;
		}
		public IEnumerable<Product> Execute(int Id)
		{
			return _productsRepo.GetProductsByCategory(Id);
		}
	}
}
