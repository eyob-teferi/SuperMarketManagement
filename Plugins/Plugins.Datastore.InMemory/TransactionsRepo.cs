using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.Datastore.InMemory
{
	public class TransactionsRepo:ITransactionsRepo
	{
		private readonly List<Transaction> _transactions = new List<Transaction>();


		public IEnumerable<Transaction> GetByCashierAndDate(string cashierName, DateTime date)
		{
			if (string.IsNullOrWhiteSpace(cashierName))
			{
				return _transactions.Where(t => t.TimeStamp.Date == date.Date);
			}
			else
			{
				return _transactions.Where(t => t.CashierName.ToLower().Contains(cashierName.ToLower()) &&
				                                t.TimeStamp.Date == date.Date);
			}
		}

		public void Add(string cashierName, int productId, string productName, double price, int qtyBefore, int quantityToSell)
		{
			var transaction = new Transaction()
			{
				CashierName = cashierName,
				Price = price,
				ProductId = productId,
				ProductName = productName,
				QtyBefore = qtyBefore,
				SoldQty = quantityToSell,
				TimeStamp = DateTime.Now
			};

			if (_transactions != null && _transactions.Count > 0)
			{
				transaction.Id = _transactions.Max(t => t.Id) + 1;
				_transactions.Add(transaction);
			}
			else
			{
				transaction.Id = 1;
				_transactions.Add(transaction);
			}
		}

		public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
		{
			// Normalize cashierName for case-insensitive search
			var normalizedCashierName = cashierName?.ToLower();

			return _transactions.Where(t =>
				(string.IsNullOrEmpty(cashierName) || t.CashierName.ToLower().Contains(normalizedCashierName)) &&
				t.TimeStamp.Date >= startDate.Date &&
				t.TimeStamp.Date <= endDate.Date);
		}
	}
}
