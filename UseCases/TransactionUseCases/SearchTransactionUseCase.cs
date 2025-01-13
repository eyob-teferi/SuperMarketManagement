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
    public class SearchTransactionUseCase : ISearchTransactionUseCase
	{
		private readonly ITransactionsRepo _transactionsRepo;

		public SearchTransactionUseCase(ITransactionsRepo transactionsRepo)
		{
			_transactionsRepo = transactionsRepo;
		}
		public IEnumerable<Transaction> Execute(string cashierName, DateTime startDate, DateTime endDate)
		{
			return _transactionsRepo.Search(cashierName, startDate, endDate);
		}
	}
}
