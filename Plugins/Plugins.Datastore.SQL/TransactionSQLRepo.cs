using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.Datastore.SQL
{
	public class TransactionSQLRepo:ITransactionsRepo
	{
		private readonly MarketContext _db;

		public TransactionSQLRepo(MarketContext db)
		{
			_db = db;
		}

		// Method to add a new transaction
		public void Add(string cashierName, int productId, string productName, double price, int qtyBefore, int quantityToSell)
		{
			var transaction = new Transaction
			{
				TimeStamp = DateTime.Now,
				ProductId = productId,
				ProductName = productName,
				Price = price,
				QtyBefore = qtyBefore,
				SoldQty = quantityToSell,
				CashierName = cashierName
			};

			_db.Transactions.Add(transaction); // Add the transaction to the context
			_db.SaveChanges(); // Save changes to the database
		}

		// Method to get transactions by cashier name and date
		public IEnumerable<Transaction> GetByCashierAndDate(string cashierName, DateTime date)
		{
			return _db.Transactions
				.Where(t => (string.IsNullOrEmpty(cashierName) || EF.Functions.Like(t.CashierName, $"%{cashierName}%"))
				            && t.TimeStamp.Date == date.Date).ToList(); // Execute the query and return the results as a list
		}

		// Method to search transactions by cashier name and date range
		public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
		{
			return _db.Transactions
				.Where(t => (string.IsNullOrEmpty(cashierName) || EF.Functions.Like(t.CashierName, $"%{cashierName}%"))
				            && t.TimeStamp.Date >= startDate.Date
				            && t.TimeStamp.Date <= endDate.Date).ToList(); // Execute the query and return the results as a list
		}
	}

}
