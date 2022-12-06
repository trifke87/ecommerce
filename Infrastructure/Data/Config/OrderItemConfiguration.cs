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
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(p=>p.UnitPrice).HasColumnType("decimal(18,2)");
            builder.Property(p => p.DiscountAmount).HasColumnType("decimal(18,2)");
            builder.Property(p => p.OriginalUnitPrice).HasColumnType("decimal(18,2)");
        }
    }
}
