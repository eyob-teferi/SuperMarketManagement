using CoreBusiness;

namespace UseCases.Interfaces;

public interface IEditCategoryUseCase
{
    void Execute(Category category);
}