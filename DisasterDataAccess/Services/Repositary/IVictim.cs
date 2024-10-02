using DisasterModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDataAccess.Services.Repositary
{
    public interface IVictim
    {
		DisasterPhotos GetById(Guid id);
		//DisasterViewModel update(DisasterViewModel model);
		Task<DisasterViewModel> Edit(DisasterViewModel model);
	}
}
