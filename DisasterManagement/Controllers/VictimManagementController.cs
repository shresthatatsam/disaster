using DisasterDataAccess.Services.Repositary;
using DisasterModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace DisasterManagement.Controllers
{
	public class VictimManagementController : Controller
    {

        private readonly IDashboard _dashboard;
        private readonly IDisaster _disaster;

        public VictimManagementController(IDashboard dashboard, IDisaster disaster)
        {
            _dashboard = dashboard;
            _disaster = disaster;
        }
        public IActionResult Index()
		{
            List<DisasterViewModel> disasterViewModels = _dashboard.recentDisaster();
            return View(disasterViewModels);
		}

        public IActionResult Edit(Guid id)
        {
           DisasterViewModel disasterViewModel = _disaster.GetById(id);
            return View(disasterViewModel);
        }
    }
}
