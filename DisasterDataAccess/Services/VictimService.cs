using DisasterDataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDataAccess.Services
{
    public class VictimService
    {


        private readonly ApplicationDbContext _context;
        public VictimService(ApplicationDbContext context)
        {
            this._context = context;
        }

        

    }
}
