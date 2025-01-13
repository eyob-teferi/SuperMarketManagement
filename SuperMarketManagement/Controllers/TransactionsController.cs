using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Data;
using SuperMarketManagement.ViewModel;
using UseCases.Interfaces;

namespace SuperMarketManagement.Controllers
{
	public class TransactionsController:Controller
	{
		private readonly ISearchTransactionUseCase _searchTransactionUseCase;

		public TransactionsController(ISearchTransactionUseCase searchTransactionUseCase)
		{
			_searchTransactionUseCase = searchTransactionUseCase;
		}
		public IActionResult Index()
		{
			var model = new TransactionViewModel();
			 return View(model);
		}

		[HttpPost]
		public IActionResult Search(TransactionViewModel model)
		{
			model.Transactions=_searchTransactionUseCase.Execute(model.CashierName, model.StartDate, model.EndDate);
			return View("Index",model);
		}
	}
}
							