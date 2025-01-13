using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.ProductUseCases
{
	public class DeleteProductUseCase : IDeleteProductUseCase
	{
		private readonly IProductsRepo _productsRepo;

		public DeleteProductUseCase(IProductsRepo productsRepo)
		{
			_productsRepo = productsRepo;
		}
		public void Execute(int Id)
		{
			_productsRepo.DeleteProduct(Id);
		}
	}
}
