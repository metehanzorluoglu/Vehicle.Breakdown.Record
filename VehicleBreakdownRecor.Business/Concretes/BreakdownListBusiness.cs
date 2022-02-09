using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using VehicleBreakdownRecor.Business.Exceptions;
using VehicleBreakdownRecor.Business.Interfaces;
using VehicleBreakdownRecord.DAL.Interfaces;
using VehicleBreakdownRecord.Entity.DTOs;
using VehicleBreakdownRecord.Entity.Entities;

namespace VehicleBreakdownRecor.Business.Concretes
{
    public class BreakdownListBusiness : IBreakdownListBusiness
    {
        private IBaseInterface<BreakdownList> _breakdownList;
        private IMapper _mapper;

        public BreakdownListBusiness(IBaseInterface<BreakdownList> breakdownList, IMapper mapper)
        {
            this._breakdownList = breakdownList;
            _mapper = mapper;
        }

        public BreakdownListDto Add(BreakdownListDto entity)
        {
            entity.CreateDate = DateTime.Now;
            var breakDown = _mapper.Map<BreakdownList>(entity);
            _breakdownList.Add(breakDown);
            return entity;
        }

        public void Delete(int id)
        {
            var hasBreakDown = _breakdownList.GetByID(id);
            if (hasBreakDown == null)
                throw new NotFoundException($"{typeof(VehicleComment).Name}({id}) is not found!");
            _breakdownList.Delete(id);
        }

        public List<BreakdownListDto> GetAll()
        {
            var breakDown = _breakdownList.GetAll();
            var list = _mapper.Map<List<BreakdownListDto>>(breakDown);
            return list;
        }

        public BreakdownListDto GetById(int id)
        {

            var hasBreakDown = _breakdownList.GetByID(id);
            if (hasBreakDown == null)
                throw new NotFoundException($"{typeof(VehicleComment).Name}({id}) is not found!");
            var breakDownId = _mapper.Map<BreakdownListDto>(hasBreakDown);
            return breakDownId;


            throw new Exception("Id can not be less then 1");
        }

        public BreakdownList PatchUpdate(int id, JsonPatchDocument<BreakdownList> vehiclePatch)
        {
            var breakdownListWithId = _breakdownList.GetByID(id);
            if (breakdownListWithId == null)
                throw new NotFoundException($"{typeof(VehicleComment).Name}({id}) is not found!");
            breakdownListWithId.UpdateDate = DateTime.Now;
            vehiclePatch.ApplyTo(breakdownListWithId);
            var breakdownListDto = _mapper.Map<BreakdownList>(breakdownListWithId);
            _breakdownList.Update(breakdownListWithId);
            return breakdownListDto;


        }

        public BreakdownListDto Update(BreakdownListDto entity)
        {
            entity.UpdateDate = DateTime.Now;
            var update = _breakdownList.Update(_mapper.Map<BreakdownList>(entity));
            var send = _mapper.Map<BreakdownListDto>(update);
            //send.UpdateDate = DateTime.Now;
            return send;
        }




    }
}
