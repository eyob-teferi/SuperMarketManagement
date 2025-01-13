using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;

namespace UseCases.TransactionUseCases
{
	public class ViewTransactionByDateAndCashierUseCase : IViewTransactionByDateAndCashierUseCase
	{
		private readonly ITransactionsRepo _transactionsRepo;

		public ViewTransactionByDateAndCashierUseCase(ITransactionsRepo transactionsRepo)
		{
			_transactionsRepo = transactionsRepo;
		}
		public IEnumerable<Transaction> Execute(string cashierName,DateTime date)
		{
			return _transactionsRepo.GetByCashierAndDate(cashierName,date);
		}
	}
}
