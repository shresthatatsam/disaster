using DisasterDataAccess.Services.Repositary;
using DisasterModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace DisasterManagement.Controllers
{
	public class VictimManagementController : Controller
    {

        private readonly IDashboard _dashboard;
        private readonly IDisaster _disaster;
		private readonly IVictim _victim;

		public VictimManagementController(IDashboard dashboard, IDisaster disaster, IVictim victim)
        {
            _dashboard = dashboard;
            _disaster = disaster;
            _victim = victim;
        }
        public IActionResult Index()
		{
            List<DisasterViewModel> disasterViewModels = _dashboard.recentDisaster();
            return View(disasterViewModels);
		}

		public IActionResult PrintView(Guid id)
		{
			DisasterViewModel item = _disaster.GetById(id);
			return View(item);
		}

		public IActionResult Edit(Guid id)
        {
           DisasterViewModel disasterViewModel = _disaster.GetById(id);
            return View(disasterViewModel);
        }

        [HttpPost]
		public async Task<IActionResult> Edit(DisasterViewModel model)
		{
		
			

			var createdModel = await _victim.Edit(model);
			if (createdModel == null)
			{
				TempData["error"] = "phone number already exists";
				return RedirectToAction("Index");
			}
			// Redirect to printView with the created model's ID
			return RedirectToAction("PrintView", new { id = createdModel.Id });


		}
	}
}
