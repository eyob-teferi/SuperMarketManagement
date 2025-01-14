using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.Datastore.SQL
{
	public class ProductsSQLRepo:IProductsRepo
	{
		private readonly MarketContext _db;

		public ProductsSQLRepo(MarketContext db)
		{
			_db = db;
		}
		public IEnumerable<Product> GetProducts(bool loadCategory = false)
		{
			if (loadCategory)
			{
				// Eager loading of the related Category for each Product
				return _db.Products
					.Include(p => p.Category) // Include the related Category
					.ToList(); // Execute the query and return the results as a list
			}
			else
			{
				// Retrieve products without loading related Category data
				return _db.Products.ToList(); // Execute the query and return the results as a list
			}
		}

		public void AddProduct(Product product)
		{
			_db.Products.Add(product);
			_db.SaveChanges();
		}

		public void UpdateProduct(Product product)
		{
			// Check if the product exists in the database
			var existingProduct = _db.Products.Find(product.Id);
			if (existingProduct != null)
			{
				// Update the existing product's properties
				_db.Entry(existingProduct).CurrentValues.SetValues(product);

				// Save changes to the database
				_db.SaveChanges();
			}
			else
			{
				throw new InvalidOperationException("Product not found");
			}
		}

		public Product? GetProductById(int id, bool loadCategory = false)
		{
			if (loadCategory)
			{
				// Include the related Category if requested
				return _db.Products
					.Include(p => p.Category) // Assuming Product has a navigation property Category
					.FirstOrDefault(p => p.Id == id);
			}
			else
			{
				// Just get the product without including related data
				return _db.Products.Find(id);
			}
		}

		public void DeleteProduct(int id)
		{
			var product = _db.Products.Find(id);
			if (product != null)
			{
				// Remove the product from the DbSet
				_db.Products.Remove(product);

				// Save changes to the database
				_db.SaveChanges();
			}
			else
			{
				throw new InvalidOperationException("Product not found");
			}
		}

		public IEnumerable<Product> GetProductsByCategory(int id)
		{
			return _db.Products
				.Where(p => p.CategoryId == id) // Filter products by CategoryId
				.ToList(); // Execute the query and return the results as a list
		}
	}
}
