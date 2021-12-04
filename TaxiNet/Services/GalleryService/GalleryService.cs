using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiNet.DataLayer;
using TaxiNet.DataLayer.DataAccess;

namespace TaxiNet.Services.GalleryService
{
    public class GalleryService : IGalleryService
    {
        private readonly TaxiNetDbContext _dbContext;

        public GalleryService(TaxiNetDbContext taxiNetDbContext)
        {
            _dbContext = taxiNetDbContext;
        }

        public GalleryItem Get(int id)
        {
            return _dbContext.Gallery.FirstOrDefault(a => a.Id == id);
        }

        public List<GalleryItem> GetAll()
        {
            return _dbContext.Gallery.ToList();
        }

        public void Update(GalleryItem galleryItem)
        {
            _dbContext.Gallery.Update(galleryItem);
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"Gallery item {galleryItem.Id} not found!");
            }
        }

        public void Delete(int id)
        {
            _dbContext.Gallery.Remove(Get(id));
            _dbContext.SaveChanges();
        }
    }
}
