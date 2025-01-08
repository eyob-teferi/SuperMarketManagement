using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.ViewModel;

namespace SuperMarketManagement.Controllers
{
	public class SalesController : Controller
	{
		public IActionResult Index()
		{
			var model = new SalesViewModel();
			
			return View(model);
		}
	}
}
