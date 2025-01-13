using CoreBusiness;

namespace UseCases.Interfaces;

public interface IViewProductsByCategoryUseCase
{
    IEnumerable<Product> Execute(int Id);
}