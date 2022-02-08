using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VehicleBreakdownRecor.Business.Interfaces;
using VehicleBreakdownRecord.Entity.DTOs;
using VehicleBreakdownRecord.Entity.Entities;

namespace VehicleBreakdownListRecord.API.Controllers
{
    /*
     * [x] GetAll (BreakdownList)
     * [x] GetById (BreakdownList)
     * [x] Add (BreakdownList)
     * [x] Update (BreakdownList)
     * [x] Delete (BreakdownList)
     */

    public class BreakdownListController : CostomBaseController
    {
        private IBaseBusiness<BreakdownListDto> _breakdownList;
        private IMapper _mapper;

        public BreakdownListController(IBaseBusiness<BreakdownListDto> breakdownList, IMapper mapper)
        {
            _breakdownList = breakdownList;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return CreateActionResult(CustomResultDto<List<BreakdownListDto>>.Success(_breakdownList.GetAll(),200));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return CreateActionResult(CustomResultDto<BreakdownListDto>.Success(_breakdownList.GetById(id), 200));
        }

        [HttpPost]
        public IActionResult Add(BreakdownListDto breakdownListDto)
        {
            _breakdownList.Add(breakdownListDto);
            return CreateActionResult(CustomResultDto<NoContentDto>.Success(201));
        }
        [HttpDelete]
        public IActionResult Delete (int id)
        {
            _breakdownList.Delete(id);
            return CreateActionResult(CustomResultDto<NoContentDto>.Success(204));
        }
        [HttpPut]
        public IActionResult Update(BreakdownListUpdateDto breakdownListUpdateDto)
        {
            _breakdownList.Update(_mapper.Map<BreakdownListDto>(breakdownListUpdateDto));
            return CreateActionResult(CustomResultDto<NoContentDto>.Success(204));
        }
    }
}
