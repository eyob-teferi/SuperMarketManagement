using System.ComponentModel.DataAnnotations;
using SuperMarketManagement.Data;

namespace SuperMarketManagement.ViewModel.Validation
{
	public class SalesViewModel_EnsureQuantityToSellAmount:ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)

		{
			var QuantityToSell = (int)value;

			var SalesViewModel = validationContext.ObjectInstance as SalesViewModel;

			if (SalesViewModel != null)
			{
				if (QuantityToSell <= 0)
				{
					return new ValidationResult("The Quantity to sell has to be greater than 0");
				}

				var QunatityInStock = ProductsRepo.GetProductById(SalesViewModel.SelectedProductId).Quantity;

				if (QunatityInStock < QuantityToSell)
				{
					return new ValidationResult("Not enough in Stock");
				}
			}

			return ValidationResult.Success;
		}
	}
}
