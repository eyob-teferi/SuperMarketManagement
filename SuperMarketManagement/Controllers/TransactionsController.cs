using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Data;
using SuperMarketManagement.ViewModel;

namespace SuperMarketManagement.Controllers
{
	public class TransactionsController:Controller
	{
		public IActionResult Index()
		{
			var model = new TransactionViewModel();
			 return View(model);
		}

		[HttpPost]
		public IActionResult Search(TransactionViewModel model)
		{
			model.Transactions=TransactionRepo.Search(model.CashierName, model.StartDate, model.EndDate);
			return View("Index",model);
		}
	}
}
							