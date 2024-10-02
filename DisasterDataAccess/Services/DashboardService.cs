using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisasterDataAccess.Data;
using DisasterDataAccess.Services.Repositary;
using DisasterModels.Models;

namespace DisasterDataAccess.Services
{
    public class DashboardService : IDashboard
    {
        public readonly ApplicationDbContext _context;

        public DashboardService(ApplicationDbContext context)
        {
            _context = context;
        }


        public string TotalVictim()
        {
           var totalVictim = _context.DisasterInformation.Count().ToString();
            return totalVictim;
        }

        public string ActiveCases()
        {
            var totalVictim = _context.DisasterInformation.Where(x=>x.Isactive ==true).Count().ToString();
            return totalVictim;
        }

        public string ResourceDeployed()
        {
            var totalVictim = _context.DisasterInformation.Where(x => x.Isactive == false).Count().ToString();
            return totalVictim;
        }

        public List<DisasterViewModel> recentDisaster()
        {
            var data = _context.DisasterInformation
         .Select(x => new DisasterViewModel
         {
             Id =x.Id,
             Category = x.Category,
             Date_Occured = x.Date_Occured,
             Isactive = x.Isactive,
             created_at = x.created_at 
         })
         .OrderByDescending(x => x.created_at).Take(10)
		 .ToList(); 

            return data;
        }

		
	}
}
