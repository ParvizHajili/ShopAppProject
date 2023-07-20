using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(m => m.ProductId);
            builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
           //builder.Property(m => m.AddedDate).HasDefaultValueSql("date('now')"); //sqllite
            builder.Property(m => m.AddedDate).HasDefaultValueSql("getdate()");//mssql
        }
    }
}
