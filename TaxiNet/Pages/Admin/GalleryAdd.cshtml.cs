using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaxiNet.DataLayer;
using TaxiNet.DataLayer.DataModels.Enums;
using TaxiNet.Services.GalleryService;

namespace TaxiNet.Pages.Admin
{
    public class GalleryAddModel : PageModel
    {
        private IGalleryService _galleryService;

        private IHostingEnvironment _environment;

        [BindProperty]
        public GalleryItem GalleryItem { get; set; }

        [Required(ErrorMessage = "Image is Required")]
        [BindProperty]
        public IFormFile Image { get; set; }

        public GalleryAddModel(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Image != null && Image.Length != 0)
            {
                var extention = Path.GetExtension(Image.FileName).ToLower();
                if (extention == "jpg" || extention == "png" || extention == "jpeg")
                {
                    var file = "wwwroot/images/" + Image.FileName;
                    using (var fileStream = new FileStream(file, FileMode.Create))
                    {
                        Image.CopyTo(fileStream);
                    }
                    GalleryItem.ImageUrl = Path.Combine("images", Image.FileName);
                }
                else
                {
                    return Page();
                }
            }
            GalleryItem.GalleryItemType = (GalleryItemType)int.Parse(Request.Form["cars"]);

            _galleryService.Update(GalleryItem);

            return RedirectToPage("GalleryController");
        }
    }
}
