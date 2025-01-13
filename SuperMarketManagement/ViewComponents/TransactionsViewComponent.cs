using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Data;
using UseCases.Interfaces;

namespace SuperMarketManagement.ViewComponents
{
	public class TransactionsViewComponent:ViewComponent
	{
		private readonly IViewTransactionByDateAndCashierUseCase _viewTransactionByDateAndCashierUseCase;

		public TransactionsViewComponent(IViewTransactionByDateAndCashierUseCase viewTransactionByDateAndCashierUseCase)
		{
			_viewTransactionByDateAndCashierUseCase = viewTransactionByDateAndCashierUseCase;
		}
		public IViewComponentResult Invoke(string userName)
		{
			var transactions=_viewTransactionByDateAndCashierUseCase.Execute(userName, DateTime.Now);
			return View(transactions);
		}
	}
}
