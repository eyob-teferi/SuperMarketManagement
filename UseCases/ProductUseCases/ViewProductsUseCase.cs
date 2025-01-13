using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.ProductUseCases
{
	public class ViewProductsUseCase : IViewProductsUseCase
	{
		private readonly IProductsRepo _productsRepo;

		public ViewProductsUseCase(IProductsRepo productsRepo )
		{
			_productsRepo = productsRepo;
		}
		public IEnumerable<Product> Execute(bool loadCategory=false)
		{
			return _productsRepo.GetProducts(loadCategory);
		}
	}

	
}
