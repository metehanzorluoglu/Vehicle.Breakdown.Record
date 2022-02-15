using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleBreakdownRecord.Entity.Entities
{
    public class UserApp:IdentityUser
    {
        public string City { get; set; }
    }
}
