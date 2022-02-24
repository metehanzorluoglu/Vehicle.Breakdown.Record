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
     * [x] GetAll (VehicleComment)
     * [x] GetById (VehicleComment)
     * [x] Add (VehicleComment)
     * [x] Update (VehicleComment)
     * [x] Delete (VehicleComment)
     */
    [Authorize]
    public class VehicleCommentController : CustomBaseController
    {
        private readonly IGenericService<VehicleComment, VehicleCommentDto> _comment;

        public VehicleCommentController(IGenericService<VehicleComment, VehicleCommentDto> comment)
        {
            _comment = comment;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _comment.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _comment.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(VehicleCommentDto breakdownListDto)
        {
            breakdownListDto.CreateDate= DateTime.Now;
            await _comment.AddAsync(breakdownListDto);
            return CreateActionResult(CustomResultDto<NoContentDto>.Success(201));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _comment.Remove(id);
            return CreateActionResult(CustomResultDto<NoContentDto>.Success(204));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, VehicleCommentDto vehicleCommentDto)
        {
            vehicleCommentDto.UpdateDate= DateTime.Now;
            await _comment.Update(id, vehicleCommentDto);
            return CreateActionResult(CustomResultDto<NoContentDto>.Success(204));
        }
        //[HttpPatch("patch/{id}")]
        //public IActionResult Patch(int id, JsonPatchDocument<VehicleComment> vehiclePatch)
        //{
        //    var vehicleDto = _comment.PatchUpdate(id, vehiclePatch);

        //    return CreateActionResult(CustomResultDto<NoContentDto>.Success(204));

        //}
    }
}
