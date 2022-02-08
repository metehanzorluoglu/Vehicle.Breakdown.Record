using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleBreakdownRecord.Entity.DTOs
{
    public class VehicleWithCommentDto:VehicleDto
    {
        public List<VehicleCommentDto> VehicleComments { get; set;}
        //public List<BreakdownListDto> VehicleBreakdownLists { get; set;}
    }
}
