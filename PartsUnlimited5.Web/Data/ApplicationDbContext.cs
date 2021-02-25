using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PartsUnlimited5.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartsUnlimited5.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CommunityPost> CommunityPosts { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get;  set; }
        public DbSet<Raincheck> Rainchecks { get; set; }
        public DbSet<RaincheckProduct> RaincheckProducts { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreProduct> StoreProducts { get; set; }
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DateTime seedDateTime = new DateTime(2021, 01, 01);
            
            //TODO: Create an admin user
            //TODO: Reference the admin user id here
            //TODO: Seed the products here too

            modelBuilder.Entity<Category>().HasData(new Category { CreatedDate = seedDateTime, Description = "Brakes for your buggy",  IsActive = true, Name = "Brakes" });
            modelBuilder.Entity<Category>().HasData(new Category { CreatedDate = seedDateTime, Description = "Lighting for your buggy", IsActive = true, Name = "Lighting" });
            modelBuilder.Entity<Category>().HasData(new Category { CreatedDate = seedDateTime, Description = "Wheels and Tires for your buggy", IsActive = true, Name = "WheelsAndTires" });
            modelBuilder.Entity<Category>().HasData(new Category { CreatedDate = seedDateTime, Description = "Batteries for your buggy", IsActive = true, Name = "Batteries" });
            modelBuilder.Entity<Category>().HasData(new Category { CreatedDate = seedDateTime, Description = "Oil for your buggy", IsActive = true, Name = "Oil" });
            
        }
    }
}
