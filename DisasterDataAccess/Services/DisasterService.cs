using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisasterDataAccess.Data;
using DisasterDataAccess.Services.Repositary;
using DisasterModels.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DisasterDataAccess.Services
{

    public class DisasterService :IDisaster
    {

        private readonly ApplicationDbContext _context;
        public DisasterService(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<DisasterViewModel> Create(DisasterPhotos model)
        {
            // Map to the database entity
           var contectNumber = _context.DisasterInformation.Where(x => x.ContactNumber == model.ContactNumber).FirstOrDefault();
            if(contectNumber != null)
            {
                return null;

			}
			var disaster = new DisasterViewModel
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Age = model.Age,
                Gender = model.Gender,
                ContactNumber = model.ContactNumber,
                Category = model.Category,
                Severity = model.Severity,
                Date_Occured = model.Date_Occured,
                Tole = model.Tole,
                Province = model.Province,
                District = model.District,
                Municipality = model.Municipality,
                Ward = model.Ward,
                Description = model.Description,
                PhotoBase64 = model.PhotoBase64
            };

            // Save the disaster entity
            _context.DisasterInformation.Add(disaster);
            await _context.SaveChangesAsync();

            return disaster; // Return the created disaster entity
        }

        public DisasterViewModel GetById(Guid id)
        {
            // Map to the database entity
            var disaster = _context.DisasterInformation.Where(x=>x.Id == id).Select(model => new DisasterViewModel
            {
                Name = model.Name,
                Age = model.Age,
                Gender = model.Gender,
                ContactNumber = model.ContactNumber,
                Category = model.Category,
                Severity = model.Severity,
                Date_Occured = model.Date_Occured,
                Tole = model.Tole,
                Province = model.Province,
                District = model.District,
                Municipality = model.Municipality,
                Ward = model.Ward,
                Description = model.Description,
                PhotoBase64 = model.PhotoBase64
            }).FirstOrDefault();


            return disaster; // Return the created disaster entity
        }
    }
}
