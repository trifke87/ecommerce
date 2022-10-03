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
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(p => p.City).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Street).IsRequired().HasMaxLength(100);
            builder.Property(p => p.HouseNumber).IsRequired().HasMaxLength(50);
        }
    }
}
