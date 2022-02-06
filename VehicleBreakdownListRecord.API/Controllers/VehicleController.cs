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
            return CreateActionResult(CostomResultDto<List<VehicleWithBreakdownAndCommentDto>>.Success(_vehicle.VehicleWithBreakdownListAndComment(),200));
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
            var vehicletDto = _mapper.Map<List<VehivleDto>>(vehicle.ToList());
            return CreateActionResult(CostomResultDto<List<VehivleDto>>.Success(vehicletDto,200));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var vehicle = _vehicle.GetById(id);
            var vehicletDto = _mapper.Map<VehivleDto>(vehicle);
            return CreateActionResult(CostomResultDto<VehivleDto>.Success(vehicletDto, 200));
        }

        [HttpPost]
        public IActionResult Add(VehivleDto vehicleDto)
        {
            _vehicle.Add(_mapper.Map<Vehicle>(vehicleDto));
            return CreateActionResult(CostomResultDto<NoContentDto>.Success(201));
        }
        [HttpPut]
        public IActionResult Update(VehicleUpdateDto vehicleDto)
        {
            _vehicle.Update(_mapper.Map<Vehicle>(vehicleDto));
            return CreateActionResult(CostomResultDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _vehicle.Delete(id);
            return CreateActionResult(CostomResultDto<NoContentDto>.Success(204));
        }
    }
}
