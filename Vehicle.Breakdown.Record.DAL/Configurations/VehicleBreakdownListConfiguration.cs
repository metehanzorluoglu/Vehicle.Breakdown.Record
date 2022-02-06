using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleBreakdownRecord.Entity.Entities;

namespace VehicleBreakdownRecord.DAL.Configurations
{
    internal class VehicleBreakdownListConfiguration : IEntityTypeConfiguration<VehicleBreakdownList>
    {
        public void Configure(EntityTypeBuilder<VehicleBreakdownList> builder)
        {
            builder.HasKey(x => new
            {
                x.VehicleId,
                x.BreakdowListId
            });
        }
    }
}
