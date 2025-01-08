using SuperMarketManagement.Data;
using SuperMarketManagement.Models;
using SuperMarketManagement.ViewModel;

namespace SuperMarketManagement.Data
{
	public static class ProductsRepo
	{
		private static List<Product> _products = new List<Product>()
		{
			new Product { Id = 1, Name = "Cola", CategoryId = 1, Price = 1, Quantity = 100 },
			new Product { Id = 2, Name = "Chicken", CategoryId = 2, Price = 5, Quantity = 50 },
			new Product { Id = 3, Name = "Bread", CategoryId = 3, Price = 2, Quantity = 200 },
			new Product { Id = 4, Name = "Salmon", CategoryId = 2, Price = 9000, Quantity = 150 }
		};


		public static List<Product> GetProducts()
		{
			return _products;
		}
		public static void Create(Product product)
		{
			if (product == null) throw new ArgumentNullException(nameof(product));
			product.Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
			_products.Add(product);
		}

		public static void UpdateProduct(Product product)
		{
			if (product == null) throw new ArgumentNullException(nameof(product));

			var productToUpdate = _products.FirstOrDefault(c => c.Id == product.Id);
			if (productToUpdate != null)
			{
				productToUpdate.Name = product.Name;
				productToUpdate.Price = product.Price;
				productToUpdate.Quantity = product.Quantity;
				productToUpdate.CategoryId= product.CategoryId;

			}
		}

		public static void DeleteProduct(int productId)
		{
			var productToRemove = _products.FirstOrDefault(c => c.Id == productId);
			if (productToRemove != null)
			{
				_products.Remove(productToRemove);
			}
		}

		public static List<ProductViewModel> GetProductsWithCategoryNames()
		{
			return _products.Select(p => new ProductViewModel
			{
				Id = p.Id,
				Name = p.Name,
				CategoryName = CategoriesRepo.GetCategories().FirstOrDefault(c => c.Id == p.CategoryId)?.Name ?? "Unknown",
				Price = p.Price,
				Quantity = p.Quantity
			}).ToList();
		}

		public static List<Product> GetProductsByCategory(int Id)
		{
			var products = _products.Where(p => p.CategoryId == Id);
			if (products != null)
			{
				return products.ToList();
			}

			return null;
		}

		public static Product GetProductById(int Id)
		{
			var product = _products.FirstOrDefault(p => p.Id == Id);
			if (product != null)
			{
				return product;
			}

			return null;
		}



	}
}
