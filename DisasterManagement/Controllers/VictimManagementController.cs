using Microsoft.AspNetCore.Mvc;

namespace DisasterManagement.Controllers
{
	public class VictimManagementController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
