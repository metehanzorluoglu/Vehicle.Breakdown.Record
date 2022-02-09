using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleBreakdownRecor.Business.Exceptions;
using VehicleBreakdownRecor.Business.Interfaces;
using VehicleBreakdownRecord.DAL.Interfaces;
using VehicleBreakdownRecord.Entity.DTOs;
using VehicleBreakdownRecord.Entity.Entities;

namespace VehicleBreakdownRecor.Business.Concretes
{
    public class VehicleBusiness : IVehicleBusiness
    {
        private IVehicleRepository _vehicle;
        private IMapper _mapper;

        public VehicleBusiness( IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _vehicle = vehicleRepository;
            _mapper = mapper;
        }

        public Vehicle Add(Vehicle entity)
        {
            return _vehicle.Add(entity);
        }

        public void Delete(int id)
        {
            var hasVehicle = _vehicle.GetByID(id);
            if (hasVehicle != null)
                _vehicle.Delete(id);
            throw new NotFoundException($"{typeof(Vehicle).Name}({id}) is not found!");

        }

        public List<Vehicle> GetAll()
        {
            return _vehicle.GetAll();
        }

        public Vehicle GetById(int id)
        {

            var hasVehicle = _vehicle.GetByID(id);
            if (hasVehicle != null)
                return hasVehicle;
            throw new NotFoundException($"{typeof(Vehicle).Name}({id}) is not found!");
        }

        public VehicleDto PatchUpdate(int id, JsonPatchDocument<Vehicle> vehiclePatch)
        {
            var vehicleWithId = _vehicle.GetByID(id);
            if (vehicleWithId != null)
            {
                vehicleWithId.UpdateDate = DateTime.Now;
                
                vehiclePatch.ApplyTo(vehicleWithId);
                var vehicleDto = _mapper.Map<VehicleDto>(vehicleWithId);
                _vehicle.Update(vehicleWithId);
                return vehicleDto;
            }
            throw new NotFoundException($"{typeof(Vehicle).Name}({id}) is not found!");
        }

        public Vehicle Update(Vehicle entity)
        {
            return _vehicle.Update(entity);
        }

        public List<VehicleWithBreakdownAndCommentDto> VehicleWithBreakdownListAndComment()
        {
            var vehicle = _vehicle.VehicleWithBreakdownListAndComment();
            var vehicleWithBC = _mapper.Map<List<VehicleWithBreakdownAndCommentDto>>(vehicle);
            return vehicleWithBC;
        }

        //public List<VehicleWithCommentDto> VehicleWithComment()
        //{
        //    var vehicle = _vehicleRepository.VehicleWithComment();
        //    var vehicleWithC = _mapper.Map<List<VehicleWithCommentDto>>(vehicle);
        //    return vehicleWithC;
        //    //return vehicle;
        //}
    }
}
