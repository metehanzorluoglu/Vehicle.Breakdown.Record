using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleBreakdownRecord.Entity.Entities;

namespace VehicleBreakdownRecord.DAL.Configurations
{
    internal class VehicleCommentConfiguration : IEntityTypeConfiguration<VehicleComment>
    {
        public void Configure(EntityTypeBuilder<VehicleComment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseIdentityColumn();
            builder.Property(x => x.Comment)
                 .IsRequired()
                 .HasMaxLength(250);
            //builder.HasOne(x=>x.Vehicle).WithMany(x=>x.VehicleComments).HasForeignKey(x=>x.VehicleId);
        }
    }
}
