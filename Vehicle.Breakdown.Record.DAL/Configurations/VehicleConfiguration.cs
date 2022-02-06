using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleBreakdownRecord.Entity.Entities;

namespace VehicleBreakdownRecord.DAL.Configurations
{
    internal class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseIdentityColumn();
            builder.Property(x => x.VehicleName)
                 .IsRequired()
                 .HasMaxLength(50);
            builder.Property(x => x.VehicleOwnerName)
                 .IsRequired()
                 .HasMaxLength(50);
            builder.Property(x => x.VehicleOwnerLastname)
                 .IsRequired()
                 .HasMaxLength(50);
            builder.Property(x => x.VehicleOwnerPhone)
                 .IsRequired()
                 .HasMaxLength(15);
            builder.Property(x => x.VehicleChassisNumber)
                 .IsRequired()
                 .HasMaxLength(50);
            
        }
    }
}
