using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VehicleBreakdownRecor.Business.Interfaces;
using VehicleBreakdownRecord.Entity.DTOs;

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
        private IBaseBusiness<VehicleCommentDto> _comment;
        private IMapper _mapper;

        public VehicleCommentController(IBaseBusiness<VehicleCommentDto> comment, IMapper mapper)
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
    }
}
