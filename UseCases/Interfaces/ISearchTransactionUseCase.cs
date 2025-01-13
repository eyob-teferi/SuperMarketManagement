using CoreBusiness;

namespace UseCases.Interfaces;

public interface ISearchTransactionUseCase
{
    IEnumerable<Transaction> Execute(string cashierName, DateTime startDate, DateTime endDate);
}