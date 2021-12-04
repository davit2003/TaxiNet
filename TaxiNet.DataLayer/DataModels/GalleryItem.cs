using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TaxiNet.DataLayer.DataModels.Enums;

namespace TaxiNet.DataLayer
{
    [Table("Gallery")]
    public class GalleryItem
    {
        [Key]
        public int? Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public GalleryItemType GalleryItemType { get; set; }
        public DateTime Created { get; private set; }
        public DateTime? LastModified { get; set; }

        public GalleryItem()
        {
            Created = DateTime.Now;
            LastModified = DateTime.Now;
        }
    }
}
