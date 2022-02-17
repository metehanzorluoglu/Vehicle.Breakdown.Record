using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleBreakdownRecor.Business.Interfaces;
using VehicleBreakdownRecord.Entity.DTOs;
using VehicleBreakdownRecord.Entity.Entities;
using VehicleBreakdownRecord.Entity.Services;

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


    [Authorize]
    public class VehicleController : CustomBaseController
    {

        //private IVehicleBusiness _vehicle;
        private readonly IGenericService<Vehicle,VehicleDto> _vehicle;

        public VehicleController( IGenericService<Vehicle, VehicleDto> vehicle)
        {
            _vehicle = vehicle;
        }
        /// <summary>
        /// Open When It can
        /// </summary>
        /// <returns></returns>
        //[HttpGet("[action]")]
        //public IActionResult VehicleWithBC()
        //{
        //    return CreateActionResult(CustomResultDto<List<VehicleWithBreakdownAndCommentDto>>.Success(_vehicle.VehicleWithBreakdownListAndComment(), 200));
        //}

        //[HttpGet("[action]")]
        //public IActionResult VehicleWithComment()
        //{
        //    return Ok(_vehicleBusiness.VehicleWithComment());
        //}



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vehicle = await  _vehicle.GetAllAsync();
            //var vehicletDto = _mapper.Map<List<VehicleDto>>(vehicle);
            //return CreateActionResult(CustomResultDto<List<VehicleDto>>.Success(vehicle, 200));
            return CreateActionResult(vehicle);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vehicle = await _vehicle.GetByIdAsync(id);
           // var vehicletDto = _mapper.Map<VehicleDto>(vehicle);
            return CreateActionResult(vehicle);
        }

        [HttpPost]
        public async Task<IActionResult> Add(VehicleDto vehicleDto)
        {
            await _vehicle.AddAsync(vehicleDto);
            return CreateActionResult(CustomResultDto<NoContentDto>.Success(201));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,VehicleDto vehicleDto)
        {
            await _vehicle.Update(id,vehicleDto);
            return CreateActionResult(CustomResultDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           await _vehicle.Remove(id);
            return CreateActionResult(CustomResultDto<NoContentDto>.Success(204));
        }
        /// <summary>
        /// Open When It can
        /// </summary>
        /// <returns></returns>
        //[HttpPatch("patch/{id}")]
        //public IActionResult Patch(int id,  JsonPatchDocument<Vehicle> vehiclePatch)
        //{
        //    var vehicleDto= _vehicle.PatchUpdate(id, vehiclePatch);

        //    return CreateActionResult(CustomResultDto<NoContentDto>.Success(204));

        //}
    }
}
