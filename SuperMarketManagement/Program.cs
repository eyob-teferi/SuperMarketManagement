


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

var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddDbContext<MarketContext>(options =>
	options.UseSqlServer(Configuration.GetConnectionString("MarketManagement")));


builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ICategoriesRepo, CategoriesRepo>();
builder.Services.AddSingleton<IProductsRepo, ProductsRepo>();
builder.Services.AddSingleton<ITransactionsRepo,TransactionsRepo>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
