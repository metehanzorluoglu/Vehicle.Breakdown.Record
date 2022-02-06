using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleBreakdownRecord.Entity.DTOs
{
    public class BreakdownListDto:BaseDto
    {
        public int Id { get; set; }
        public string BreakdownName { get; set; }
    }
}
