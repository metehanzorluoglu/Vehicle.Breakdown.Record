﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace VehicleBreakdownRecord.Entity.DTOs
{
    public abstract class BaseDto
    {
        //[JsonIgnore]
        public int Id { get; set; }
        //public int Id { get; set; }
        [JsonIgnore]
        public DateTime CreateDate { get; set; } 

        [JsonIgnore]
        public DateTime UpdateDate { get; set; }

    }
}
