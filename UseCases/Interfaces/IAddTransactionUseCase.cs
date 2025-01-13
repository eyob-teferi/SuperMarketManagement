namespace UseCases.Interfaces;

public interface IAddTransactionUseCase
{
    void Execute(string cashierName, int productId, string productName, double price, int qtyBefore, int quantityToSell);
}