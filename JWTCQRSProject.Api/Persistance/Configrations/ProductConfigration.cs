﻿using JWTCQRSProject.Api.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JWTCQRSProject.Api.Persistance.Configrations
{
    public class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
           builder.HasOne(x=>x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
        }
    }
}
