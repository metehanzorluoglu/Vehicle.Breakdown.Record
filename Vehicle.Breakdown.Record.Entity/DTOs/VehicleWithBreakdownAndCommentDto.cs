using System;
using System.Collections.Generic;
using System.Text;
using VehicleBreakdownRecord.Entity.Entities;

namespace VehicleBreakdownRecord.Entity.DTOs
{
    public class VehicleWithBreakdownAndCommentDto: VehivleDto
    {
        //public int Id { get; set; }
        public List<BreakdownListDto> BreakdownList { get; set; }
        public List<VehicleCommentDto> VehicleComments { get; set; }

    }
}
