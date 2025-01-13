using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
	public interface ITransactionsRepo
	{
		void Add(string cashierName, int productId, string productName, double price, int qtyBefore, int quantityToSell);
		IEnumerable<Transaction> GetByCashierAndDate(string cashierName, DateTime date);
		IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate);
	}
}
