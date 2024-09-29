using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisasterModels.Models;
using Microsoft.EntityFrameworkCore;

namespace DisasterDataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<DisasterViewModel> DisasterInformation { get; set; }
        //public DbSet<DisasterPhotos> DisasterPhotos { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<DisasterPhotos>(entity =>
        //           {

        //               entity.HasKey(e => e.Id);
        //               entity.HasOne(p => p.DisasterReport)
        //                 .WithMany(v => v.Photos)
        //                 .HasForeignKey(p => p.DisasterId)
        //                 .OnDelete(DeleteBehavior.Restrict);
        //           });
        //}
    }
}
