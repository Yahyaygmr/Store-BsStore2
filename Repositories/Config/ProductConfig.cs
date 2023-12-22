using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductName).IsRequired();
            builder.HasData(
           new Product() { ProductId = 1, ImageUrl = "/images/1.jpg", ProductName = "Sunglases", Price = 1700, CategoryId = 1, ShowCase = true },
           new Product() { ProductId = 2, ImageUrl = "/images/2.jpg", ProductName = "Watch", Price = 2000, CategoryId = 2, ShowCase = true },
           new Product() { ProductId = 3, ImageUrl = "/images/3.jpg", ProductName = "Sneakers", Price = 700, CategoryId = 3, ShowCase = true },
           new Product() { ProductId = 4, ImageUrl = "/images/4.jpg", ProductName = "Camera", Price = 3500, CategoryId = 1, ShowCase = true },
           new Product() { ProductId = 5, ImageUrl = "/images/5.jpg", ProductName = "Toy", Price = 300, CategoryId = 2, ShowCase = false },
           new Product() { ProductId = 6, ImageUrl = "/images/6.jpg", ProductName = "Backpack", Price = 700, CategoryId = 3, ShowCase = true },
           new Product() { ProductId = 7, ImageUrl = "/images/7.jpg", ProductName = "Earphone", Price = 900, CategoryId = 1, ShowCase = true },
           new Product() { ProductId = 8, ImageUrl = "/images/8.jpg", ProductName = "Camera2", Price = 900, CategoryId = 1, ShowCase = false },
           new Product() { ProductId = 9, ImageUrl = "/images/1.jpg", ProductName = "Xp-Pen", Price = 900, CategoryId = 2, ShowCase = true },
           new Product() { ProductId = 10, ImageUrl = "/images/2.jpg", ProductName = "Galaxy FE", Price = 9000, CategoryId = 1, ShowCase = true },
           new Product() { ProductId = 11, ImageUrl = "/images/3.jpg", ProductName = "Hp Mouse", Price = 600, CategoryId = 3, ShowCase = false }
       );
        }
    }
}
