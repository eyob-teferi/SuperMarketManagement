using CoreBusiness;

namespace UseCases.ProductUseCases;

public interface IViewProductsUseCase
{
	IEnumerable<Product> Execute(bool loadCategory=false);
}