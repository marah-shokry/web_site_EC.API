using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastrcuture.Configuration
{     public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("CartItems");
            builder.HasKey(i=> i.Id);
            builder.Property(i=>i.Quantity).IsRequired();
            builder.Property(i=>i.UnitPrice).IsRequired().HasPrecision(18, 2);



            builder.HasOne(i => i.Product)
            .WithMany(p => p.CartItems)
            .HasForeignKey(i => i.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
