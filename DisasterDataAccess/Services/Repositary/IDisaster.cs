using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisasterModels.Models;

namespace DisasterDataAccess.Services.Repositary
{
    public interface IDisaster
    {
        Task<DisasterViewModel> Create(DisasterPhotos model);
        DisasterViewModel GetById(Guid id);
    }
}
