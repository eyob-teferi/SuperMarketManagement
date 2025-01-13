using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using CoreBusiness;


namespace Plugins.Datastore.InMemory
{
	public class ProductsRepo:IProductsRepo
	{
		private readonly ICategoriesRepo _categoriesRepo;

		public ProductsRepo(ICategoriesRepo categoriesRepo)
		{
			_categoriesRepo = categoriesRepo;
		}
		private readonly List<Product> _products = new List<Product>()
		{
			new Product { Id = 1, Name = "Cola", CategoryId = 1, Price = 1, Quantity = 100 },
			new Product { Id = 2, Name = "Chicken", CategoryId = 2, Price = 5, Quantity = 50 },
			new Product { Id = 3, Name = "Bread", CategoryId = 3, Price = 2, Quantity = 200 },
			new Product { Id = 4, Name = "Salmon", CategoryId = 2, Price = 9000, Quantity = 150 }
		};


		public  IEnumerable<Product> GetProducts(bool loadCategory = false)
		{
			if (!loadCategory)
			{
				return _products;
			}
			else
			{
				if (_products != null && _products.Count > 0)
				{
					_products.ForEach(x =>
					{
						if (x.CategoryId != 0)
							x.Category = _categoriesRepo.GetCategoryById(x.CategoryId);
					});
				}

				return _products ?? new List<Product>();
			}
		}

		public Product? GetProductById(int productId, bool loadCategory = false)
		{
			var product = _products.FirstOrDefault(x => x.Id == productId);
			if (product != null)
			{
				var prod = new Product
				{
					Id = product.Id,
					Name = product.Name,
					Quantity = product.Quantity,
					Price = product.Price,
					CategoryId = product.CategoryId
				};

				if (loadCategory)
				{
					prod.Category = _categoriesRepo.GetCategoryById(prod.CategoryId);
				}

				return prod;
			}

			return null;
		}
		public void AddProduct(Product product)
		{
			if (product == null) throw new ArgumentNullException(nameof(product));

			product.Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;

			_products.Add(product);
		}

		public  void UpdateProduct(Product product)
		{
			if (product == null) throw new ArgumentNullException(nameof(product));

			var productToUpdate = _products.FirstOrDefault(c => c.Id == product.Id);
			if (productToUpdate != null)
			{
				productToUpdate.Name = product.Name;
				productToUpdate.Price = product.Price;
				productToUpdate.Quantity = product.Quantity;
				productToUpdate.CategoryId = product.CategoryId;

			}
		}

		public  void DeleteProduct(int productId)
		{
			var productToRemove = _products.FirstOrDefault(c => c.Id == productId);
			if (productToRemove != null)
			{
				_products.Remove(productToRemove);
			}
		}

		

		public  IEnumerable<Product> GetProductsByCategory(int Id)
		{
			var products = _products.Where(p => p.CategoryId == Id);
			if (products != null)
			{
				return products.ToList();
			}

			return null;
		}

		
	}
}
