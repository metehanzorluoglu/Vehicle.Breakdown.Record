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
    public class VehicleCommentBusiness : IVehicleCommentBusiness
    {
        private readonly IBaseInterface<VehicleComment> _comment;
        private IMapper _mapper;

        public VehicleCommentBusiness(IMapper mapper, IBaseInterface<VehicleComment> comment)
        {
            _mapper = mapper;
            _comment = comment;
        }

        public VehicleCommentDto Add(VehicleCommentDto entity)
        {
            entity.CreateDate = DateTime.Now;
            var breakDown = _mapper.Map<VehicleComment>(entity);
            _comment.Add(breakDown);
            return entity;
        }

        public void Delete(int id)
        {
            var hasComment = _comment.GetByID(id);
            if (hasComment != null)
                _comment.Delete(id);
            throw new NotFoundException($"{typeof(VehicleComment).Name}({id}) is not found!");
        }

        public List<VehicleCommentDto> GetAll()
        {
            var comment = _comment.GetAll();
            var list = _mapper.Map<List<VehicleCommentDto>>(comment);
            return list;
        }

        public VehicleCommentDto GetById(int id)
        {
            var hasComment = _comment.GetByID(id);
            if (hasComment == null)
                throw new NotFoundException($"{typeof(VehicleComment).Name}({id}) is not found!");
            var commentId = _mapper.Map<VehicleCommentDto>(hasComment);
            return commentId;

        }

        public VehicleCommentDto PatchUpdate(int id, JsonPatchDocument<VehicleComment> vehiclePatch)
        {
            var vehicleCommentWithId = _comment.GetByID(id);
            if (vehicleCommentWithId != null)
                throw new NotFoundException($"{typeof(VehicleComment).Name}({id}) is not found!");
            vehicleCommentWithId.UpdateDate = DateTime.Now;
            vehiclePatch.ApplyTo(vehicleCommentWithId);
            var vehicleCommentDto = _mapper.Map<VehicleCommentDto>(vehicleCommentWithId);
            _comment.Update(vehicleCommentWithId);
            return vehicleCommentDto;
        }

        public VehicleCommentDto Update(VehicleCommentDto entity)
        {
            entity.UpdateDate = DateTime.Now;
            var update = _comment.Update(_mapper.Map<VehicleComment>(entity));
            var send = _mapper.Map<VehicleCommentDto>(update);
            return send;
        }
    }
}
