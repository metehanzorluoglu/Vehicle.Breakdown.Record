using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleBreakdownRecord.Entity.DTOs;
using VehicleBreakdownRecord.Entity.Entities;

namespace VehicleBreakdownRecor.Business.Interfaces
{
    public interface IVehicleBusiness:IBaseBusiness<Vehicle>
    {
        List<VehicleWithBreakdownAndCommentDto> VehicleWithBreakdownListAndComment();

        VehicleDto PatchUpdate(int id, JsonPatchDocument<Vehicle> vehiclePatch);
        //List<VehicleWithCommentDto> VehicleWithComment();
    }
}
