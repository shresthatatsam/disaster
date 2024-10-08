﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using DisasterModels.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DisasterDataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<DisasterViewModel> DisasterInformation { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<DisasterViewModel>(entity =>
            {
                entity.ToTable("DisasterInformation");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Isactive).HasDefaultValue(true); 
                entity.Property(e => e.created_at).HasDefaultValueSql("CURRENT_TIMESTAMP");

            });

        }

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
