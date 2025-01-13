using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;

namespace UseCases.Interfaces
{
	public interface IViewCategoriesUseCase
	{
		IEnumerable<Category> Execute();
	}
}
