using System.Collections.Generic;
using TaxiNet.DataLayer;

namespace TaxiNet.Services.GalleryService
{
    public interface IGalleryService
    {
        GalleryItem Get(int id);
        List<GalleryItem> GetAll();
        void Update(GalleryItem galleryItem);
        void Delete(int id);
    }
}