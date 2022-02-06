using System;
using System.Collections.Generic;
using System.Text;
using VehicleBreakdownRecord.Entity.DTOs;
using VehicleBreakdownRecord.Entity.Entities;

namespace VehicleBreakdownRecord.DAL.Interfaces
{
    public interface IVehicleRepository:IBaseInterface<Vehicle>
    {
        List<Vehicle> VehicleWithBreakdownListAndComment();
        //List<Vehicle> VehicleWithComment();

    }
}
