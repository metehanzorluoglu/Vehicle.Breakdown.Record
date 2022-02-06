using System.Collections;
using System.Collections.Generic;

namespace VehicleBreakdownRecord.Entity.Entities
{
    public class BreakdownList : BaseEntity
    {
        public string BreakdownName { get; set; }
        public bool IsValid { get; set; }
        public ICollection<VehicleBreakdownList> VehicleBreakdownLists { get; set; }

    }
}
