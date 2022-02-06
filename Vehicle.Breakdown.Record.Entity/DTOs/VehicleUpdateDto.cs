using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleBreakdownRecord.Entity.DTOs
{
    public class VehicleUpdateDto
    {
        public int Id { get; set; }
        public string VehicleName { get; set; }
        public string VehicleOwnerName { get; set; }
        public string VehicleOwnerLastname { get; set; }
        public string VehicleOwnerPhone { get; set; }
        public string VehicleChassisNumber { get; set; }
        public DateTime UpdateDate { get; set; } 
    }
}
