using EcommerceWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = "PD001",
                    Name = "Samsung Galaxy Z Fold3 5G 512GB",
                    Price = 44990000,
                    Const = 43990000,
                    Brand = "Samsung",
                    CreateDate = DateTime.UtcNow,
                    CreateUserId = "admin",
                    Description = ""
                });
        }
    }
}
