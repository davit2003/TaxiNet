using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiNet.DataLayer
{
    public class Slide
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Created { get; private set; }
        public DateTime Updated { get; set; }

        public Slide()
        {
            Created = DateTime.Now;
        }
        public Slide(int id, string title, string subtitle, string imageUrl) 
        { 
            Id = id; 
            Title = title; 
            Subtitle = subtitle; 
            ImageUrl = imageUrl;
        }
    }
}
