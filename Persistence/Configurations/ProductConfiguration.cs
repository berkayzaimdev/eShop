﻿using Domain.Customers;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasConversion(
                productId => productId.Value,
                value => new ProductId(value));

            builder.Property(p => p.Sku)
                .HasConversion(
                sku => sku.Value,
                value => Sku.Create(value)!);


            // product'a dahili olan parametre, bir entity olmadığı için Owns metodunu kullandık
            builder.OwnsOne(p => p.Price, priceBuilder => 
            {
                priceBuilder.Property(m => m.Currency).HasMaxLength(3);
            });
        }
    }
}
