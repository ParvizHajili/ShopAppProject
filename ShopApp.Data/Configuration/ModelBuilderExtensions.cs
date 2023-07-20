using Microsoft.EntityFrameworkCore;
using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Data.Configuration
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(
           new Product() { ProductId = 1, Name = "Samsung s5", Url = "samsung-s5", Price = 20, Description = "Fine", ImageUrl = "2.jpg", IsApproved = true },
           new Product() { ProductId = 2, Name = "Samsung s6", Url = "samsung-s6", Price = 30, Description = "Fine", ImageUrl = "3.jpg", IsApproved = false },
           new Product() { ProductId = 3, Name = "Samsung s7", Url = "samsung-s7", Price = 40, Description = "Fine", ImageUrl = "4.jpg", IsApproved = true },
           new Product() { ProductId = 4, Name = "Samsung s8", Url = "samsung-s8", Price = 50, Description = "Fine", ImageUrl = "5.jpg", IsApproved = false },
           new Product() { ProductId = 5, Name = "Samsung s9", Url = "samsung-s9", Price = 60, Description = "Fine", ImageUrl = "1.jpg", IsApproved = true });


            builder.Entity<Category>().HasData(
          new Category() { CategoryId = 1, Name = "Telefon", Url = "telefon" },
          new Category() { CategoryId = 2, Name = "Kompyuter", Url = "kompyuter" },
          new Category() { CategoryId = 3, Name = "Elektronika", Url = "elektronika" },
          new Category() { CategoryId = 4, Name = "Geyim", Url = "geyim" },
          new Category() { CategoryId = 5, Name = "İkinci Əl", Url = "ikinci-əl" });


            builder.Entity<ProductCategory>().HasData(
           new ProductCategory() { ProductId = 1, CategoryId = 1 },
           new ProductCategory() { ProductId = 2, CategoryId = 1 },
           new ProductCategory() { ProductId = 3, CategoryId = 2 },
           new ProductCategory() { ProductId = 4, CategoryId = 1 },
           new ProductCategory() { ProductId = 5, CategoryId = 4 });
        }
    }
}
