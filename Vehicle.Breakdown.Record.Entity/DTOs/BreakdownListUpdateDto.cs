using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleBreakdownRecord.Entity.DTOs
{
    public class BreakdownListUpdateDto
    {
        public int Id { get; set; }
        public string BreakdownName { get; set; }
        //public bool IsValid { get; set; }
        //public DateTime UpdateDate { get; set; }
    }
}
