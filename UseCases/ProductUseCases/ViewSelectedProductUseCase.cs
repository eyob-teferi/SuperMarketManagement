using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;

namespace UseCases.ProductUseCases
{
    public class ViewSelectedProductUseCase : IViewSelectedProductUseCase
	{
		private readonly IProductsRepo _productsRepo;

		public ViewSelectedProductUseCase(IProductsRepo productsRepo)
		{
			_productsRepo = productsRepo;
		}
		public Product? Execute(int id, bool loadCategory = false)
		{
			return _productsRepo.GetProductById(id,loadCategory);
		}
	}
}
