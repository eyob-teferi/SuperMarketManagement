


using Microsoft.EntityFrameworkCore;
using Plugins.Datastore.InMemory;
using Plugins.Datastore.SQL;
using UseCases.CatagoryUseCases;
using UseCases.CategoryUseCases;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;
using UseCases.ProductUseCases;
using UseCases.TransactionUseCases;
using CategoriesRepo = Plugins.Datastore.InMemory.CategoriesRepo;
using ProductsRepo = Plugins.Datastore.InMemory.ProductsRepo;
using Microsoft.AspNetCore.Identity;
using SuperMarketManagement.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AccountContextConnection") ?? throw new InvalidOperationException("Connection string 'AccountContextConnection' not found.");

var Configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddDbContext<MarketContext>(options =>
	options.UseSqlServer(Configuration.GetConnectionString("MarketManagement")));

builder.Services.AddDbContext<AccountContext>(options =>
	options.UseSqlServer(Configuration.GetConnectionString("MarketManagement")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AccountContext>();

builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("Inventory", p=>p.RequireClaim("Department","Inventory"));
	options.AddPolicy("Cashiers", p => p.RequireClaim("Department", "Cashiers"));
});
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();


builder.Services.AddTransient<ICategoriesRepo, CategoriesSQLRepo>();
builder.Services.AddTransient<IProductsRepo, ProductsSQLRepo>();
builder.Services.AddTransient<ITransactionsRepo,TransactionSQLRepo>();

builder.Services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
builder.Services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
builder.Services.AddTransient< IDeleteCategoryUseCase, DeleteCategoryUseCase > ();
builder.Services.AddTransient< IEditCategoryUseCase, EditCategoryUseCase > ();
builder.Services.AddTransient< IViewSelectedCategoryUseCase, ViewSelectedCategoryUseCase > ();

builder.Services.AddTransient<IViewProductsUseCase, ViewProductsUseCase>();
builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase>();
builder.Services.AddTransient< IDeleteProductUseCase, DeleteProductUseCase > ();
builder.Services.AddTransient< IEditProductUseCase, EditProductUseCase > ();
builder.Services.AddTransient< IViewProductsByCategoryUseCase, ViewProductsByCategoryUseCase > ();
builder.Services.AddTransient< IViewSelectedProductUseCase ,ViewSelectedProductUseCase > ();

builder.Services.AddTransient<ISearchTransactionUseCase, SearchTransactionUseCase>();
builder.Services.AddTransient<IAddTransactionUseCase, AddTransactionUseCase>();
builder.Services.AddTransient<IViewTransactionByDateAndCashierUseCase, ViewTransactionByDateAndCashierUseCase>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
