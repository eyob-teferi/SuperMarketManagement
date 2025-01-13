using CoreBusiness;

namespace UseCases.Interfaces;

public interface IViewTransactionByDateAndCashierUseCase
{
    IEnumerable<Transaction> Execute(string cashierName, DateTime date);
}