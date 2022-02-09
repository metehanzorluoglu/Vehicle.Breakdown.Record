using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleBreakdownRecord.Entity.DTOs;
using VehicleBreakdownRecord.Entity.Entities;

namespace VehicleBreakdownRecor.Business.Interfaces
{
    public interface IBreakdownListBusiness:IBaseBusiness<BreakdownListDto>
    {
        BreakdownList PatchUpdate(int id, JsonPatchDocument<BreakdownList> vehiclePatch);
    }
}
