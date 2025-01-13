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
    public class AddProductUseCase : IAddProductUseCase
	{
		private readonly IProductsRepo _productsRepo;

		public AddProductUseCase(IProductsRepo productsRepo)
		{
			_productsRepo = productsRepo;
		}
		public void Execute(Product product)
		{ 
			_productsRepo.AddProduct(product);
		}
	}
}
