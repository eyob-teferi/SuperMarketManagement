using CoreBusiness;

namespace UseCases.Interfaces;

public interface IViewSelectedProductUseCase
{
    Product Execute(int id, bool loadCategory = false);
}