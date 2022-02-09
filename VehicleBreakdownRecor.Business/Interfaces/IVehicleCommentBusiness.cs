using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleBreakdownRecord.Entity.DTOs;
using VehicleBreakdownRecord.Entity.Entities;

namespace VehicleBreakdownRecor.Business.Interfaces
{
    public interface IVehicleCommentBusiness:IBaseBusiness<VehicleCommentDto>
    {
        VehicleCommentDto PatchUpdate(int id, JsonPatchDocument<VehicleComment> vehiclePatch);
    }
}
