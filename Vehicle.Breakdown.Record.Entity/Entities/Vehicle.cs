using System.Collections.Generic;

namespace VehicleBreakdownRecord.Entity.Entities
{
    public class Vehicle : BaseEntity
    {
        public string VehicleName { get; set; }
        public string VehicleOwnerName { get; set; }
        public string VehicleOwnerLastname { get; set; }
        public string VehicleOwnerPhone { get; set; }
        public string VehicleChassisNumber { get; set; }
        public ICollection<VehicleBreakdownList> VehicleBreakdownLists { get; set; }
        public ICollection<VehicleComment> VehicleComments { get; set; }

    }
}
