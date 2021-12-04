using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaxiNet.DataLayer;
using TaxiNet.Helpers;
using TaxiNet.Services.GalleryService;

namespace TaxiNet.Pages
{
    public class GalleryModel : PageModel
    {
        private IGalleryService _galleryService;

        [BindProperty(SupportsGet = true)]
        public List<GalleryItem> GalleryItems { get; set; } = new List<GalleryItem>();

        public GalleryModel(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

        public void OnGet()
        {
            var x = _galleryService.GetAll();
            GalleryItems = x;
        }
    }
}
