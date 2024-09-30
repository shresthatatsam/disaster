using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DisasterModels.Models
{
    public class DisasterViewModel
    {
        public Guid Id { get; set; }
        //VICTIM
        public string Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }

        //DISASTER

        public string Category { get; set; }
        public string Severity { get; set; }
        public string Date_Occured { get; set; }

        //LOCATION
        public string Tole { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Municipality { get; set; }
        public string Ward { get; set; }

        //PHOTO
        public string Description { get; set; }
        public List<string> PhotoBase64 { get; set; } = new List<string>();

        //Extras
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }

        public string? adminId { get; set; }
        
        public bool Isactive { get; set; }


    }
}
