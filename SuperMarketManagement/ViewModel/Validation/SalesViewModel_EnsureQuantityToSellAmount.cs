using System.ComponentModel.DataAnnotations;
using SuperMarketManagement.Data;
using UseCases.Interfaces;

namespace SuperMarketManagement.ViewModel.Validation
{
	public class SalesViewModel_EnsureQuantityToSellAmount : ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			// Ensure value is not null and is an integer
			if (value == null || !(value is int QuantityToSell))
			{
				return new ValidationResult("Invalid quantity to sell.");
			}

			var salesViewModel = validationContext.ObjectInstance as SalesViewModel;

			if (salesViewModel != null)
			{
				if (QuantityToSell <= 0)
				{
					return new ValidationResult("The quantity to sell has to be greater than 0.");
				}

				// Retrieve the use case from the service provider
				var viewSelectedProductUseCase = (IViewSelectedProductUseCase)validationContext.GetService(typeof(IViewSelectedProductUseCase));

				if (viewSelectedProductUseCase == null)
				{
					return new ValidationResult("Product service is not available.");
				}

				var product = viewSelectedProductUseCase.Execute(salesViewModel.SelectedProductId);

				if (product == null)
				{
					return new ValidationResult("Selected product not found.");
				}

				var quantityInStock = product.Quantity;

				if (quantityInStock < QuantityToSell)
				{
					return new ValidationResult("Not enough in stock.");
				}
			}

			return ValidationResult.Success;
		}
	}
}
