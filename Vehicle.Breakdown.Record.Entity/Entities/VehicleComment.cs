using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleBreakdownRecord.Entity.Entities
{
    public class VehicleComment:BaseEntity
    {
        public string Comment { get; set; }
        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
