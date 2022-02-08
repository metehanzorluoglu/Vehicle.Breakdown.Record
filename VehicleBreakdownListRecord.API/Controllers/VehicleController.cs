using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VehicleBreakdownRecor.Business.Interfaces;
using VehicleBreakdownRecord.Entity.DTOs;
using VehicleBreakdownRecord.Entity.Entities;

namespace VehicleBreakdownListRecord.API.Controllers
{
    /*
     * [x] VehicleWithBC (Get)
     * [ ] VehicleAddComment (Post)
     * [ ] VehicleAddBreakdow (Post)
     * [x] GetAll (Vehicle)
     * [x] GetById (Vehicle)
     * [x] Add (Vehicle)
     * [x] Update (Vehicle)
     * [x] Delete (Vehicle)
     */



    public class VehicleController : CostomBaseController
    {

        private IVehicleBusiness _vehicle;
        private IMapper _mapper;

        public VehicleController(IMapper mapper, IVehicleBusiness vehicleBusiness)
        {

            _mapper = mapper;
            _vehicle = vehicleBusiness;
        }

        [HttpGet("[action]")]
        public IActionResult VehicleWithBC()
        {
            return CreateActionResult(CustomResultDto<List<VehicleWithBreakdownAndCommentDto>>.Success(_vehicle.VehicleWithBreakdownListAndComment(),200));
        }

        //[HttpGet("[action]")]
        //public IActionResult VehicleWithComment()
        //{
        //    return Ok(_vehicleBusiness.VehicleWithComment());
        //}



        [HttpGet]
        public IActionResult GetAll()
        {
            var vehicle= _vehicle.GetAll();
            var vehicletDto = _mapper.Map<List<VehicleDto>>(vehicle.ToList());
            return CreateActionResult(CustomResultDto<List<VehicleDto>>.Success(vehicletDto,200));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var vehicle = _vehicle.GetById(id);
            var vehicletDto = _mapper.Map<VehicleDto>(vehicle);
            return CreateActionResult(CustomResultDto<VehicleDto>.Success(vehicletDto, 200));
        }

        [HttpPost]
        public IActionResult Add(VehicleDto vehicleDto)
        {
            _vehicle.Add(_mapper.Map<Vehicle>(vehicleDto));
            return CreateActionResult(CustomResultDto<NoContentDto>.Success(201));
        }
        [HttpPut]
        public IActionResult Update(VehicleUpdateDto vehicleDto)
        {
            _vehicle.Update(_mapper.Map<Vehicle>(vehicleDto));
            return CreateActionResult(CustomResultDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _vehicle.Delete(id);
            return CreateActionResult(CustomResultDto<NoContentDto>.Success(204));
        }
    }
}
