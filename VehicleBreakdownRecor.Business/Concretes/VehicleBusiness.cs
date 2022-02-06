using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleBreakdownRecor.Business.Interfaces;
using VehicleBreakdownRecord.DAL.Interfaces;
using VehicleBreakdownRecord.Entity.DTOs;
using VehicleBreakdownRecord.Entity.Entities;

namespace VehicleBreakdownRecor.Business.Concretes
{
    public class VehicleBusiness : IVehicleBusiness
    {
        private IBaseInterface<Vehicle> _vehicle;
        private IVehicleRepository _vehicleRepository;
        private IMapper _mapper;

        public VehicleBusiness(IBaseInterface<Vehicle> vehicle, IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _vehicle = vehicle;
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public Vehicle Add(Vehicle entity)
        {
           return _vehicle.Add(entity);
        }

        public void Delete(int id)
        {
            _vehicle.Delete(id);
        }

        public List<Vehicle> GetAll()
        {
           return _vehicle.GetAll();
        }

        public Vehicle GetById(int id)
        {
            if (id>0)
            return _vehicle.GetByID(id);
            throw new Exception("Id can not be less then 1");
        }

        public Vehicle Update(Vehicle entity)
        {
            return _vehicle.Update(entity);
        }

        public List<VehicleWithBreakdownAndCommentDto> VehicleWithBreakdownListAndComment()
        {
            var vehicle= _vehicleRepository.VehicleWithBreakdownListAndComment();
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
