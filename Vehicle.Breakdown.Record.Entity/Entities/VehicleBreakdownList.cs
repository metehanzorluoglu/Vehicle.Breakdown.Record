using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VehicleBreakdownRecord.Entity.Entities
{
    public class VehicleBreakdownList
    {
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        [ForeignKey("BreakdownList")]
        public int BreakdowListId { get; set; }

        public Vehicle Vehicle { get; set; }
        public BreakdownList BreakdownList { get; set; }

    }
}
