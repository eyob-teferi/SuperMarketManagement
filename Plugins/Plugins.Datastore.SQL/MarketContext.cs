using CoreBusiness;
using Microsoft.EntityFrameworkCore;

namespace Plugins.Datastore.SQL
{
	public class MarketContext:DbContext
	{

		public MarketContext(DbContextOptions<MarketContext> options) : base(options)
		{
		}
		public DbSet<Category> Categories { get; set; }

		public DbSet<Product> Products { get; set; }	

		public DbSet<Transaction> Transactions { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			

			// Configure one-to-many relationship
			modelBuilder.Entity<Category>()
				.HasMany(c => c.Products)
				.WithOne(p => p.Category)
				.HasForeignKey(p => p.CategoryId);

			modelBuilder.Entity<Category>().HasData(
		new Category { Id = 1, Name = "Electronics", Description = "Devices and gadgets." },
		new Category { Id = 2, Name = "Books", Description = "Fiction and non-fiction books." },
		new Category { Id = 3, Name = "Clothing", Description = "Men's and women's apparel." },
		new Category { Id = 4, Name = "Home Appliances", Description = "Appliances for home use." },
		new Category { Id = 5, Name = "Sports", Description = "Sports equipment and gear." },
		new Category { Id = 6, Name = "Toys", Description = "Children's toys and games." },
		new Category { Id = 7, Name = "Beauty", Description = "Beauty products and cosmetics." },
		new Category { Id = 8, Name = "Automotive", Description = "Car and motorcycle accessories." },
		new Category { Id = 9, Name = "Health", Description = "Health and wellness products." },
		new Category { Id = 10, Name = "Grocery", Description = "Food and daily essentials." }
	);

			// Seed products
			modelBuilder.Entity<Product>().HasData(
				new Product { Id = 1, Name = "Laptop", Price = 999.99, Quantity = 10, CategoryId = 1 },
				new Product { Id = 2, Name = "Smartphone", Price = 699.99, Quantity = 25, CategoryId = 1 },
				new Product { Id = 3, Name = "Headphones", Price = 199.99, Quantity = 50, CategoryId = 1 },
				new Product { Id = 4, Name = "C# Programming", Price = 39.99, Quantity = 100, CategoryId = 2 },
				new Product { Id = 5, Name = "Fiction Novel", Price = 15.99, Quantity = 75, CategoryId = 2 },
				new Product { Id = 6, Name = "T-Shirt", Price = 19.99, Quantity = 30, CategoryId = 3 },
				new Product { Id = 7, Name = "Jeans", Price = 49.99, Quantity = 20, CategoryId = 3 },
				new Product { Id = 8, Name = "Blender", Price = 89.99, Quantity = 15, CategoryId = 4 },
				new Product { Id = 9, Name = "Tennis Racket", Price = 79.99, Quantity = 10, CategoryId = 5 },
				new Product { Id = 10, Name = "Action Figure", Price = 24.99, Quantity = 50, CategoryId = 6 }
			);
		}


	}
}
