using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaxiNet.DataLayer;
using TaxiNet.Helpers;
using TaxiNet.Services.GalleryService;

namespace TaxiNet.Pages.Admin
{
    //[Authorize]
    public class GalleryControllerModel : PageModel
    {
        [BindProperty]
        public List<GalleryItem> galleryItems { get; set; } = new List<GalleryItem>();

        private IGalleryService _galleryService;

        public GalleryControllerModel(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }
        public void OnGet()
        {
            galleryItems = _galleryService.GetAll();
        }

        public IActionResult OnPostDelete(int id)
        {
            _galleryService.Delete(id);
            return RedirectToPage();
        }
        
    }
}
