using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
	public interface IProductsRepo
	{
		IEnumerable<Product> GetProducts(bool loadCategory = false);
		void AddProduct(Product product);
		void UpdateProduct(Product product);
		Product? GetProductById(int id, bool loadCategory = false);
		void DeleteProduct(int id);
		IEnumerable<Product> GetProductsByCategory(int id);
	}
}
