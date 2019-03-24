using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IIASA.EOCS.PhotoMicroService.Models;

namespace IIASA.EOCS.PhotoMicroService.DBContexts
{
    public class PhotoContext : DbContext
    {
        public PhotoContext(DbContextOptions<PhotoContext> options) : base(options)
        {
        }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<LandCategory> LandCategories { get; set; }
        public DbSet<DirectionType> DirectionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // create Land Category Table and records on startup.
            modelBuilder.Entity<LandCategory>().HasData(
                new LandCategory
                {
                    Id = 1,
                    Name = "Residential",
                    Description = "Land with house and Aprtments",
                },
                new LandCategory
                {
                    Id = 2,
                    Name = "Amenities",
                    Description = "Cinema, Museums,Airport etc...",
                },
                new LandCategory
                {
                    Id = 3,
                    Name = "Recreation,Sport",
                    Description = "Parks, Stadiumms etc..",
                },
                new LandCategory
                {
                    Id = 4,
                    Name = "Commerce",
                    Description = "Shops, Supermarkets etc...",
                },
                new LandCategory
                {
                    Id = 5,
                    Name = "Construction",
                    Description = "Building or developement going on.",
                },
                 new LandCategory
                 {
                     Id = 6,
                     Name = "Agriculture",
                     Description = "Crops or other fileds.",
                 },
                  new LandCategory
                  {
                      Id = 7,
                      Name = "Forestry",
                      Description = "Forest land.",
                  },
                   new LandCategory
                   {
                       Id = 8,
                       Name = "Insdustry",
                       Description = "Factory or Manufacturing Plants.",
                   },
                    new LandCategory
                    {
                        Id = 9,
                        Name = "Transport",
                        Description = "Road, streets or Rail.",
                    }
            );

            // create Direction Type Table and records on startup.

            modelBuilder.Entity<DirectionType>().HasData(
                 new DirectionType
                 {
                     Id = 1,
                     Name = "North",
                     Description = "Photo Taken towards North",
                 },
                 new DirectionType
                 {
                     Id = 2,
                     Name = "South",
                     Description = "Photo Taken towards South",
                 },
                  new DirectionType
                  {
                      Id = 3,
                      Name = "East",
                      Description = "Photo Taken towards East",
                  },
                   new DirectionType
                   {
                       Id = 4,
                       Name = "West",
                       Description = "Photo Taken towards West",
                   },
                    new DirectionType
                    {
                        Id = 5,
                        Name = "Ground",
                        Description = "Photo Taken towards Ground",
                    }
                );
        }


    }
}
