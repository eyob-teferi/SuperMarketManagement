using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Data;

namespace SuperMarketManagement.ViewComponents
{
	public class TransactionsViewComponent:ViewComponent
	{
		public IViewComponentResult Invoke(string userName)
		{
			var transactions=TransactionRepo.GetByDateandCashier(userName, DateTime.Now);
			return View(transactions);
		}
	}
}
