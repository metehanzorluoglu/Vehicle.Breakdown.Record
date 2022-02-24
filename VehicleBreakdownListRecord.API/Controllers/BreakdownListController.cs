using System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleBreakdownRecor.Business.Interfaces;
using VehicleBreakdownRecord.Entity.DTOs;
using VehicleBreakdownRecord.Entity.Entities;
using VehicleBreakdownRecord.Entity.Services;

namespace VehicleBreakdownListRecord.API.Controllers
{
    /*
     * [x] GetAll (BreakdownList)
     * [x] GetById (BreakdownList)
     * [x] Add (BreakdownList)
     * [x] Update (BreakdownList)
     * [x] Delete (BreakdownList)
     */
    [Authorize]
    public class BreakdownListController : CustomBaseController
    {
        private readonly IGenericService<BreakdownList, BreakdownListDto> _breakdownList;

        public BreakdownListController(IGenericService<BreakdownList, BreakdownListDto> breakdownList)
        {
            _breakdownList = breakdownList;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _breakdownList.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _breakdownList.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(BreakdownListDto breakdownListDto)
        {
            breakdownListDto.CreateDate= DateTime.Now;
           await _breakdownList.AddAsync(breakdownListDto);
            return CreateActionResult(CustomResultDto<NoContentDto>.Success(201));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
           await _breakdownList.Remove(id);
            return CreateActionResult(CustomResultDto<NoContentDto>.Success(204));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,BreakdownListDto breakdownListUpdateDto)
        {
            breakdownListUpdateDto.UpdateDate= DateTime.Now;
           await _breakdownList.Update(id,breakdownListUpdateDto);
            return CreateActionResult(CustomResultDto<NoContentDto>.Success(204));
        }
        //[HttpPatch("patch/{id}")]
        //public IActionResult Patch(int id, JsonPatchDocument<BreakdownList> vehiclePatch)
        //{
        //    var vehicleDto = _breakdownList.PatchUpdate(id, vehiclePatch);

        //    return CreateActionResult(CustomResultDto<NoContentDto>.Success(204));

        //}
    }
}
