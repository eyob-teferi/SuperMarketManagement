using CoreBusiness;

namespace SuperMarketManagement.ViewModel
{
	public class TransactionViewModel
	{
		public string? CashierName { get; set; }

		public DateTime StartDate { get; set; }= DateTime.Now;
		public DateTime EndDate { get; set; } = DateTime.Now;

		public IEnumerable<Transaction> Transactions { get; set; } = new List<Transaction>();
	}
}
