using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DisasterModels.Models
{
    public class DisasterPhotos
    {

            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Age { get; set; }
            public string Gender { get; set; }
            public string ContactNumber { get; set; }
            public string Category { get; set; }
            public string Severity { get; set; }
            public string Date_Occured { get; set; }
            public string Tole { get; set; }
            public string Province { get; set; }
            public string District { get; set; }
            public string Municipality { get; set; }
            public string Ward { get; set; }
            public string Description { get; set; }
            public List<string> PhotoBase64 { get; set; } = new List<string>();
            public List<IFormFile> UploadedPhotos { get; set; } = new List<IFormFile>();
        



    }
}
