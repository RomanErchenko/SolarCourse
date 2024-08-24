using Microsoft.EntityFrameworkCore;
using SolarLab.Academy.Domain;
using SolarLab.Academy.Domain.Advert;
using SolarLab.Academy.Domain.Userss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLab.Academy.Infrastructure
{
    public class BoardDbContext:DbContext
    {
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        public BoardDbContext(DbContextOptions<BoardDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


          //  modelBuilder.Entity<Advert>().HasData(
          //new Advert 
          //{
          // Id = new Guid("e5878c94-90eb-47f5-a52f-c1c9e65171cc"), 
          // Name = "car sale",
          // Description = " new car for sale .",
           
          //},

          //new Advert
          //{
          //    Id = new Guid("e5178c94-88eb-47f5-a52f-c1c9e65171cc"),
          //    Name = "bike sale",
          //    Description = " new bike for sale .",

          //}
          //  );

           base.OnModelCreating(modelBuilder);



        }
    }
}
