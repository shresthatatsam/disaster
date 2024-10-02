using DisasterDataAccess.Data;
using DisasterDataAccess.Services.Repositary;
using DisasterModels.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDataAccess.Services
{
    public class VictimService : IVictim
    {


        private readonly ApplicationDbContext _context;
        public VictimService(ApplicationDbContext context)
        {
            this._context = context;
        }


		public DisasterPhotos GetById(Guid id)
		{
			// Map to the database entity
			var disaster = _context.DisasterInformation.Where(x => x.Id == id).Select(model => new DisasterPhotos
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


		public async Task<DisasterViewModel> Edit(DisasterViewModel model)
		{
			var existingDisaster = _context.DisasterInformation
										  .Where(x => x.ContactNumber == model.ContactNumber)
										  .FirstOrDefault();

				existingDisaster.Name = string.IsNullOrEmpty(model.Name) ? existingDisaster.Name : model.Name;
				existingDisaster.Age = model.Age ?? existingDisaster.Age; // Assuming Age is nullable
				existingDisaster.Gender = string.IsNullOrEmpty(model.Gender) ? existingDisaster.Gender : model.Gender;
				existingDisaster.Category = string.IsNullOrEmpty(model.Category) ? existingDisaster.Category : model.Category;
				existingDisaster.Severity = model.Severity ?? existingDisaster.Severity; // Assuming Severity is nullable
				existingDisaster.Date_Occured = model.Date_Occured ?? existingDisaster.Date_Occured; // Assuming Date_Occured is nullable
				existingDisaster.Tole = string.IsNullOrEmpty(model.Tole) ? existingDisaster.Tole : model.Tole;
				existingDisaster.Province = string.IsNullOrEmpty(model.Province) ? existingDisaster.Province : model.Province;
				existingDisaster.District = string.IsNullOrEmpty(model.District) ? existingDisaster.District : model.District;
				existingDisaster.Municipality = string.IsNullOrEmpty(model.Municipality) ? existingDisaster.Municipality : model.Municipality;
				existingDisaster.Ward = string.IsNullOrEmpty(model.Ward) ? existingDisaster.Ward : model.Ward;
				existingDisaster.Description = string.IsNullOrEmpty(model.Description) ? existingDisaster.Description : model.Description;
				existingDisaster.PhotoBase64 = existingDisaster.PhotoBase64;

				existingDisaster.Isactive = true;

				await _context.SaveChangesAsync();

				return existingDisaster; 
			
		}


	}
}
