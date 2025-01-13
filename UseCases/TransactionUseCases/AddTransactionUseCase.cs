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
    public class AddTransactionUseCase : IAddTransactionUseCase
	{
		private readonly ITransactionsRepo _transactionsRepo;

		public AddTransactionUseCase(ITransactionsRepo transactionsRepo)
		{
			_transactionsRepo = transactionsRepo;
		}
		public void Execute(string cashierName, int productId, string productName, double price, int qtyBefore, int quantityToSell)
		{
			_transactionsRepo.Add(cashierName, productId, productName, price, qtyBefore, quantityToSell);
		}
	}
}
