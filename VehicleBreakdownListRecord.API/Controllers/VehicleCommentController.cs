using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VehicleBreakdownRecor.Business.Interfaces;
using VehicleBreakdownRecord.Entity.DTOs;
using VehicleBreakdownRecord.Entity.Entities;

namespace VehicleBreakdownListRecord.API.Controllers
{
    /*
     * [x] GetAll (VehicleComment)
     * [x] GetById (VehicleComment)
     * [x] Add (VehicleComment)
     * [x] Update (VehicleComment)
     * [x] Delete (VehicleComment)
     */

    public class VehicleCommentController : CustomBaseController
    {
        private readonly IVehicleCommentBusiness _comment;
        private IMapper _mapper;

        public VehicleCommentController(IVehicleCommentBusiness comment, IMapper mapper)
        {
            _comment = comment;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return CreateActionResult(CustomResultDto<List<VehicleCommentDto>>.Success(_comment.GetAll(), 200));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return CreateActionResult(CustomResultDto<VehicleCommentDto>.Success(_comment.GetById(id), 200));
        }

        [HttpPost]
        public IActionResult Add(VehicleCommentDto breakdownListDto)
        {
            _comment.Add(breakdownListDto);
            return CreateActionResult(CustomResultDto<NoContentDto>.Success(201));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _comment.Delete(id);
            return CreateActionResult(CustomResultDto<NoContentDto>.Success(204));
        }
        [HttpPut]
        public IActionResult Update(VehicleCommentDto vehicleCommentDto)
        {
            _comment.Update(_mapper.Map<VehicleCommentDto>(vehicleCommentDto));
            return CreateActionResult(CustomResultDto<NoContentDto>.Success(204));
        }
        [HttpPatch("patch/{id}")]
        public IActionResult Patch(int id, JsonPatchDocument<VehicleComment> vehiclePatch)
        {
            var vehicleDto = _comment.PatchUpdate(id, vehiclePatch);

            return CreateActionResult(CustomResultDto<NoContentDto>.Success(204));

        }
    }
}
