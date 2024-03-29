﻿using Microsoft.EntityFrameworkCore;
using P230_Pronia.Entities;

namespace P230_Pronia.DAL
{
    public class ProniaDbContext:DbContext
    {
        public ProniaDbContext(DbContextOptions<ProniaDbContext> options):base(options)
        {
            
        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PlantDeliveryInformation> PlantDeliveryInformation { get; set; }
        public DbSet<PlantImage> PlantImages { get; set; }
        public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Setting>()
                .HasIndex(s => s.Key)
                .IsUnique();
            modelBuilder.Entity<Categories>().HasIndex(c => c.Name).IsUnique();
            base.OnModelCreating(modelBuilder);
        }


    }
}
