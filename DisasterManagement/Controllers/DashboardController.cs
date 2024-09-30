using DisasterDataAccess.Services.Repositary;
using DisasterModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DisasterManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IDashboard _dashboard;
		private readonly IDisaster _disaster;
	
		public DashboardController(IDashboard dashboard, IDisaster disaster)
        {
            _dashboard = dashboard;
			_disaster = disaster; 
		}

        public IActionResult Index()
        {
            ViewBag.VictimCount = _dashboard.TotalVictim();
            ViewBag.ActiveCases = _dashboard.ActiveCases();
            ViewBag.ResourceDeployed = _dashboard.ResourceDeployed();
            List<DisasterViewModel> disasterViewModels = _dashboard.recentDisaster();
            return View(disasterViewModels);
        }

        public IActionResult Details(Guid id)
        {
			DisasterViewModel item = _disaster.GetById(id);
			return View(item);
        }

    }
}
