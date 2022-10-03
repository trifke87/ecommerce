using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(p => p.PhoneNumber).IsRequired().HasMaxLength(100);
            builder.Property(p=>p.TotalAmount).HasColumnType("decimal(18,2)");
            builder.Property(p=>p.Discount).HasColumnType("decimal(18,2)");
        }
    }
}
