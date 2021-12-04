using System;
using System.Collections.Generic;
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
    public class GalleryEditModel : PageModel
    {
        private IGalleryService _galleryService;

        private IHostingEnvironment _environment;

        [BindProperty]
        public GalleryItem galleryItem { get; set; } = new GalleryItem();

        [BindProperty]
        public IFormFile Upload { get; set; }

        public GalleryEditModel(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

        public void OnGet(int id)
        {
            galleryItem = _galleryService.Get(id);
        }
        public IActionResult OnPost()
        {
            if (Upload != null && Upload.Length != 0)
            {
                var file = "wwwroot/images/" + Upload.FileName;
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    Upload.CopyTo(fileStream);
                }
                galleryItem.ImageUrl = Path.Combine("images", Upload.FileName);
            }
            galleryItem.GalleryItemType = (GalleryItemType)int.Parse(Request.Form["cars"]);

            _galleryService.Update(galleryItem);

            return RedirectToPage("GalleryController");
        }
    }
}
