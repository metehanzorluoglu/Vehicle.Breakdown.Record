using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleBreakdownRecor.Business.Services
{
    public static class SignService
    {
        public static SecurityKey GetSymmetricSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
