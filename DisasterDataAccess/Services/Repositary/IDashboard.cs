using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisasterModels.Models;

namespace DisasterDataAccess.Services.Repositary
{
    public interface IDashboard
    {
        string TotalVictim();
        string ResourceDeployed();
        string ActiveCases();
        List<DisasterViewModel> recentDisaster();
      

	}
}
