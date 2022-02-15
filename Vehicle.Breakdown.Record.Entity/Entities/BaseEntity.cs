using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace VehicleBreakdownRecord.Entity.Entities
{
    public class BaseEntity
    {
        
        public int Id { get; set; }
        [JsonIgnore]
        public DateTime CreateDate { get; set; }
        [JsonIgnore]
        public DateTime? UpdateDate { get; set; }
        [JsonIgnore]
        public DateTime? DeleteDate { get; set; }
    }
}
