using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleBreakdownRecord.Entity.Entities;

namespace VehicleBreakdownRecord.DAL.Configurations
{
    internal class BreakdownListConfiguration : IEntityTypeConfiguration<BreakdownList>
    {
        public void Configure(EntityTypeBuilder<BreakdownList> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseIdentityColumn();
            builder.Property(x => x.BreakdownName)
                 .IsRequired()
                 .HasMaxLength(50);
            
        }
    }
}
