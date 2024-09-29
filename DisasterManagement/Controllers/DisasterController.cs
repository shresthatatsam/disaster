using DisasterDataAccess.Services.Repositary;
using DisasterModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace DisasterManagement.Controllers
{
    public class DisasterController : Controller
    {
        private readonly IDisaster _disaster;
        public DisasterController(IDisaster disaster)
        {
            _disaster = disaster;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PrintView(Guid id)
        {
            DisasterViewModel item = _disaster.GetById(id);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DisasterPhotos model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Return the same view with the model if the state is invalid
            }

            var base64Images = new List<string>(); // Temporary list to hold base64 images

            foreach (var file in model.UploadedPhotos)
            {
                if (file.Length > 0) // Ensure the file is not empty
                {
                    try
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            Console.WriteLine($"Uploading file: {file.FileName}, Size: {file.Length}");
                            await file.CopyToAsync(memoryStream);

                            // Reset the memory stream position to the beginning
                            memoryStream.Position = 0;

                            // Read the bytes from the memory stream
                            byte[] imageBytes = memoryStream.ToArray();
                            string base64Image = Convert.ToBase64String(imageBytes);
                            base64Images.Add(base64Image); // Add to temporary list
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing file {file.FileName}: {ex.Message}");
                        ModelState.AddModelError("UploadedPhotos", $"Could not process {file.FileName}. Error: {ex.Message}");
                    }
                }
            }

            
            model.PhotoBase64.AddRange(base64Images);

            var createdModel = await _disaster.Create(model);
            if(createdModel == null)
            {
                TempData["error"] = "phone number already exists";
                return RedirectToAction("Index");
            }
            // Redirect to printView with the created model's ID
            return RedirectToAction("PrintView", new { id = createdModel.Id });
        }

    }
}
