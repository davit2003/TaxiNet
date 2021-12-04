    using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaxiNet.DataLayer.DataModels;

namespace TaxiNet.DataLayer.DataAccess
{
    public class TaxiNetDbContext : DbContext
    {
        public TaxiNetDbContext(DbContextOptions<TaxiNetDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GalleryItem>().ToTable("Gallery");
            modelBuilder.Entity<User>().ToTable("Users");
        }
        public DbSet<GalleryItem> Gallery { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
